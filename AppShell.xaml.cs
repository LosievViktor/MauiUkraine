namespace MauiControlsShowcase;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Every demo page is already reachable by its absolute route because
		// each one is declared as a top-level FlyoutItem/ShellContent above
		// (e.g. Shell.Current.GoToAsync("//buttons")). That's how the "Jump to
		// a demo" cards on the Home page navigate without needing any extra
		// Routing.RegisterRoute calls here.
	}
}
