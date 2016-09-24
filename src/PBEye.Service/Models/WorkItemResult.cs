using System.Collections.Generic;
using Newtonsoft.Json;
using PBEye.Service.Models;

namespace PBEye.Service
{
	public class WorkItemResult
	{
		public int Count { get; set; }

		[JsonProperty("Value")]
		public List<RawWorkItem> WorkItems { get; set; }
	}
}