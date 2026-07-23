using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiControlsShowcase.Views;

namespace MauiControlsShowcase.ViewModels;

public partial class AlertsAndDialogsViewModel : BaseViewModel
{
	[ObservableProperty]
	private string lastResult = "Спробуйте одну з дій нижче.";

	public AlertsAndDialogsViewModel()
	{
		Title = "Сповіщення та діалоги";
	}

	[RelayCommand]
	private async Task ShowAlertAsync()
	{
		var confirmed = await Shell.Current.DisplayAlertAsync(
			"Видалити елемент?",
			"Це двокнопковий DisplayAlert — класичний блокуючий діалог підтвердження.",
			"Видалити", "Скасувати");

		LastResult = confirmed ? "Alert: користувач обрав «Видалити»." : "Alert: користувач обрав «Скасувати».";
	}

	[RelayCommand]
	private async Task ShowActionSheetAsync()
	{
		var choice = await Shell.Current.DisplayActionSheetAsync(
			"Сортувати завдання за...", "Скасувати", "Видалити все",
			"Пріоритетом", "Датою створення", "Назвою (А-Я)");

		LastResult = $"Action sheet: користувач обрав «{choice}».";
	}

	[RelayCommand]
	private async Task ShowPromptAsync()
	{
		var name = await Shell.Current.DisplayPromptAsync(
			"Як вас звати?",
			"DisplayPromptAsync збирає один рядок вільного тексту.",
			accept: "OK", cancel: "Скасувати", placeholder: "Ада Лавлейс");

		LastResult = string.IsNullOrWhiteSpace(name)
			? "Prompt: скасовано або залишено порожнім."
			: $"Prompt: привіт, {name}!";
	}

	[RelayCommand]
	private async Task ShowToastAsync()
	{
		var toast = Toast.Make("Це Toast від CommunityToolkit.Maui — коротке ненав'язливе сповіщення.", ToastDuration.Short, 14);
		await toast.Show();
		LastResult = "Toast показано (CommunityToolkit.Maui).";
	}

	[RelayCommand]
	private async Task ShowSnackbarAsync()
	{
		var snackbar = Snackbar.Make(
			"Завдання видалено.",
			action: () => LastResult = "Snackbar: користувач натиснув СКАСУВАТИ.",
			actionButtonText: "СКАСУВАТИ",
			duration: TimeSpan.FromSeconds(4));

		await snackbar.Show();
		LastResult = "Snackbar показано — натисніть СКАСУВАТИ, поки не зникне.";
	}

	[RelayCommand]
	private static async Task OpenModalAsync()
	{
		await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new DemoModalPage()));
	}
}
