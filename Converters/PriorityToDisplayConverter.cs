using System.Globalization;
using MauiControlsShowcase.Models;
using MauiControlsShowcase.Resources.Strings;

namespace MauiControlsShowcase.Converters;

public class PriorityToDisplayConverter : IValueConverter, IMultiValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is Priority priority ? priority switch
		{
			Priority.Low => AppResources.Get("Priority_Low"),
			Priority.High => AppResources.Get("Priority_High"),
			_ => AppResources.Get("Priority_Normal")
		} : string.Empty;

	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
		=> Convert(values.ElementAtOrDefault(0), targetType, parameter, culture);

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
