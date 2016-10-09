using FreshMvvm;

namespace PBEye.Views
{
    public partial class WorkItemDetailView
    {
		private readonly App app;

        public WorkItemDetailView()
        {
            InitializeComponent();

			this.app = FreshIOC.Container.Resolve<App>();
        }

		protected override void OnAppearing()
		{
			// TODO: fix properly without resolving and referencing App class
			this.app.SetNavigationBarColor(PBEye.Constants.Colors.FeatureColor);

			base.OnAppearing();
		}
    }
}