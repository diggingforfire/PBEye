using System;
using System.Globalization;
using Xamarin.Forms;

namespace PBEye.Converters
{
	public class WorkItemTypeToColorConverter : IValueConverter
	{
		private readonly Color _featureColor = Color.FromRgb(0, 147, 146);
		private readonly Color _bugColor = Color.FromRgb(209, 34, 13);

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string workItemType = (string)value;

			switch (workItemType)
			{
				case "Bug":
					return _bugColor;
				case "Product Backlog Item":
					return _featureColor;
				default:
					return _featureColor;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}