using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PBEye.Converters
{
	public class StateToIconSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string state = (string)value;

			switch (state.ToLowerInvariant())
			{
				case "done":
				case "ready for release":
					return "state_green.png";
				case "ready for test":
					return "state_red.png";
				case "committed":
					return "state_blue.png";
				case "in progress":
					return "state_light_blue.png";
				case "approved":
				case "new":
					return "state_gray.png";
				case "po check":
					return "state_orange.png";
				case "ready for code review":
					return "state_purple.png";
				default:
					return "state_green.png";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}