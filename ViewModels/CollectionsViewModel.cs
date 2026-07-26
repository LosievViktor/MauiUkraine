using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiControlsShowcase.Models;
using MauiControlsShowcase.Resources.Strings;

namespace MauiControlsShowcase.ViewModels;

public partial class CollectionsViewModel : BaseViewModel
{
	[ObservableProperty]
	private bool isRefreshing;

	[ObservableProperty]
	private string newTodoText = string.Empty;

	public ObservableCollection<TodoItem> Todos { get; } = new();

	public CollectionsViewModel()
	{
		SeedTodos();
		ApplyLocalization();
	}

	protected override void ApplyLocalization()
	{
		Title = AppResources.Get("Collections_Title");
		foreach (var todo in Todos.Where(t => t.TitleResourceKey is not null))
		{
			todo.Title = AppResources.Get(todo.TitleResourceKey!);
		}
	}

	private void SeedTodos()
	{
		Todos.Add(CreateSeed("Collections_Todo1", Priority.High, isDone: true));
		Todos.Add(CreateSeed("Collections_Todo2", Priority.Normal, isDone: true));
		Todos.Add(CreateSeed("Collections_Todo3", Priority.High, isDone: false));
		Todos.Add(CreateSeed("Collections_Todo4", Priority.Normal, isDone: false));
		Todos.Add(CreateSeed("Collections_Todo5", Priority.Low, isDone: false));
	}

	private static TodoItem CreateSeed(string resourceKey, Priority priority, bool isDone)
		=> new()
		{
			TitleResourceKey = resourceKey,
			Title = AppResources.Get(resourceKey),
			Priority = priority,
			IsDone = isDone
		};

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
		Todos.Add(new TodoItem
		{
			Title = AppResources.Format("Collections_RefreshedItemFormat", DateTime.Now),
			Priority = Priority.Low
		});
		IsRefreshing = false;
	}
}
