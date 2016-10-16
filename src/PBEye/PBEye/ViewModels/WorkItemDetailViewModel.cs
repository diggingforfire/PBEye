using FreshMvvm;
using PBEye.Service.Models;
using PBEye.Service.Models.WorkItem;
using PropertyChanged;
using Xamarin.Forms;

namespace PBEye.ViewModels
{
    [ImplementPropertyChanged]
    public class WorkItemDetailViewModel : FreshBasePageModel
    {
        public WorkItem SelectedWorkItem { get; set; }
	    public string Title { get; set; }

        public override void Init(object initData)
        {
            SelectedWorkItem = (WorkItem)initData;
        }
    }
}
