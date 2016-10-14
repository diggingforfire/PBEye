using System;
using Foundation;
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
				Control.Font = UIFont.FromName(Element.FontAttributes == FontAttributes.Bold ? "AvenirBold" : "Avenir", Control.Font.PointSize);
			}

			float lineHeight = 1.2f;

			if (Math.Abs(lineHeight - (-1)) > 0.05)
			{
				var paragraphStyle = new NSMutableParagraphStyle
				{
					LineSpacing = lineHeight
				};

				var text = new NSMutableAttributedString(Element.Text);
				var style = UIStringAttributeKey.ParagraphStyle;
				var range = new NSRange(0, text.Length);

				text.AddAttribute(style, paragraphStyle, range);

				Control.AttributedText = text;
			}
		}
	}
}