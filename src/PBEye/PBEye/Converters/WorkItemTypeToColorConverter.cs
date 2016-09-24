using System;
using System.Globalization;
using PBEye.Models;
using Xamarin.Forms;

namespace PBEye.Converters
{
	public class WorkItemTypeToColorConverter : IValueConverter
	{
		private readonly Color _featureColor = Color.FromRgb(0, 147, 146);
		private readonly Color _bugColor = Color.FromRgb(209, 34, 13);

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			WorkItemType workItemType = (WorkItemType) value;

			switch (workItemType)
			{
				case WorkItemType.Bug:
					return _bugColor;
				case WorkItemType.Feature:
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