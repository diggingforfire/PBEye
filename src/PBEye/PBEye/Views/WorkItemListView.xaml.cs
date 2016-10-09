using Xamarin.Forms;
using FreshMvvm;

namespace PBEye.Views
{
    public partial class WorkItemListView
    {
		private readonly App app;

        public WorkItemListView()
        {
            InitializeComponent();

			NavigationPage.SetHasBackButton(this, false);
			this.app = FreshIOC.Container.Resolve<App>();
        }

		protected override void OnAppearing()
		{
			// TODO: fix properly without resolving and referencing App class
			this.app.SetNavigationBarColor(PBEye.Constants.Colors.NavigationBarColor);

			base.OnAppearing();
		}
    }
}