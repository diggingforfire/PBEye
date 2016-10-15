using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using PBEye.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace PBEye.Droid.Controls
{
	public class CustomNavigationRenderer : NavigationRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
		{
			base.OnElementChanged(e);

			var activity = this.Context as Activity;

			SpannableString s = new SpannableString(activity.ActionBar.Title);
			s.SetSpan(new TypefaceSpan("Avenir.otf"), 0, s.Length(), SpanTypes.ExclusiveExclusive);
			activity.ActionBar.TitleFormatted = s;





		}
	}
}