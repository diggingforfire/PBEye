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
			await Navigation.PushAsync(new WorkItemList());
            Navigation.RemovePage(this);
		}
	}
}