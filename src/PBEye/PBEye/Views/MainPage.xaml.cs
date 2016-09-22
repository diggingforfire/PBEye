using System;

namespace PBEye.Views
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void Login(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SprintList());
		}
	}
}