using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class AlertsAndDialogsPage : ContentPage
{
	public AlertsAndDialogsPage(AlertsAndDialogsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
