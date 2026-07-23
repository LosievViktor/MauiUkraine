using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class ButtonsAndInputsPage : ContentPage
{
	public ButtonsAndInputsPage(ButtonsAndInputsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
