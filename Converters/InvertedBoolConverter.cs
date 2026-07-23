using System.Globalization;

namespace MauiControlsShowcase.Converters;

/// <summary>Simple boolean-negation converter - handy for binding IsEnabled to "not busy", etc.</summary>
public class InvertedBoolConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is bool b && !b;

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is bool b && !b;
}
