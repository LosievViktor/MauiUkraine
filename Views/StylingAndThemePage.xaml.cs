using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class StylingAndThemePage : ContentPage
{
	private readonly StylingAndThemeViewModel _viewModel;

	public StylingAndThemePage(StylingAndThemeViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = viewModel;
	}

	private void OnLikeTapped(object? sender, TappedEventArgs e)
	{
		_viewModel.IsLiked = !_viewModel.IsLiked;
		LikeLabel.Text = _viewModel.IsLiked ? "❤️" : "🤍";
		VisualStateManager.GoToState(LikeBorder, _viewModel.IsLiked ? "Liked" : "Normal");
	}
}
