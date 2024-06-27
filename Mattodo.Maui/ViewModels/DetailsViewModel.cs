namespace Mattodo.Maui;

public partial class DetailsViewModel : BaseViewModel, IQueryAttributable
{
	public const string LibraryQueryKey = nameof(LibraryQueryKey);
	
	[ObservableProperty]
	string? _libraryTitle, _libraryDetails;
	
	[ObservableProperty]
	bool? _libraryCompleted;
	
	[RelayCommand]
	Task BackButtonTapped() => Shell.Current.GoToAsync("..", true);

	void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
	{
		var library = (TodoTask)query[LibraryQueryKey];

		LibraryTitle = library.Title;
		LibraryCompleted = DateTime.Compare(library.Completed, library.Started) > 0;
		LibraryDetails = library.Details;
	}
}