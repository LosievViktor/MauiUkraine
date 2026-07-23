using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class LayoutsPage : ContentPage
{
	public LayoutsPage(LayoutsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
