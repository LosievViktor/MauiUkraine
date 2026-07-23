using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiControlsShowcase.Models;

/// <summary>A single row shown in the CollectionView demo on the Collections page.</summary>
public partial class TodoItem : ObservableObject
{
	[ObservableProperty]
	private bool isDone;

	public string Title { get; set; } = string.Empty;
	public Priority Priority { get; set; } = Priority.Normal;
	public DateTime CreatedOn { get; set; } = DateTime.Now;
}
