using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
