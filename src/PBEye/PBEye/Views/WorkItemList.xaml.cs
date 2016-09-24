using System.Collections.ObjectModel;
using System.Linq;
using PBEye.Models;
using PBEye.Service;

namespace PBEye.Views
{
	public partial class WorkItemList
	{
		private string _url;
		private string _username;
		private string _password;
		public ObservableCollection<WorkItem> WorkItems { get; }

		public WorkItemList()
		{
			InitializeComponent();
		}

		public WorkItemList(string subdomain, string username, string password)
		{
			InitializeComponent();

			_url = $"https://{subdomain}.visualstudio.com";
			_username = username;
			_password = password;
			var vsService = new VsService(_url, _username, _password);
			
			var workItem = vsService.GetWorkItem(13458);

			var actualWorkItem = new WorkItem
			{
				Title = workItem.Title,
				WorkItemNumber = int.Parse(workItem.Id)
			};

			WorkItems = new ObservableCollection<WorkItem>
			{
				actualWorkItem
			};

			//var workItems = vsService.GetWorkItems();

			//WorkItems = new ObservableCollection<WorkItem>(workItems.Select(x => new WorkItem
			//{
			//	Title = x.Title,
			//	Type = WorkItemType.Feature,
			//	WorkItemNumber = int.Parse(x.Id)
			//}));

			/*
			WorkItems = new ObservableCollection<WorkItem>
			{
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I want to get Extra Instructions from a preferred Course ", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903, Type = WorkItemType.Feature},
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903, Type = WorkItemType.Feature},
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903, Type = WorkItemType.Feature},
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903, Type = WorkItemType.Feature},
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course, As a teacher, I wa nt to ge t Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },
				new WorkItem { Title = "[Dash3][ExtraInstruction] As a teacher, I want to get Extra Instructions from a preferred Course", WorkItemNumber = 12903 },

			};
			*/
		}

	    private async void NavigateToWorkItemDetail(object sender, SelectedItemChangedEventArgs e)
	    {
	        if (e.SelectedItem != null)
	        {
                await Navigation.PushAsync(new WorkItemDetail());
            }
	    }
	}
}