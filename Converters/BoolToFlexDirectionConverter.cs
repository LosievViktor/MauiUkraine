using System.Globalization;
using Microsoft.Maui.Layouts;

namespace MauiControlsShowcase.Converters;

/// <summary>Lets a Switch live-toggle a FlexLayout between row and column direction.</summary>
public class BoolToFlexDirectionConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is true ? FlexDirection.Column : FlexDirection.Row;

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is FlexDirection.Column;
}
