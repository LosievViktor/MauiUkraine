using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class GraphicsPage : ContentPage
{
	private IDispatcherTimer? _clockTimer;

	public GraphicsPage(GraphicsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		// The clock face only needs to repaint once a second, so a plain
		// IDispatcherTimer ticking Invalidate() is all GraphicsView needs -
		// no animation engine required for a "live" custom drawing.
		if (_clockTimer is null)
		{
			_clockTimer = Dispatcher.CreateTimer();
			_clockTimer.Interval = TimeSpan.FromSeconds(1);
			_clockTimer.Tick += (_, _) => ClockView.Invalidate();
		}

		_clockTimer.Start();
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		_clockTimer?.Stop();
	}
}
