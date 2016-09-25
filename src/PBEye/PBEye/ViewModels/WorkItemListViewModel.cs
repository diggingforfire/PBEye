using System.Collections.ObjectModel;
using FreshMvvm;
using PBEye.Service;
using PBEye.Service.Models;
using PropertyChanged;

namespace PBEye.ViewModels
{
    [ImplementPropertyChanged]
    public class WorkItemListViewModel : FreshBasePageModel
    {
        private readonly IVsService _vsService;
        public ObservableCollection<WorkItem> WorkItems { get; set; }

        public WorkItemListViewModel(IVsService vsService)
        {
            _vsService = vsService;
        }

        public override void Init(object initData)
        {
            WorkItems = new ObservableCollection<WorkItem>(_vsService.GetWorkItems());
        }
    }
}