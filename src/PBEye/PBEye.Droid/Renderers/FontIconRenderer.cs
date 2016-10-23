using Android.Graphics;
using PBEye.Controls;
using PBEye.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FontIcon), typeof(FontIconRenderer))]
namespace PBEye.Droid.Renderers
{
	public class FontIconRenderer : DefaultLabelRenderer
	{
		private static readonly Typeface FontAwesome = Typeface.CreateFromAsset(Forms.Context.Assets, "FontAwesome.otf");

		protected override Typeface GetTypeFace()
		{
			return FontAwesome;
		}
	}
}