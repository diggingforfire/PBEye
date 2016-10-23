using PBEye.Controls;
using PBEye.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MultiLineLabel), typeof(MultiLineLabelRenderer))]
namespace PBEye.iOS.Renderers
{
    public class MultiLineLabelRenderer : DefaultLabelRenderer
	{
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            MultiLineLabel multiLineLabel = (MultiLineLabel)Element;

	        if (multiLineLabel != null)
	        {
		        if (multiLineLabel.Lines != -1)
		        {
					Control.Lines = multiLineLabel.Lines;
				}
			}
        }
    }
}