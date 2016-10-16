using System.Collections.Generic;

namespace PBEye.Service.Models.WorkItem
{
	public class RawWorkItem
	{
		public int Id { get; set; }
		public int Rev { get; set; }
		public Dictionary<string, string> Fields { get; set; }

		public string GetField(string key)
		{
			return Fields.ContainsKey(key) ? Fields[key] : string.Empty;
		}
	}
}