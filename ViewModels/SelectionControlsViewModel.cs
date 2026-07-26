using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiControlsShowcase.Resources.Strings;

namespace MauiControlsShowcase.ViewModels;

public partial class SelectionControlsViewModel : BaseViewModel
{
	[ObservableProperty]
	private bool isSwitchOn = true;

	[ObservableProperty]
	private bool isChecked = true;

	[ObservableProperty]
	private string selectedColor = "Green";

	public ObservableCollection<string> Platforms { get; } = new() { "Android", "iOS", "macOS (Mac Catalyst)", "Windows" };

	[ObservableProperty]
	private string selectedPlatform = "Android";

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(ScheduledSummary))]
	private DateTime selectedDate = DateTime.Today;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(ScheduledSummary))]
	private TimeSpan selectedTime = DateTime.Now.TimeOfDay;

	[ObservableProperty]
	private double stepperValue = 3;

	[ObservableProperty]
	private double sliderValue = 0.5;

	public string ScheduledSummary =>
		AppResources.Format("Selection_ScheduledFormat", SelectedDate)
		+ AppResources.Get("Selection_At")
		+ SelectedTime.ToString(@"hh\:mm", AppResources.Culture);

	public SelectionControlsViewModel()
	{
		ApplyLocalization();
	}

	protected override void ApplyLocalization()
	{
		Title = AppResources.Get("Selection_Title");
		OnPropertyChanged(nameof(ScheduledSummary));
	}
}
