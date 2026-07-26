using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MauiControlsShowcase.Services;
using MauiControlsShowcase.ViewModels;
using MauiControlsShowcase.Views;

namespace MauiControlsShowcase;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		// Apply saved language (default English) before any page is created.
		_ = LocalizationResourceManager.Instance;

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit(options =>
			{
				// Required for Toast/Snackbar on Windows (uses AppNotification + COM activation).
				options.SetShouldEnableSnackbarOnWindows(true);
			})
			.ConfigureFonts(fonts =>
			{
				// Add custom fonts here if you drop .ttf files into Resources/Fonts,
				// e.g. fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		RegisterViewsAndViewModels(builder.Services);

		return builder.Build();
	}

	/// <summary>
	/// A tiny, dependency-free "DI container" wiring: every page and view-model
	/// pair used by the showcase is registered here so Shell can resolve them
	/// via constructor injection when the user taps a flyout item.
	/// </summary>
	private static void RegisterViewsAndViewModels(IServiceCollection services)
	{
		services.AddSingleton<HomeViewModel>();
		services.AddSingleton<HomePage>();

		services.AddTransient<ButtonsAndInputsViewModel>();
		services.AddTransient<ButtonsAndInputsPage>();

		services.AddTransient<SelectionControlsViewModel>();
		services.AddTransient<SelectionControlsPage>();

		services.AddTransient<CollectionsViewModel>();
		services.AddTransient<CollectionsPage>();

		services.AddTransient<IndicatorsAndProgressViewModel>();
		services.AddTransient<IndicatorsAndProgressPage>();

		services.AddTransient<AlertsAndDialogsViewModel>();
		services.AddTransient<AlertsAndDialogsPage>();
	}
}
