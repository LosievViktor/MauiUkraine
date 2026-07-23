namespace MauiControlsShowcase;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = new Window(new AppShell())
		{
			Title = "Вітрина елементів MAUI"
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
