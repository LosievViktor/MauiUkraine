using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiControlsShowcase.Models;

namespace MauiControlsShowcase.ViewModels;

public partial class CollectionsViewModel : BaseViewModel
{
	[ObservableProperty]
	private bool isRefreshing;

	[ObservableProperty]
	private string newTodoText = string.Empty;

	public ObservableCollection<TodoItem> Todos { get; } = new()
	{
		new TodoItem { Title = "Підключити навігацію Shell flyout", IsDone = true, Priority = Priority.High },
		new TodoItem { Title = "Стилізувати елементи через ResourceDictionary", IsDone = true, Priority = Priority.Normal },
		new TodoItem { Title = "Додати діаграму GraphicsView", IsDone = false, Priority = Priority.High },
		new TodoItem { Title = "Показати видалення свайпом через SwipeView", IsDone = false, Priority = Priority.Normal },
		new TodoItem { Title = "Опублікувати 🚀", IsDone = false, Priority = Priority.Low },
	};

	public ObservableCollection<GalleryPhoto> GalleryPhotos { get; } = new()
	{
		new GalleryPhoto { ImageUrl = "https://picsum.photos/seed/maui1/600/360", Caption = "CarouselView — гортайте між слайдами" },
		new GalleryPhoto { ImageUrl = "https://picsum.photos/seed/maui2/600/360", Caption = "IndicatorView — показує поточну позицію" },
		new GalleryPhoto { ImageUrl = "https://picsum.photos/seed/maui3/600/360", Caption = "Image — завантаження з віддаленого Uri" },
		new GalleryPhoto { ImageUrl = "https://picsum.photos/seed/maui4/600/360", Caption = "Усе пов'язано через прив'язку даних, без code-behind" },
	};

	public CollectionsViewModel()
	{
		Title = "Колекції";
	}

	[RelayCommand]
	private void AddTodo()
	{
		if (string.IsNullOrWhiteSpace(NewTodoText))
		{
			return;
		}

		Todos.Insert(0, new TodoItem { Title = NewTodoText.Trim(), Priority = Priority.Normal });
		NewTodoText = string.Empty;
	}

	[RelayCommand]
	private void DeleteTodo(TodoItem? todo)
	{
		if (todo is not null)
		{
			Todos.Remove(todo);
		}
	}

	[RelayCommand]
	private async Task RefreshAsync()
	{
		IsRefreshing = true;
		await Task.Delay(800);
		Todos.Add(new TodoItem { Title = $"Оновлений елемент о {DateTime.Now:T}", Priority = Priority.Low });
		IsRefreshing = false;
	}
}
