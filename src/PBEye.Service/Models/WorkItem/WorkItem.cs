namespace PBEye.Service.Models.WorkItem
{
	public class WorkItem
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string State { get; set; }
		public string Team { get; set; }
		public string AssignedTo { get; set; }
		public string Sprint { get; set; }
		public string Description { get; set; }
		public string Effort { get; set; }
		public string Changed { get; set; }
		public string AcceptanceCriteria { get; set; }
		public string Type { get; set; }
		public string ImplementOn { get; set; }

	    public string WorkItemNumberAndTitle => $"{Id} - {Title}";
		public RawWorkItem Raw { get; set; }
	}
}