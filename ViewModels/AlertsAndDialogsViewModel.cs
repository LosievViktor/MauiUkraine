using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiControlsShowcase.Resources.Strings;
using MauiControlsShowcase.Views;

namespace MauiControlsShowcase.ViewModels;

public partial class AlertsAndDialogsViewModel : BaseViewModel
{
	[ObservableProperty]
	private string lastResult = string.Empty;

	private bool _hasCustomResult;

	public AlertsAndDialogsViewModel()
	{
		ApplyLocalization();
	}

	protected override void ApplyLocalization()
	{
		Title = AppResources.Get("Alerts_Title");
		if (!_hasCustomResult)
		{
			LastResult = AppResources.Get("Alerts_LastResultDefault");
		}
	}

	[RelayCommand]
	private async Task ShowAlertAsync()
	{
		var confirmed = await Shell.Current.DisplayAlertAsync(
			AppResources.Get("Alerts_DeleteTitle"),
			AppResources.Get("Alerts_DeleteMessage"),
			AppResources.Get("Alerts_Delete"),
			AppResources.Get("Alerts_Cancel"));

		LastResult = confirmed
			? AppResources.Get("Alerts_AlertDeleted")
			: AppResources.Get("Alerts_AlertCancelled");
		_hasCustomResult = true;
	}

	[RelayCommand]
	private async Task ShowActionSheetAsync()
	{
		var choice = await Shell.Current.DisplayActionSheetAsync(
			AppResources.Get("Alerts_SortTitle"),
			AppResources.Get("Alerts_Cancel"),
			AppResources.Get("Alerts_DeleteAll"),
			AppResources.Get("Alerts_SortByPriority"),
			AppResources.Get("Alerts_SortByDate"),
			AppResources.Get("Alerts_SortByName"));

		LastResult = AppResources.Format("Alerts_ActionSheetResultFormat", choice);
		_hasCustomResult = true;
	}

	[RelayCommand]
	private async Task ShowPromptAsync()
	{
		var name = await Shell.Current.DisplayPromptAsync(
			AppResources.Get("Alerts_PromptTitle"),
			AppResources.Get("Alerts_PromptMessage"),
			accept: "OK",
			cancel: AppResources.Get("Alerts_Cancel"),
			placeholder: AppResources.Get("Alerts_PromptPlaceholder"));

		LastResult = string.IsNullOrWhiteSpace(name)
			? AppResources.Get("Alerts_PromptCancelled")
			: AppResources.Format("Alerts_PromptHelloFormat", name);
		_hasCustomResult = true;
	}

	[RelayCommand]
	private async Task ShowToastAsync()
	{
		var toast = Toast.Make(AppResources.Get("Alerts_ToastMessage"), ToastDuration.Short, 14);
		await toast.Show(CancellationToken.None);
		LastResult = AppResources.Get("Alerts_ToastShown");
		_hasCustomResult = true;
	}

	[RelayCommand]
	private async Task ShowSnackbarAsync()
	{
		var snackbar = Snackbar.Make(
			AppResources.Get("Alerts_SnackbarMessage"),
			action: () => MainThread.BeginInvokeOnMainThread(() =>
			{
				LastResult = AppResources.Get("Alerts_SnackbarUndone");
				_hasCustomResult = true;
			}),
			actionButtonText: AppResources.Get("Alerts_SnackbarUndo"),
			duration: TimeSpan.FromSeconds(4));

		await snackbar.Show(CancellationToken.None);
		LastResult = AppResources.Get("Alerts_SnackbarShown");
		_hasCustomResult = true;
	}

	[RelayCommand]
	private static async Task OpenModalAsync()
	{
		await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new DemoModalPage()));
	}
}
