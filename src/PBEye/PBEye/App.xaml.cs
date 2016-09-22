using PBEye.Views;
using Xamarin.Forms;

namespace PBEye
{
	public partial class App
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new LoginPage());
		}

		protected override void OnStart()
		{

		}

		protected override void OnSleep()
		{

		}

		protected override void OnResume()
		{

		}
	}
}