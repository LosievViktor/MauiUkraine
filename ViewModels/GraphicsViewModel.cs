using MauiControlsShowcase.Graphics;

namespace MauiControlsShowcase.ViewModels;

public partial class GraphicsViewModel : BaseViewModel
{
	public BarChartDrawable BarChart { get; } = new()
	{
		Data = new (string, double)[]
		{
			("Пн", 12),
			("Вт", 19),
			("Ср", 9),
			("Чт", 24),
			("Пт", 30),
			("Сб", 14),
			("Нд", 6),
		}
	};

	public AnalogClockDrawable Clock { get; } = new();

	public GraphicsViewModel()
	{
		Title = "Графіка та малювання";
	}
}
