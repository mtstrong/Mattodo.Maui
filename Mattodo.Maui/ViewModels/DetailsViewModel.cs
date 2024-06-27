namespace Mattodo.Maui;

public partial class DetailsViewModel : BaseViewModel, IQueryAttributable
{
	public const string TodoTaskQueryKey = nameof(TodoTaskQueryKey);
	
	[ObservableProperty]
	string? _TodoTaskTitle, _TodoTaskDetails;
	
	[ObservableProperty]
	bool? _TodoTaskCompleted;
	
	[RelayCommand]
	Task BackButtonTapped() => Shell.Current.GoToAsync("..", true);

	void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
	{
		var TodoTask = (TodoTask)query[TodoTaskQueryKey];

		TodoTaskTitle = TodoTask.Title;
		TodoTaskCompleted = DateTime.Compare(TodoTask.Completed, TodoTask.Started) > 0;
		TodoTaskDetails = TodoTask.Details;
	}
}