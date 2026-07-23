using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiControlsShowcase.ViewModels;

public partial class LayoutsViewModel : BaseViewModel
{
	[ObservableProperty]
	private bool flexIsColumn;

	public ObservableCollection<string> Chips { get; } = new()
	{
		"Grid", "StackLayout", "FlexLayout", "AbsoluteLayout", "ScrollView", "Border", "ContentView", "Frame"
	};

	public LayoutsViewModel()
	{
		Title = "Макети";
	}
}
