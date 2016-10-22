using PBEye.Constants;
using PBEye.ViewModels;

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