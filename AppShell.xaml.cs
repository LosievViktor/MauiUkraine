using MauiControlsShowcase.Resources.Strings;
using MauiControlsShowcase.Services;

namespace MauiControlsShowcase;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		LocalizationResourceManager.Instance.CultureChanged += OnCultureChanged;
		ApplyFlyoutTitles();
	}

	private void OnCultureChanged(object? sender, EventArgs e)
		=> MainThread.BeginInvokeOnMainThread(ApplyFlyoutTitles);

	private void ApplyFlyoutTitles()
	{
		Title = AppResources.Get("App_Title");
		HomeFlyout.Title = AppResources.Get("Flyout_Home");
		ButtonsFlyout.Title = AppResources.Get("Flyout_Buttons");
		SelectionFlyout.Title = AppResources.Get("Flyout_Selection");
		CollectionsFlyout.Title = AppResources.Get("Flyout_Collections");
		IndicatorsFlyout.Title = AppResources.Get("Flyout_Indicators");
		AlertsFlyout.Title = AppResources.Get("Flyout_Alerts");

		foreach (var item in Items)
		{
			if (item is FlyoutItem flyout)
			{
				foreach (var section in flyout.Items)
				{
					foreach (var content in section.Items)
					{
						content.Title = flyout.Title;
					}
				}
			}
		}

		if (Application.Current?.Windows.FirstOrDefault() is Window window)
		{
			window.Title = AppResources.Get("App_Title");
		}
	}
}
