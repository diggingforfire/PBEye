using Android.Graphics;
using PBEye.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(DefaultLabelRenderer))]
namespace PBEye.Droid.Controls
{
	public class DefaultLabelRenderer : LabelRenderer
	{
		private static readonly Typeface DefaultTypefaceRegular = Typeface.CreateFromAsset(Forms.Context.Assets, "Avenir.otf");
		private static readonly Typeface DefaultTypefaceBold = Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirBold.otf");
 
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Element.FontFamily == null)
			{
				Control.Typeface = Element.FontAttributes == FontAttributes.Bold ? DefaultTypefaceBold : DefaultTypefaceRegular;
			}
		}
	}
}