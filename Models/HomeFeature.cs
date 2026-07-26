namespace MauiControlsShowcase.Models;

/// <summary>
/// A home-page menu button that mirrors a Shell flyout item.
/// Each entry exposes a name, description, and AutomationId for UI tests.
/// </summary>
public class HomeFeature
{
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Route { get; set; } = string.Empty;
	public string AutomationId { get; set; } = string.Empty;
}
