using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiControlsShowcase.Models;

/// <summary>A single row shown in the CollectionView demo on the Collections page.</summary>
public partial class TodoItem : ObservableObject
{
	[ObservableProperty]
	private bool isDone;

	[ObservableProperty]
	private string title = string.Empty;

	public string? TitleResourceKey { get; set; }

	public Priority Priority { get; set; } = Priority.Normal;

	public DateTime CreatedOn { get; set; } = DateTime.Now;
}
