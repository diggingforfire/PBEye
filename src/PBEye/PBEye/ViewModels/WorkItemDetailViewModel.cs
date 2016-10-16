using FreshMvvm;
using PBEye.Service.Models.WorkItem;
using PropertyChanged;

namespace PBEye.ViewModels
{
    [ImplementPropertyChanged]
    public class WorkItemDetailViewModel : FreshBasePageModel
    {
        public WorkItem SelectedWorkItem { get; set; }
	    public string Title { get; set; }
	    public bool IsBug => SelectedWorkItem.Type == "Bug";
	    public bool IsFeature => !IsBug;

	    public float DescriptionOpacity => SelectedWorkItem.Type == "Bug" ? 0 : 1;
		public float ReproStepsOpacity => SelectedWorkItem.Type == "Bug" ? 1 : 0;

		public override void Init(object initData)
        {
            SelectedWorkItem = (WorkItem)initData;
        }
    }
}