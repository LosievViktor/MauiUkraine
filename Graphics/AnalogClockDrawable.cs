namespace MauiControlsShowcase.Graphics;

/// <summary>
/// A hand-drawn analog clock face - another IDrawable, this one redrawn every
/// second by a code-behind timer to demonstrate GraphicsView.Invalidate() driving
/// smooth, continuous custom rendering.
/// </summary>
public class AnalogClockDrawable : IDrawable
{
	public void Draw(ICanvas canvas, RectF dirtyRect)
	{
		var now = DateTime.Now;
		var center = new PointF(dirtyRect.Center.X, dirtyRect.Center.Y);
		var radius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 2 - 6;

		// Face
		canvas.FillColor = Colors.White;
		canvas.StrokeColor = Color.FromArgb("#512BD4");
		canvas.StrokeSize = 3;
		canvas.FillCircle(center, radius);
		canvas.DrawCircle(center, radius);

		// Hour ticks
		canvas.StrokeColor = Colors.Gray;
		canvas.StrokeSize = 2;
		for (var i = 0; i < 12; i++)
		{
			var angle = i * Math.PI / 6 - Math.PI / 2;
			var outer = PointOnCircle(center, radius - 4, angle);
			var inner = PointOnCircle(center, radius - 12, angle);
			canvas.DrawLine(inner, outer);
		}

		DrawHand(canvas, center, radius * 0.5f, (now.Hour % 12 + now.Minute / 60.0) * Math.PI / 6, 5, Color.FromArgb("#2B0B98"));
		DrawHand(canvas, center, radius * 0.75f, now.Minute * Math.PI / 30, 3.5f, Color.FromArgb("#512BD4"));
		DrawHand(canvas, center, radius * 0.85f, now.Second * Math.PI / 30, 1.5f, Color.FromArgb("#00C2A8"));

		// Center pin
		canvas.FillColor = Color.FromArgb("#2B0B98");
		canvas.FillCircle(center, 5);
	}

	private static void DrawHand(ICanvas canvas, PointF center, float length, double angleFromTwelve, float thickness, Color color)
	{
		var angle = angleFromTwelve - Math.PI / 2; // 0 == 12 o'clock, clockwise
		var end = PointOnCircle(center, length, angle);

		canvas.StrokeColor = color;
		canvas.StrokeSize = thickness;
		canvas.StrokeLineCap = LineCap.Round;
		canvas.DrawLine(center, end);
	}

	private static PointF PointOnCircle(PointF center, float radius, double angleRadians)
		=> new(
			center.X + radius * (float)Math.Cos(angleRadians),
			center.Y + radius * (float)Math.Sin(angleRadians));
}
