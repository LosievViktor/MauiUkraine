using System.Globalization;
using MauiControlsShowcase.Resources.Strings;

namespace MauiControlsShowcase.Converters;

public class ColorNameConverter : IValueConverter, IMultiValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value?.ToString() switch
		{
			"Red" => AppResources.Get("Selection_Red"),
			"Green" => AppResources.Get("Selection_Green"),
			"Blue" => AppResources.Get("Selection_Blue"),
			_ => value?.ToString() ?? string.Empty
		};

	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
		=> Convert(values.ElementAtOrDefault(0), targetType, parameter, culture);

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
