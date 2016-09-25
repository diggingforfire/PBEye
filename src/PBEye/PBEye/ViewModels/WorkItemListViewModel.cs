using System.Collections.ObjectModel;
using FreshMvvm;
using PBEye.Service;
using PBEye.Service.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace PBEye.ViewModels
{
    [ImplementPropertyChanged]
    public class WorkItemListViewModel : FreshBasePageModel
    {
        private readonly IVsService _vsService;
        public ObservableCollection<WorkItem> WorkItems { get; set; }
        public WorkItem SelectedWorkItem { get; set; }

        public WorkItemListViewModel(IVsService vsService)
        {
            _vsService = vsService;
        }

        public override void Init(object initData)
        {
            WorkItems = new ObservableCollection<WorkItem>(_vsService.GetWorkItems());
        }

        public Command ShowWorkItemDetail
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<WorkItemDetailViewModel>(SelectedWorkItem);
                });
            }
        }
    }
}