namespace MauiControlsShowcase.Graphics;

/// <summary>
/// A tiny, dependency-free bar chart drawn entirely with Microsoft.Maui.Graphics -
/// no charting library required. Demonstrates IDrawable + GraphicsView, MAUI's
/// immediate-mode 2D drawing surface that's shared across every platform.
/// </summary>
public class BarChartDrawable : IDrawable
{
	public IReadOnlyList<(string Label, double Value)> Data { get; set; } = Array.Empty<(string, double)>();

	public void Draw(ICanvas canvas, RectF dirtyRect)
	{
		if (Data.Count == 0)
		{
			return;
		}

		const float padding = 8f;
		const float labelHeight = 20f;
		var chartWidth = dirtyRect.Width - padding * 2;
		var chartHeight = dirtyRect.Height - padding * 2 - labelHeight;
		var maxValue = Math.Max(1.0, Data.Max(d => d.Value));

		var barSlot = chartWidth / Data.Count;
		var barWidth = barSlot * 0.55f;

		canvas.FontSize = 11;

		for (var i = 0; i < Data.Count; i++)
		{
			var (label, value) = Data[i];
			var barHeightRatio = (float)(value / maxValue);
			var barHeight = chartHeight * barHeightRatio;

			var x = padding + i * barSlot + (barSlot - barWidth) / 2;
			var y = padding + (chartHeight - barHeight);

			// Bar
			canvas.FillColor = Color.FromRgba(0x51, 0x2B, 0xD4, (int)(140 + 115.0 * barHeightRatio));
			var barRect = new RectF(x, y, barWidth, barHeight);
			canvas.FillRoundedRectangle(barRect, 6);

			// Value above the bar
			canvas.FontColor = Colors.Gray;
			canvas.DrawString(value.ToString("0"), x + barWidth / 2, y - 14, barWidth, 14,
				HorizontalAlignment.Center, VerticalAlignment.Center);

			// Label below the chart
			canvas.FontColor = Colors.Gray;
			canvas.DrawString(label, x - (barSlot - barWidth) / 2, dirtyRect.Height - labelHeight, barSlot, labelHeight,
				HorizontalAlignment.Center, VerticalAlignment.Center);
		}
	}
}
