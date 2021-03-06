using PBEye.Controls;
using PBEye.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MultiLineLabel), typeof(MultiLineLabelRenderer))]
namespace PBEye.Droid.Renderers
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
					Control.SetSingleLine(false);
					Control.SetLines(multiLineLabel.Lines);
				}

				UpdateLayout();
            }
        }
    }
}