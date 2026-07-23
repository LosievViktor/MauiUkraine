using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using MauiControlsShowcase.Models;

namespace MauiControlsShowcase.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
	public ObservableCollection<HomeFeature> Features { get; } = new()
	{
		new HomeFeature { Icon = "🔘", Title = "Кнопки та поля вводу", Description = "Button, ImageButton, Entry, Editor, SearchBar", Route = "buttons" },
		new HomeFeature { Icon = "✅", Title = "Елементи вибору", Description = "Switch, CheckBox, RadioButton, Picker, Date/TimePicker, Stepper, Slider", Route = "selection" },
		new HomeFeature { Icon = "🧱", Title = "Макети", Description = "Grid, StackLayout, FlexLayout, AbsoluteLayout, ScrollView", Route = "layouts" },
		new HomeFeature { Icon = "📋", Title = "Колекції", Description = "CollectionView, CarouselView, IndicatorView, RefreshView", Route = "collections" },
		new HomeFeature { Icon = "⏳", Title = "Індикатори та прогрес", Description = "ActivityIndicator, ProgressBar, Border, Shadow, BoxView", Route = "indicators" },
		new HomeFeature { Icon = "🎨", Title = "Графіка та малювання", Description = "GraphicsView, IDrawable, власні діаграми", Route = "graphics" },
		new HomeFeature { Icon = "👆", Title = "Жести та анімація", Description = "Tap/Pan/Pinch/Swipe та анімації ViewExtensions", Route = "gestures" },
		new HomeFeature { Icon = "🌗", Title = "Стилі та теми", Description = "Styles, словники ресурсів, світла/темна тема, VisualStateManager", Route = "styling" },
		new HomeFeature { Icon = "💬", Title = "Сповіщення та діалоги", Description = "DisplayAlert, ActionSheet, Prompt, Toast, Snackbar, модальні вікна", Route = "alerts" },
	};

	public HomeViewModel()
	{
		Title = "Вітрина елементів MAUI";
	}

	[RelayCommand]
	private async Task NavigateAsync(HomeFeature? feature)
	{
		if (feature is null)
		{
			return;
		}

		await Shell.Current.GoToAsync($"//{feature.Route}");
	}

	[RelayCommand]
	private static async Task OpenRepoInfoAsync()
	{
		await Shell.Current.DisplayAlertAsync(
			"Про цей приклад",
			"Цей застосунок — єдиний проєкт .NET MAUI, створений вручну, щоб показати широту можливостей фреймворку на Android, iOS, macOS і Windows з однієї спільної кодової бази C#/XAML.",
			"Чудово!");
	}
}
