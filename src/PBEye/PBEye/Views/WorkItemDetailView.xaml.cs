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
			_navigationManager.SetNavigationBarColor(PBEye.Constants.Colors.FeatureColor);

			base.OnAppearing();
		}
    }
}