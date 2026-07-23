using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiControlsShowcase.ViewModels;

public partial class GesturesAndAnimationViewModel : BaseViewModel
{
	[ObservableProperty]
	private int tapCount;

	[ObservableProperty]
	private int doubleTapCount;

	[ObservableProperty]
	private string pinchStatus = "Стисніть фіолетовий квадрат";

	[ObservableProperty]
	private string panStatus = "Перетягніть бірюзове коло";

	[ObservableProperty]
	private string swipeStatus = "Проведіть картку ліворуч або праворуч";

	public GesturesAndAnimationViewModel()
	{
		Title = "Жести та анімація";
	}
}
