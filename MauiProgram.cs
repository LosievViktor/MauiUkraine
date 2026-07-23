using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MauiControlsShowcase.ViewModels;
using MauiControlsShowcase.Views;

namespace MauiControlsShowcase;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
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

		services.AddTransient<LayoutsViewModel>();
		services.AddTransient<LayoutsPage>();

		services.AddTransient<CollectionsViewModel>();
		services.AddTransient<CollectionsPage>();

		services.AddTransient<IndicatorsAndProgressViewModel>();
		services.AddTransient<IndicatorsAndProgressPage>();

		services.AddTransient<GraphicsViewModel>();
		services.AddTransient<GraphicsPage>();

		services.AddTransient<GesturesAndAnimationViewModel>();
		services.AddTransient<GesturesAndAnimationPage>();

		services.AddTransient<StylingAndThemeViewModel>();
		services.AddTransient<StylingAndThemePage>();

		services.AddTransient<AlertsAndDialogsViewModel>();
		services.AddTransient<AlertsAndDialogsPage>();
	}
}
