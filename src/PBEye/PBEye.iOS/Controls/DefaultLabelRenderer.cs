using PBEye.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(DefaultLabelRenderer))]
namespace PBEye.iOS.Controls
{
	public class DefaultLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Element.FontFamily == null)
			{
				Control.Font = UIFont.FromName("Avenir", Control.Font.PointSize);
			}
		}
	}
}
