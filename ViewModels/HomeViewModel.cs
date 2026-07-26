using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiControlsShowcase.Models;
using MauiControlsShowcase.Resources.Strings;
using MauiControlsShowcase.Services;

namespace MauiControlsShowcase.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
	public ObservableCollection<HomeFeature> Features { get; } = new();

	[ObservableProperty]
	private string selectedLanguageCode = LocalizationResourceManager.DefaultLanguage;

	private bool _suppressLanguageChange;

	public HomeViewModel()
	{
		_suppressLanguageChange = true;
		SelectedLanguageCode = LocalizationResourceManager.Instance.CurrentLanguage;
		_suppressLanguageChange = false;

		ApplyLocalization();
	}

	protected override void ApplyLocalization()
	{
		Title = AppResources.Get("Flyout_Home");
		RebuildFeatures();
	}

	partial void OnSelectedLanguageCodeChanged(string value)
	{
		if (_suppressLanguageChange || string.IsNullOrWhiteSpace(value))
		{
			return;
		}

		LocalizationResourceManager.Instance.SetCulture(value);
	}

	private void RebuildFeatures()
	{
		Features.Clear();
		Features.Add(new HomeFeature { Title = AppResources.Get("Home_Feature_Buttons_Title"), Description = AppResources.Get("Home_Feature_Buttons_Desc"), Route = "buttons" });
		Features.Add(new HomeFeature { Title = AppResources.Get("Home_Feature_Selection_Title"), Description = AppResources.Get("Home_Feature_Selection_Desc"), Route = "selection" });
		Features.Add(new HomeFeature { Title = AppResources.Get("Home_Feature_Collections_Title"), Description = AppResources.Get("Home_Feature_Collections_Desc"), Route = "collections" });
		Features.Add(new HomeFeature { Title = AppResources.Get("Home_Feature_Indicators_Title"), Description = AppResources.Get("Home_Feature_Indicators_Desc"), Route = "indicators" });
		Features.Add(new HomeFeature { Title = AppResources.Get("Home_Feature_Alerts_Title"), Description = AppResources.Get("Home_Feature_Alerts_Desc"), Route = "alerts" });
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
			AppResources.Get("Home_AboutAlertTitle"),
			AppResources.Get("Home_AboutAlertMessage"),
			AppResources.Get("Home_AboutAlertOk"));
	}
}
