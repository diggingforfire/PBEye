namespace PBEye.Models
{
	public class WorkItem
	{
		public string Title { get; set; }
		public int WorkItemNumber { get; set; }
		public WorkItemType Type { get; set; }
		public string WorkItemNumberAndTitle => $"{WorkItemNumber} - {Title}";
	}
}