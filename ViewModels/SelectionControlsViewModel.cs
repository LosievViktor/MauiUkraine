using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

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
	private DateTime selectedDate = DateTime.Today;

	[ObservableProperty]
	private TimeSpan selectedTime = DateTime.Now.TimeOfDay;

	[ObservableProperty]
	private double stepperValue = 3;

	[ObservableProperty]
	private double sliderValue = 0.5;

	public SelectionControlsViewModel()
	{
		Title = "Елементи вибору";
	}
}
