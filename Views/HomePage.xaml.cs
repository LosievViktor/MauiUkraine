using System.Collections.Specialized;
using MauiControlsShowcase.Models;
using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _viewModel;

	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
		_viewModel.Features.CollectionChanged += OnFeaturesChanged;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.EnsureMenuReady();
		RebuildMenu();
	}

	private void OnFeaturesChanged(object? sender, NotifyCollectionChangedEventArgs e)
		=> MainThread.BeginInvokeOnMainThread(RebuildMenu);

	private void RebuildMenu()
	{
		MenuHost.Children.Clear();

		foreach (var feature in _viewModel.Features)
		{
			MenuHost.Children.Add(CreateMenuButton(feature));
		}
	}

	private View CreateMenuButton(HomeFeature feature)
	{
		object? captionStyle = null;
		object? cardStyle = null;
		Application.Current?.Resources.TryGetValue("CaptionLabel", out captionStyle);
		Application.Current?.Resources.TryGetValue("CardBorder", out cardStyle);

		var title = new Label
		{
			Text = feature.Title,
			FontAttributes = FontAttributes.Bold,
			FontSize = 16
		};
		var description = new Label
		{
			Text = feature.Description,
			LineBreakMode = LineBreakMode.WordWrap
		};
		if (captionStyle is Style caption)
		{
			description.Style = caption;
		}

		var content = new VerticalStackLayout
		{
			Spacing = 4,
			Children = { title, description }
		};

		var border = new Border { Content = content };
		if (cardStyle is Style card)
		{
			border.Style = card;
		}
		else
		{
			border.Padding = 16;
			border.StrokeThickness = 1;
		}

		border.AutomationId = feature.AutomationId;
		SemanticProperties.SetDescription(border, feature.Title);

		var tap = new TapGestureRecognizer();
		tap.Tapped += async (_, _) => await _viewModel.NavigateCommand.ExecuteAsync(feature);
		border.GestureRecognizers.Add(tap);

		return border;
	}
}
