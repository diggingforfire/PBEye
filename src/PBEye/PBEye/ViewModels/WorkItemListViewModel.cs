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
        public string SelectedTeam { get; set; }
        public string SelectedSprint { get; set; }

        public WorkItemListViewModel(IVsService vsService)
        {
            _vsService = vsService;
            SelectedTeam = "No team";
            SelectedSprint = "Sprint 74";
        }

        public override void Init(object initData)
        {
            WorkItems = new ObservableCollection<WorkItem>(_vsService.GetWorkItems());
        }

        public Command SelectSprint
        {
            get
            {
                return new Command(async () =>
                {
                    var action = await CoreMethods.DisplayActionSheet("Select a sprint", Constants.ButtonType.Cancel.ToString(), "",
                       "Sprint 71", "Sprint 72", "Sprint 73", "Sprint 74",
                       "Sprint 75", "Sprint 76", "Sprint 77", "Sprint 78",
                       "Sprint 79", "Sprint 80", "Sprint 81", "Sprint 82");

                    if (action != Constants.ButtonType.Cancel.ToString())
                    {
                        SelectedSprint = action;
                    }
                });
            }
        }

        public Command SelectTeam
        {
            get
            {
                return new Command(async () =>
                {
                    var action = await CoreMethods.DisplayActionSheet("Select a team", Constants.ButtonType.Cancel.ToString(), "", 
                        "No team", "ST", "Posco", "Monkeys");

                    if (action != Constants.ButtonType.Cancel.ToString())
                    {
                        SelectedTeam = action;
                    }

                });
            }
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