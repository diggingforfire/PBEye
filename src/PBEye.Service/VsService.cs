using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PBEye.Service.Models;

namespace PBEye.Service
{
	internal class VsService : IVsService
	{
		private string _url;
		private string _username;
		private string _password;

		public VsService(string url, string username, string password)
		{
			_username = username;
			_password = password;
			_url = url;
		}

		public IList<WorkItem> GetWorkItems()
		{
			var workItems = new List<WorkItem>();

			var parameters = new Dictionary<string, string>
			{
				{ "api-version", "1.0" }
			};

			var body = new
			{
				Query = "SELECT * FROM WorkItems WHERE State = 'In Progress'"
			};

			var result = Post($"{_url}/DefaultCollection/_apis/wit/wiql", parameters, body);

			var workItemsResult = (WorkItemsResult)JsonConvert.DeserializeObject(result, typeof(WorkItemsResult));

			var workItemIds = workItemsResult.WorkItems.Select(workItemMeta => workItemMeta.Id).ToList();


			int take = 200;
			int offset = 0;

			while (workItemIds.Count > offset)
			{
				var workItemParameters = new Dictionary<string, string>
				{
					{ "api-version", "1.0" },
					{ "ids", string.Join(",", workItemIds.Skip(offset).Take(take)) },
					{ "$expand", "all" }
				};

				offset += take;

				var partialWorkItemsResult = Get($"{_url}/DefaultCollection/_apis/wit/workitems", workItemParameters).Result;


				var partialWorkItems = (WorkItemResult)JsonConvert.DeserializeObject(partialWorkItemsResult, typeof(WorkItemResult));

				workItems.AddRange(partialWorkItems.WorkItems.Select(workItem => new WorkItem
				{
					Id = workItem.GetField("System.Id"),
					Title = workItem.GetField("System.Title"),
					State = workItem.GetField("System.State"),
					Team = workItem.GetField("System.NodeName"),
					AssignedTo = workItem.GetField("AssignedTo"),
					Sprint = workItem.GetField("System.IterationLevel3"),
					Description = workItem.GetField("System.Description"),
					Effort = workItem.GetField("Microsoft.VSTS.Scheduling.Effort"),
					AcceptanceCriteria = workItem.GetField("Microsoft.VSTS.Common.AcceptanceCriteria"),
					Changed = workItem.GetField("System.ChangedDate")
				}));
			}

			return workItems;
		}

		public WorkItem GetWorkItem(int id)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "api-version", "1.0" },
				{ "ids", id.ToString() },
				{ "$expand", "all" }
			};

			var result = Get($"{_url}/DefaultCollection/_apis/wit/workitems", parameters).Result;

			var workItemResult = (WorkItemResult)JsonConvert.DeserializeObject(result, typeof(WorkItemResult));

			if (workItemResult.Count == 0)
			{
				return null;
			}

			var workItem = workItemResult.WorkItems[0];

			var workItemClean = new WorkItem
			{
				Id = workItem.GetField("System.Id"),
				Title = workItem.GetField("System.Title"),
				State = workItem.GetField("System.State"),
				Team = workItem.GetField("System.NodeName"),
				AssignedTo = workItem.GetField("AssignedTo"),
				Sprint = workItem.GetField("System.IterationLevel3"),
				Description = workItem.GetField("System.Description"),
				Effort = workItem.GetField("Microsoft.VSTS.Scheduling.Effort"),
				AcceptanceCriteria = workItem.GetField("Microsoft.VSTS.Common.AcceptanceCriteria"),
				Changed = workItem.GetField("System.ChangedDate")
			};

			return workItemClean;
		}

		private async Task<string> Get(string url, Dictionary<string, string> parameters)
		{
			using (var client = GetHttpClient())
			{
				var queryString = ParametersToQueryString(parameters);

				var urlWithQueryString = $"{url}?{queryString}";

				var response = await client.GetAsync(urlWithQueryString);

				response.EnsureSuccessStatusCode();

				var responseBody = await response.Content.ReadAsStringAsync();

				return responseBody;
			}
		}

		private HttpClient GetHttpClient()
		{
			var client = new HttpClient();
			var byteArray = Encoding.UTF8.GetBytes($"{_username}:{_password}");
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			return client;
		}

		private string Post(string url, Dictionary<string, string> parameters, object body)
		{
			var result = string.Empty;
			using (var client = GetHttpClient())
			{
				var queryString = ParametersToQueryString(parameters);

				var urlWithQueryString = $"{url}?{queryString}";

				var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

				var postResult = client.PostAsync(urlWithQueryString, content).Result;

				var json = postResult.Content.ReadAsStringAsync().Result;

				result = json;
			}

			return result;
		}

		private string ParametersToQueryString(Dictionary<string, string> parameters)
		{
			var queryString = string.Empty;

			foreach (var parameter in parameters)
			{
				queryString += $"&{parameter.Key}={parameter.Value}";
			}

			return queryString.Length > 0 ? queryString.Substring(1) : queryString;
		}
	}
}
