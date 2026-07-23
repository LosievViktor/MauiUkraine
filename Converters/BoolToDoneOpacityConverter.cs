using System.Globalization;

namespace MauiControlsShowcase.Converters;

/// <summary>Fades a completed to-do's title slightly, alongside the strikethrough decoration.</summary>
public class BoolToDoneOpacityConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is true ? 0.55 : 1.0;

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
