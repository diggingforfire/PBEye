using Xamarin.Forms;

namespace PBEye.Controls
{
    public class MultiLineLabel : Label
    {
        private const int DefaultLineSetting = -1;
	    //private const float DefaultLineHeightSetting = -1;

        public static readonly BindableProperty LinesProperty = BindableProperty.Create(nameof(Lines), typeof(int), typeof(MultiLineLabel), DefaultLineSetting);
        public int Lines
        {
            get { return (int)GetValue(LinesProperty); }
            set { SetValue(LinesProperty, value); }
        }


		//public static readonly BindableProperty LineHeightProperty = BindableProperty.Create(nameof(LineHeight), typeof(float), typeof(MultiLineLabel), DefaultLineHeightSetting);
		//public float LineHeight
		//{
		//	get { return (float)GetValue(LineHeightProperty); }
		//	set { SetValue(LineHeightProperty, value); }
		//}
	}
}