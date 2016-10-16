using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FreshMvvm;
using PBEye.Constants;
using PBEye.Service;
using PBEye.Service.Models;
using PBEye.Service.Models.WorkItem;
using PropertyChanged;
using Xamarin.Forms;

namespace PBEye.ViewModels
{
    [ImplementPropertyChanged]
    public class WorkItemListViewModel : FreshBasePageModel
    {
        private readonly IVsService _vsService;

		public ObservableCollection<Project> Projects { get; set; }
		public ObservableCollection<Team> Teams { get; set; }
		public ObservableCollection<Iteration> Iterations { get; set; }
		public ObservableCollection<WorkItem> WorkItems { get; set; }

	    public Project SelectedProject { get; set; }
		public Team SelectedTeam { get; set; }
	    public Iteration SelectedIteration { get; set; }
		public WorkItem SelectedWorkItem { get; set; }

		public bool IsBusy { get; set; }
	    public bool IsIdle => !IsBusy;
	    public bool IsRefreshing { get; set; }
	    public bool HasIterations => Iterations != null && Iterations.Any();

	    public WorkItemListViewModel(IVsService vsService)
        {
            _vsService = vsService;
        }

	    public override void Init(object initData)
	    {
		    Task.Factory.StartNew(async () =>
		    {
				IsBusy = true;

			    await GetAndSetProjects();
			    await GetAndSetTeams();
			    await GetAndSetIterations();
			    await GetAndSetWorkItems();

				IsBusy = false;
			});
	    }

	    private async Task GetAndSetProjects()
	    {
		    var projects = await _vsService.GetProjects();

		    if (projects != null && projects.Any())
		    {
			    Projects = new ObservableCollection<Project>(projects);
			    SelectedProject = Projects.First();
		    }
		    else
		    {
			    Projects = null;
			    SelectedProject = null;
		    }
	    }

		private async Task GetAndSetTeams()
		{
			if (SelectedProject != null)
			{
				var teams = await _vsService.GetTeams(SelectedProject);

				if (teams != null && teams.Any())
				{
					Teams = new ObservableCollection<Team>(teams);
					SelectedTeam = Teams.FirstOrDefault(team => team.Name == "Team ST") ?? Teams.First(); // hehe
				}
				else
				{
					Teams = null;
					SelectedTeam = null;
				}

			}
			else
			{
				Teams = null;
				SelectedTeam = null;
			}
		}

		private async Task GetAndSetIterations()
		{
			if (SelectedProject != null && SelectedTeam != null)
			{
				var iterations = await _vsService.GetIterations(SelectedProject, SelectedTeam);

				if (iterations != null && iterations.Any())
				{
					Iterations = new ObservableCollection<Iteration>(iterations.OrderByDescending(iteration => iteration.Name));
					SelectedIteration = Iterations.Single(iteration => iteration.IsCurrent);
				}
				else
				{
					Iterations = null;
					SelectedIteration = null;
				}
			}
			else
			{
				Iterations = null;
				SelectedIteration = null;
			}
		}

		private async Task GetAndSetWorkItems()
	    {
			if (SelectedProject != null && SelectedTeam != null && SelectedIteration != null)
			{
				WorkItems = new ObservableCollection<WorkItem>(await
					_vsService.GetWorkItems(SelectedProject, SelectedTeam, SelectedIteration));
			}
			else
			{
				WorkItems = null;
			}
	    }

	    public Command Refresh
	    {
		    get
		    {
			    return new Command(async () =>
			    {
				    IsRefreshing = true;
				    await GetAndSetWorkItems();
				    IsRefreshing = false;
			    });
		    }
	    }

		public Command SelectProject
		{
			get
			{
				return new Command(async () =>
				{
					var action = await CoreMethods.DisplayActionSheet(
						"Select a project", 
						ButtonType.Cancel.ToString(), 
						"", 
						Projects.Select(project => project.Name).ToArray());

					if (action != ButtonType.Cancel.ToString() && action != SelectedProject.Name)
					{
						SelectedProject = Projects.First(project => project.Name == action);

						IsBusy = true;
						await GetAndSetTeams();
						await GetAndSetIterations();
						await GetAndSetWorkItems();
						IsBusy = false;

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
					var action = await CoreMethods.DisplayActionSheet(
						"Select a team",
						ButtonType.Cancel.ToString(),
						"",
						Teams.Select(team => team.Name).ToArray());

					if (action != ButtonType.Cancel.ToString() && action != SelectedTeam.Name)
					{
						SelectedTeam = Teams.First(team => team.Name == action);

						IsBusy = true;
						await GetAndSetIterations();
						await GetAndSetWorkItems();
						IsBusy = false;
					}
				});
            }
        }

		public Command SelectIteration
		{
			get
			{
				return new Command(async () =>
				{
					var action = await CoreMethods.DisplayActionSheet(
						"Select an iteration",
						ButtonType.Cancel.ToString(),
						"",
						Iterations.Select(iteration => iteration.Name).ToArray());

					if (action != ButtonType.Cancel.ToString() && action != SelectedIteration.Name)
					{
						SelectedIteration = Iterations.First(iteration => iteration.Name == action);

						IsBusy = true;
						await GetAndSetWorkItems();
						IsBusy = false;
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

	    public Command Logout
	    {
		    get
		    {
			    return new Command(async () =>
			    {
				    if (await CoreMethods.DisplayAlert("Log out", "Are you sure you want to log out?", 
							ButtonType.OK.ToString(),
						    ButtonType.Cancel.ToString()))
				    {
						_vsService.Logout();
						await CoreMethods.PushPageModel<LoginViewModel>();
						CoreMethods.RemoveFromNavigation();
					}
			    });
		    }
	    }
    }
}