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

		public override void Init(object initData)
        {
            SelectedWorkItem = (WorkItem)initData;
        }
    }
}