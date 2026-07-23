using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiControlsShowcase.ViewModels;

public partial class ButtonsAndInputsViewModel : BaseViewModel
{
	[ObservableProperty]
	private int counter;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor(nameof(ResetCounterCommand))]
	private bool isCounterBusy;

	[ObservableProperty]
	private string fullName = string.Empty;

	[ObservableProperty]
	private string password = string.Empty;

	[ObservableProperty]
	private string bio = "MAUI дозволяє одній кодовій базі C# + XAML працювати на Android, iOS, macOS і Windows.";

	[ObservableProperty]
	private string searchQuery = string.Empty;

	public ObservableCollection<string> AllTechnologies { get; } = new()
	{
		".NET MAUI", "Xamarin.Forms", "WinUI 3", "Blazor Hybrid", "MAUI Graphics",
		"MAUI Essentials", "CommunityToolkit.Mvvm", "CommunityToolkit.Maui", "Shell Navigation"
	};

	public ObservableCollection<string> SearchResults { get; } = new();

	public ButtonsAndInputsViewModel()
	{
		Title = "Кнопки та поля вводу";
		RunSearch();
	}

	[RelayCommand]
	private void Increment() => Counter++;

	[RelayCommand]
	private async Task ResetCounterAsync()
	{
		IsCounterBusy = true;
		await Task.Delay(400);
		Counter = 0;
		IsCounterBusy = false;
	}

	partial void OnSearchQueryChanged(string value) => RunSearch();

	private void RunSearch()
	{
		SearchResults.Clear();
		var matches = string.IsNullOrWhiteSpace(SearchQuery)
			? AllTechnologies
			: AllTechnologies.Where(t => t.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

		foreach (var match in matches)
		{
			SearchResults.Add(match);
		}
	}
}
