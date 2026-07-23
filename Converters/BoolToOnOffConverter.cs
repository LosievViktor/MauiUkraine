using System.Globalization;

namespace MauiControlsShowcase.Converters;

public class BoolToOnOffConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is true ? "увімкнено" : "вимкнено";

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
