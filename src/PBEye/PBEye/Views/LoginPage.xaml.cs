using System;

namespace PBEye.Views
{
	public partial class LoginPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		private async void Login(object sender, EventArgs e)
		{
			var url = Url.Text;
			var username = Username.Text;
			var password = Password.Text;

			await Navigation.PushAsync(new WorkItemList(url, username, password));
		}
	}
}