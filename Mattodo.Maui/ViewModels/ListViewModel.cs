namespace Mattodo.Maui;

public partial class ListViewModel : BaseViewModel
{
	readonly IDispatcher _dispatcher;
	readonly TodoTaskApiService _todoTaskApiService;
	IReadOnlyList<TodoTask>? _cachedTasks;

	[ObservableProperty]
	bool _isSearchBarEnabled = true,
			_isRefreshing = false;
	
	[ObservableProperty]
	string _searchBarText = string.Empty;
	
	public ListViewModel(IDispatcher dispatcher, TodoTaskApiService todoTaskApiService)
	{
		_dispatcher = dispatcher;
		_todoTaskApiService = todoTaskApiService;
	}
	
	public ObservableCollection<TodoTask> MauiTodoTasks { get; } = new();

	[RelayCommand]
	async Task RefreshAction()
	{
		IsSearchBarEnabled = false;

		try
		{
			_cachedTasks ??= await _todoTaskApiService.GetTodoTasks().ConfigureAwait(false);

			foreach(var task in _cachedTasks ?? Array.Empty<TodoTask>())
			{
				if(!MauiTodoTasks.Any(x => x.Id == task.Id))
				{
					MauiTodoTasks.Add(task);
				}
			}
		}
		finally
		{
			IsSearchBarEnabled = true;
		}
	}
	
	[RelayCommand]
	async Task UserStoppedTyping()
	{
		await RefreshAction();
		/*var searchText = SearchBarText;

		var existingTodoTasks = new List<TodoTask>();
		var originalTodoTasks = _cachedTasks ?? new List<TodoTask>();

		var distinctTodoTasks = existingTodoTasks.Concat(originalTodoTasks).DistinctBy(x => x.Title);

		await _dispatcher.DispatchAsync(MauiTodoTasks.Clear);

		foreach (var TodoTask in distinctTodoTasks.Where(x => x.Title.Contains(searchText)))
		{
			await _dispatcher.DispatchAsync(() => MauiTodoTasks.Add(TodoTask));
		}*/
	}
}