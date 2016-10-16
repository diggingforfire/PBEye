using System;
using System.Text.RegularExpressions;

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
		public string ReproSteps { get; set; }

		// TODO: don't do this and support html
		public string DescriptionCleaned => Regex.Replace(Description, "<.*?>", String.Empty);
		public string ReproStepsCleaned => Regex.Replace(ReproSteps, "<.*?>", String.Empty);
		public string AcceptanceCriteriaCleaned => Regex.Replace(AcceptanceCriteria, "<.*?>", String.Empty);

		public string DescriptionDisplayValue => !string.IsNullOrEmpty(DescriptionCleaned) ? DescriptionCleaned : "No description available";
		public string ReproStepsDisplayValue => !string.IsNullOrEmpty(ReproStepsCleaned) ? ReproStepsCleaned : "No repro steps available";
		public string AcceptanceCriteriaDisplayValue => !string.IsNullOrEmpty(AcceptanceCriteriaCleaned) ? AcceptanceCriteriaCleaned : "No acceptance criteria available";

		public string WorkItemNumberAndTitle => $"{Id} - {Title}";
		public RawWorkItem Raw { get; set; }
	}
}