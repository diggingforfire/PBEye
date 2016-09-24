using System.Collections.ObjectModel;
using PBEye.Models;
using Xamarin.Forms;

namespace PBEye.Views
{
	public partial class WorkItemList
	{
		public ObservableCollection<WorkItem> WorkItems { get; }

		public WorkItemList()
		{
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

			InitializeComponent();
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