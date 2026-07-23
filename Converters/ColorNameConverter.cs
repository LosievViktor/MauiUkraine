using System.Globalization;

namespace MauiControlsShowcase.Converters;

public class ColorNameConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value?.ToString() switch
		{
			"Red" => "Червоний",
			"Green" => "Зелений",
			"Blue" => "Синій",
			_ => value?.ToString() ?? string.Empty
		};

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
