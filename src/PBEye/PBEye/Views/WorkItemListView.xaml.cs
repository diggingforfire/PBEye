using Xamarin.Forms;

namespace PBEye.Views
{
    public partial class WorkItemListView
    {
        public WorkItemListView()
        {
            InitializeComponent();

			NavigationPage.SetHasBackButton(this, false);
        }
    }
}