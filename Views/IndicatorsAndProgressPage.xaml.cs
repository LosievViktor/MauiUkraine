using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class IndicatorsAndProgressPage : ContentPage
{
	public IndicatorsAndProgressPage(IndicatorsAndProgressViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
