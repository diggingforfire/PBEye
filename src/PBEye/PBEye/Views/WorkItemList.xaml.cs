using System.Collections.ObjectModel;
using System.Linq;
using PBEye.Service;
using PBEye.Service.Models;
using Xamarin.Forms;

namespace PBEye.Views
{
	public partial class WorkItemList
	{
		public ObservableCollection<WorkItem> WorkItems { get; }

		public WorkItemList()
		{
		    var service = VsServiceFactory.GetService(); // TODO: inject
		    WorkItems = new ObservableCollection<WorkItem>(service.GetWorkItems());

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