using System.Globalization;

namespace MauiControlsShowcase.Converters;

/// <summary>Turns a completed to-do's title strikethrough by returning a TextDecorations value.</summary>
public class BoolToStrikethroughConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is true ? TextDecorations.Strikethrough : TextDecorations.None;

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
