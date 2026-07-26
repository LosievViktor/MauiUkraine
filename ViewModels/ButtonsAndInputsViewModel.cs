using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiControlsShowcase.Resources.Strings;

namespace MauiControlsShowcase.ViewModels;

public partial class ButtonsAndInputsViewModel : BaseViewModel
{
	[ObservableProperty]
	private string fullName = string.Empty;

	[ObservableProperty]
	private string password = string.Empty;

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
		ApplyLocalization();
		RunSearch();
	}

	protected override void ApplyLocalization()
	{
		Title = AppResources.Get("Buttons_Title");
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
