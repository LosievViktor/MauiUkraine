using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiControlsShowcase.ViewModels;

public partial class StylingAndThemeViewModel : BaseViewModel
{
	[ObservableProperty]
	private string selectedTheme = "System";

	[ObservableProperty]
	private bool isLiked;

	public string[] Themes { get; } = { "System", "Light", "Dark" };

	public StylingAndThemeViewModel()
	{
		Title = "Стилі та теми";
		SelectedTheme = Application.Current?.UserAppTheme switch
		{
			AppTheme.Light => "Light",
			AppTheme.Dark => "Dark",
			_ => "System"
		};
	}

	partial void OnSelectedThemeChanged(string value)
	{
		if (Application.Current is null)
		{
			return;
		}

		Application.Current.UserAppTheme = value switch
		{
			"Light" => AppTheme.Light,
			"Dark" => AppTheme.Dark,
			_ => AppTheme.Unspecified
		};
	}

	[RelayCommand]
	private void CycleAccentColor()
	{
		if (Application.Current is null)
		{
			return;
		}

		var palette = new[] { Colors.HotPink, Colors.DarkOrange, Colors.MediumSeaGreen, Colors.DodgerBlue, Color.FromArgb("#00C2A8") };
		var current = (Color)Application.Current.Resources["Accent"];
		var nextIndex = (Array.IndexOf(palette, current) + 1) % palette.Length;

		Application.Current.Resources["Accent"] = palette[nextIndex];
	}

	[RelayCommand]
	private void ToggleLiked() => IsLiked = !IsLiked;
}
