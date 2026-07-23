using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class CollectionsPage : ContentPage
{
	public CollectionsPage(CollectionsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
