using System.Globalization;
using MauiControlsShowcase.Resources.Strings;

namespace MauiControlsShowcase.Converters;

public class BoolToOnOffConverter : IValueConverter, IMultiValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is true ? AppResources.Get("Selection_On") : AppResources.Get("Selection_Off");

	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
		=> Convert(values.ElementAtOrDefault(0), targetType, parameter, culture);

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
