using MauiControlsShowcase.ViewModels;

namespace MauiControlsShowcase.Views;

public partial class GesturesAndAnimationPage : ContentPage
{
	private readonly GesturesAndAnimationViewModel _viewModel;

	// Pinch-to-zoom state, following the canonical pattern from Microsoft's
	// own MAUI gesture-recognizer samples.
	private double _pinchStartScale = 1;
	private double _pinchCurrentScale = 1;

	// Pan state: remember where the shape was when the last pan ended.
	private double _panX;
	private double _panY;

	public GesturesAndAnimationPage(GesturesAndAnimationViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = viewModel;
	}

	// --- Tap / double-tap -------------------------------------------------

	private async void OnSingleTapped(object? sender, TappedEventArgs e)
	{
		_viewModel.TapCount++;
		await TapTarget.ScaleToAsync(0.85, 80, Easing.CubicOut);
		await TapTarget.ScaleToAsync(1.0, 120, Easing.SpringOut);
	}

	private async void OnDoubleTapped(object? sender, TappedEventArgs e)
	{
		_viewModel.DoubleTapCount++;
		await TapTarget.RotateToAsync(TapTarget.Rotation + 360, 500, Easing.CubicInOut);
	}

	// --- Pinch --------------------------------------------------------------

	private void OnPinchUpdated(object? sender, PinchGestureUpdatedEventArgs e)
	{
		switch (e.Status)
		{
			case GestureStatus.Started:
				_pinchStartScale = PinchTarget.Scale;
				PinchTarget.AnchorX = 0.5;
				PinchTarget.AnchorY = 0.5;
				break;

			case GestureStatus.Running:
				_pinchCurrentScale += (e.Scale - 1) * _pinchStartScale;
				_pinchCurrentScale = Math.Clamp(_pinchCurrentScale, 0.5, 3.0);
				PinchTarget.Scale = _pinchCurrentScale;
				_viewModel.PinchStatus = $"Масштаб: {_pinchCurrentScale:0.00}x";
				break;

			case GestureStatus.Completed:
				_pinchStartScale = _pinchCurrentScale;
				break;
		}
	}

	// --- Pan ------------------------------------------------------------------

	private void OnPanUpdated(object? sender, PanUpdatedEventArgs e)
	{
		switch (e.StatusType)
		{
			case GestureStatus.Running:
				PanTarget.TranslationX = _panX + e.TotalX;
				PanTarget.TranslationY = _panY + e.TotalY;
				_viewModel.PanStatus = $"Зміщення: {PanTarget.TranslationX:0}, {PanTarget.TranslationY:0}";
				break;

			case GestureStatus.Completed:
				_panX = PanTarget.TranslationX;
				_panY = PanTarget.TranslationY;
				break;
		}
	}

	// --- Swipe ------------------------------------------------------------------

	private async void OnSwiped(object? sender, SwipedEventArgs e)
	{
		_viewModel.SwipeStatus = $"Останній свайп: {TranslateSwipeDirection(e.Direction)}";

		var slide = e.Direction == SwipeDirection.Left ? -40 : 40;
		await SwipeTarget.TranslateToAsync(slide, 0, 90, Easing.CubicOut);
		await SwipeTarget.TranslateToAsync(0, 0, 140, Easing.SpringOut);
	}

	// --- Explicit ViewExtensions animations ------------------------------------

	private async void OnFadeClicked(object? sender, EventArgs e)
	{
		await AnimTarget.FadeToAsync(0.15, 250);
		await AnimTarget.FadeToAsync(1, 250);
	}

	private async void OnRotateClicked(object? sender, EventArgs e)
	{
		await AnimTarget.RotateToAsync(AnimTarget.Rotation + 180, 400, Easing.CubicInOut);
	}

	private async void OnScaleClicked(object? sender, EventArgs e)
	{
		await AnimTarget.ScaleToAsync(1.3, 150, Easing.CubicOut);
		await AnimTarget.ScaleToAsync(1.0, 250, Easing.BounceOut);
	}

	private async void OnTranslateClicked(object? sender, EventArgs e)
	{
		await AnimTarget.TranslateToAsync(-80, 0, 180, Easing.CubicInOut);
		await AnimTarget.TranslateToAsync(80, 0, 260, Easing.CubicInOut);
		await AnimTarget.TranslateToAsync(0, 0, 180, Easing.CubicInOut);
	}

	private async void OnCombinedClicked(object? sender, EventArgs e)
	{
		// Multiple ViewExtensions animations composed together: a rotate runs
		// concurrently with a scale-up-then-down, via Task.WhenAll + a local
		// async helper for the sequenced half.
		async Task ScaleUpThenDown()
		{
			await AnimTarget.ScaleToAsync(1.4, 300, Easing.CubicOut);
			await AnimTarget.ScaleToAsync(1.0, 300, Easing.CubicIn);
		}

		await Task.WhenAll(
			AnimTarget.RotateToAsync(AnimTarget.Rotation + 360, 600, Easing.CubicInOut),
			ScaleUpThenDown());
	}

	private static string TranslateSwipeDirection(SwipeDirection direction) => direction switch
	{
		SwipeDirection.Left => "ліворуч",
		SwipeDirection.Right => "праворуч",
		SwipeDirection.Up => "вгору",
		SwipeDirection.Down => "вниз",
		_ => direction.ToString()
	};
}
