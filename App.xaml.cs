using MauiControlsShowcase.Resources.Strings;
using MauiControlsShowcase.Services;

namespace MauiControlsShowcase;

public partial class App : Application
{
	public App()
	{
		// Ensure the saved/default culture is applied before any UI is built.
		_ = LocalizationResourceManager.Instance;
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = new Window(new AppShell())
		{
			Title = AppResources.Get("App_Title")
		};

		// Give the desktop targets (Windows / Mac Catalyst) a sensible default
		// size so the showcase looks good the first time it launches.
		window.Width = 1100;
		window.Height = 800;
		window.MinimumWidth = 420;
		window.MinimumHeight = 500;

		return window;
	}
}
