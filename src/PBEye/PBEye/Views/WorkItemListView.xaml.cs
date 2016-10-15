using Xamarin.Forms;

namespace PBEye.Views
{
    public partial class WorkItemListView
    {
	    private readonly INavigationManager _navigationManager;

        public WorkItemListView(INavigationManager navigationManager)
        {
            InitializeComponent();
	        this._navigationManager = navigationManager;
			NavigationPage.SetHasBackButton(this, false);
        }

		protected override void OnAppearing()
		{
			_navigationManager.SetNavigationBarColor(PBEye.Constants.Colors.NavigationBarColor);

			base.OnAppearing();
		}
    }
}