using CommunityToolkit.Mvvm.ComponentModel;
using MauiControlsShowcase.Services;

namespace MauiControlsShowcase.ViewModels;

/// <summary>
/// Common base for every demo page's view-model. Using CommunityToolkit.Mvvm's
/// ObservableObject gives every derived view-model INotifyPropertyChanged for
/// free via the [ObservableProperty] source generator.
/// </summary>
public abstract partial class BaseViewModel : ObservableObject
{
	[ObservableProperty]
	private string title = string.Empty;

	[ObservableProperty]
	private bool isBusy;

	protected BaseViewModel()
	{
		LocalizationResourceManager.Instance.CultureChanged += OnCultureChanged;
	}

	private void OnCultureChanged(object? sender, EventArgs e)
		=> MainThread.BeginInvokeOnMainThread(ApplyLocalization);

	/// <summary>Refresh titles and any culture-sensitive view-model text.</summary>
	protected virtual void ApplyLocalization()
	{
	}
}
