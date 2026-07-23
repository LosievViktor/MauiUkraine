using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class SelectionControlsPage : ContentPage
{
	public SelectionControlsPage(SelectionControlsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
