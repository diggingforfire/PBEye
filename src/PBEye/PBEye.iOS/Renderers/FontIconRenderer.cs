using PBEye.Controls;
using PBEye.iOS.Renderers;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FontIcon), typeof(FontIconRenderer))]
namespace PBEye.iOS.Renderers
{
	public class FontIconRenderer : DefaultLabelRenderer
	{
		protected override UIFont GetFont()
		{
			return UIFont.FromName("FontAwesome", Control.Font.PointSize);
		}
	}
}