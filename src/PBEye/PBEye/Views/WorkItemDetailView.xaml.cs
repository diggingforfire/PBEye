using PBEye.Constants;
using PBEye.Converters;
using PBEye.Service.Models.WorkItem;
using PBEye.ViewModels;
using Xamarin.Forms;

namespace PBEye.Views
{
    public partial class WorkItemDetailView
    {
		private readonly INavigationManager _navigationManager;

	 
		public WorkItemDetailView(INavigationManager navigationManager)
        {
            InitializeComponent();

			_navigationManager = navigationManager;
        }

		protected override void OnAppearing()
		{
			var viewModel = BindingContext as WorkItemDetailViewModel;

			if (viewModel != null)
			{
				_navigationManager.SetNavigationBarColor(viewModel.SelectedWorkItem.Type == "Bug" ? Colors.BugColor : Colors.FeatureColor);
			}

			base.OnAppearing();
		}
    }
}