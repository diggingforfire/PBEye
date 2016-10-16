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
using PBEye.Service.Models.WorkItem;

namespace PBEye.Service
{
	public class VsService : IVsService
	{
		private string _url;
		private string _username;
		private string _password;

		#region Public API

		public async Task Login(string organization, string username, string password)
		{	
			_url = new Uri($"https://{organization}.visualstudio.com/").ToString();
			_username = username;
			_password = password;

			try
			{
				await GetProjects();
			}
			catch (Exception)
			{
				_url = null;
				_username = null;
				_password = null;

				throw;
			}
		}

		public async Task<IList<Project>> GetProjects()
		{
			return await Get<List<Project>>($"{_url}{EndPoints.ProjectsEndPoint}");
		}

		public async Task<IList<Team>> GetTeams(Project project)
		{
			return await Get<List<Team>>($"{_url}{string.Format(EndPoints.TeamsEndPoint, project.Name)}");
		}

		public async Task<IList<Iteration>> GetIterations(Project project, Team team)
		{
			var iterations = await Get<List<Iteration>>($"{_url}{string.Format(EndPoints.IterationsEndPoint, project.Name, team.Name)}");

			if (iterations != null)
			{
				var currentIterations = await Get<List<Iteration>>($"{_url}{string.Format(EndPoints.CurrentIterationEndPoint, project.Name, team.Name)}");
				iterations.Single(iteration => iteration.Name == currentIterations.Single().Name).IsCurrent = true;
			}

			return iterations;
		}

		public async Task<IList<WorkItem>> GetWorkItems(Project project, Team team, Iteration iteration)
		{
			List<WorkItem> workItems = new List<WorkItem>();

			var workItemIds = await GetWorkItemIds(project, team, iteration);

			const int take = 200;
			int offset = 0;

			while (workItemIds.Count > offset)
			{
				var workItemParameters = new Dictionary<string, string>
				{
					{"ids", string.Join(",", workItemIds.Skip(offset).Take(take))},
					{"$expand", "all"}
				};

				var rawWorkItems =
					await Get<List<RawWorkItem>>($"{_url}{EndPoints.WorkItemsEndPoint}", workItemParameters);

				workItems.AddRange(rawWorkItems.Select(workItem => new WorkItem
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
					Changed = workItem.GetField("System.ChangedDate"),
					Type = workItem.GetField("System.WorkItemType"),
					ImplementOn = workItem.GetField("snappet.SnappetScrum.Implementon"),
					ReproSteps = workItem.GetField("Microsoft.VSTS.TCM.ReproSteps")
				}));

				offset += take;
			}

			return workItems;
		}

		private async Task<List<int>> GetWorkItemIds(Project project, Team team, Iteration iteration)
		{
			var url = $"{_url}{string.Format(EndPoints.WorkItemsQueryEndPoint, project.Name)}";

			var workItemsMeta = await Post<WorkItemsResult>(url, new
			{
				Query =
					"SELECT * " +
					"FROM WorkItems " +
					$"WHERE System.AreaPath = '{project.Name}\\{team.Name}' AND System.IterationPath= '{iteration.Path}'" +
					"AND (System.WorkItemType = \'Bug\' OR System.WorkItemType = \'Product Backlog Item\')" + 
					"AND System.State <> 'Removed'"
			});

			var workItemIds = workItemsMeta.WorkItems.Select(workItemMeta => workItemMeta.Id).ToList();

			return workItemIds;
		}

		#endregion

		#region Helper methods

		private HttpClient GetHttpClient()
		{
			var client = new HttpClient();
			var byteArray = Encoding.UTF8.GetBytes($"{_username}:{_password}");
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

			return client;
		}

		private string ParametersToQueryString(Dictionary<string, string> parameters)
		{
			var queryString = new StringBuilder();

			foreach (var parameter in parameters)
			{
				queryString.Append($"&{parameter.Key}={parameter.Value}");
			}

			return queryString.ToString();
		}

		private string CreateRequestUri(string url, Dictionary<string, string> parameters)
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append(url);

			if (parameters != null)
			{
				stringBuilder.Append(ParametersToQueryString(parameters));
			}

			return stringBuilder.ToString();
		}

		private async Task<T> Post<T>(string url, object content, Dictionary<string, string> parameters = null) where T : class
		{
			return await ExecuteRequest<T>(client => 
				client.PostAsync(CreateRequestUri(url, parameters), new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")), false);
		}

		private async Task<T> Get<T>(string url, Dictionary<string, string> parameters = null) where T : class
		{
			return await ExecuteRequest<T>(client => 
				client.GetAsync(CreateRequestUri(url, parameters)), true);
		}

		private async Task<T> ExecuteRequest<T>(Func<HttpClient, Task<HttpResponseMessage>> getResult, bool responseHasRoot) where T : class
		{
			using (var client = GetHttpClient())
			{
				var response = await getResult(client);

				string json = await response.Content.ReadAsStringAsync();

				response.EnsureSuccessStatusCode();

				if (response.StatusCode == HttpStatusCode.NonAuthoritativeInformation)
				{
					throw new Exception("Non-Authoritative Information");
				}

				if (responseHasRoot)
				{
					dynamic deserializedResult = JsonConvert.DeserializeObject(json);
					return deserializedResult.count > 0 ? deserializedResult.value.ToObject<T>() : default(T);
				}
				else
				{
					return JsonConvert.DeserializeObject<T>(json);
				}
			}
		}

		#endregion
	}
}