using System.Globalization;
using MauiControlsShowcase.Resources.Strings;

namespace MauiControlsShowcase.Converters;

/// <summary>
/// Formats a value (or MultiBinding values) with a localized format string whose
/// resource key is supplied via ConverterParameter. Include a binding to
/// LocalizationResourceManager.CultureVersion in MultiBindings so the text
/// refreshes when the language changes.
/// </summary>
public sealed class FormatConverter : IValueConverter, IMultiValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		var format = ResolveFormat(parameter);
		return string.Format(AppResources.Culture ?? culture, format, value ?? string.Empty);
	}

	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		var format = ResolveFormat(parameter);
		// Drop trailing CultureVersion sentinel if present (int).
		var args = values
			.Where(v => v is not int)
			.Select(v => v ?? string.Empty)
			.ToArray();
		return string.Format(AppResources.Culture ?? culture, format, args);
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();

	private static string ResolveFormat(object? parameter)
	{
		if (parameter is string key && !string.IsNullOrWhiteSpace(key))
		{
			return AppResources.Get(key);
		}

		return "{0}";
	}
}
