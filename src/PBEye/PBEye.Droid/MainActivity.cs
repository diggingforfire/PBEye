using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using Android.Widget;
using PBEye.Droid.Controls;
using Xamarin.Forms;

namespace PBEye.Droid
{
	[Activity(Label = "PBEye", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());


		}
	}
}