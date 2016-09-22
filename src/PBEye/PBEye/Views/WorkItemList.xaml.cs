using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBEye.Models;
using Xamarin.Forms;

namespace PBEye.Views
{
	public partial class WorkItemList : ContentPage
	{
		public ObservableCollection<WorkItem> WorkItems { get; set; }

		public WorkItemList()
		{
			WorkItems = new ObservableCollection<WorkItem>
			{
				new WorkItem { Title = "Implement crap", WorkItemNumber = 12903 },
				new WorkItem { Title = "Design crap", WorkItemNumber = 11730 },
				new WorkItem { Title = "R&D crap", WorkItemNumber = 13066 },
				new WorkItem { Title = "More crap", WorkItemNumber = 12954 },
				new WorkItem { Title = "Revert previous crap", WorkItemNumber = 13085 },
				new WorkItem { Title = "Discuss crap", WorkItemNumber = 12952 }
			};

			InitializeComponent();
		}
	}
}