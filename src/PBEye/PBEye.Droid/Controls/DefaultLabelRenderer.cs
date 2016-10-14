using Android.Graphics;
using PBEye.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(DefaultLabelRenderer))]
namespace PBEye.Droid.Controls
{
	public class DefaultLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Element.FontFamily == null)
			{
				Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, "Avenir.otf");
			}
		}
	}
}