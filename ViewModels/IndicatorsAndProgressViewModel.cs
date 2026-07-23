using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiControlsShowcase.ViewModels;

public partial class IndicatorsAndProgressViewModel : BaseViewModel
{
	[ObservableProperty]
	private bool isActivityRunning = true;

	[ObservableProperty]
	private double progress;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(StartUploadCommand))]
	private bool isUploading;

	public IndicatorsAndProgressViewModel()
	{
		Title = "Індикатори та прогрес";
	}

	[RelayCommand(CanExecute = nameof(CanStartUpload))]
	private async Task StartUploadAsync()
	{
		IsUploading = true;
		Progress = 0;

		while (Progress < 1)
		{
			await Task.Delay(120);
			Progress = Math.Min(1, Progress + 0.08);
		}

		await Task.Delay(300);
		IsUploading = false;
	}

	private bool CanStartUpload() => !IsUploading;
}
