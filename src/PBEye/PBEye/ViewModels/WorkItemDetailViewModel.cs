using FreshMvvm;
using PBEye.Service.Models;
using PropertyChanged;

namespace PBEye.ViewModels
{
    [ImplementPropertyChanged]
    public class WorkItemDetailViewModel : FreshBasePageModel
    {
        public WorkItem SelectedWorkItem { get; set; }

        public WorkItemDetailViewModel()
        {
            
        }

        public override void Init(object initData)
        {
            SelectedWorkItem = (WorkItem)initData;
        }
    }
}