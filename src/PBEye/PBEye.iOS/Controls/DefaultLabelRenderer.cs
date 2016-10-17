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

			if (Element != null)
			{
				if (Element.FontFamily == null)
				{
					Control.Font = UIFont.FromName(Element.FontAttributes == FontAttributes.Bold ?
												   "AvenirNextLTPro-Bold" : "AvenirNextLTPro-Regular",
												   Control.Font.PointSize);
				}

				if (Element.Text != null)
				{
					float lineSpacing = 5;

					if (Math.Abs(lineSpacing - (-1)) > 0.05)
					{
						var paragraphStyle = new NSMutableParagraphStyle
						{
							LineSpacing = lineSpacing,
							LineBreakMode = (UILineBreakMode)Enum.Parse(typeof(UILineBreakMode), Element.LineBreakMode.ToString())
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
	}
}