namespace PBEye.Service
{
	internal class EndPoints
	{
		public const string ProjectsEndPoint = "DefaultCollection/_apis/projects?api-version=1.0";
		public const string WorkItemsEndPoint = "DefaultCollection/_apis/wit/workitems?api-version=1.0";
		public const string TeamsEndPoint = "DefaultCollection/_apis/projects/{0}/teams?api-version=1.0";
		public const string WorkItemsQueryEndPoint = "DefaultCollection/{0}/_apis/wit/wiql?api-version=1.0";
		public const string IterationsEndPoint = "DefaultCollection/{0}/{1}/_apis/work/TeamSettings/Iterations?api-version=2.0-preview.1";
		public static readonly string CurrentIterationEndPoint = $"{IterationsEndPoint}&$timeframe=current";
	}
}