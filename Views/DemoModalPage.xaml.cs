namespace MauiControlsShowcase.Views;

public partial class DemoModalPage : ContentPage
{
	public DemoModalPage()
	{
		InitializeComponent();
	}

	private async void OnCloseClicked(object? sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}
