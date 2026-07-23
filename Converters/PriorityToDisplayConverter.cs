using System.Globalization;
using MauiControlsShowcase.Models;

namespace MauiControlsShowcase.Converters;

public class PriorityToDisplayConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is Priority priority ? priority switch
		{
			Priority.Low => "Низький",
			Priority.High => "Високий",
			_ => "Звичайний"
		} : string.Empty;

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
