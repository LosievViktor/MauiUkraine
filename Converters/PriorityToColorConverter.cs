using System.Globalization;
using MauiControlsShowcase.Models;

namespace MauiControlsShowcase.Converters;

/// <summary>Maps a <see cref="Priority"/> value to an accent color for the Collections demo.</summary>
public class PriorityToColorConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value is Priority priority
			? priority switch
			{
				Priority.High => Colors.OrangeRed,
				Priority.Normal => Colors.DodgerBlue,
				Priority.Low => Colors.MediumSeaGreen,
				_ => Colors.Gray
			}
			: Colors.Gray;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
