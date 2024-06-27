namespace Mattodo.Maui;

public partial class ListViewModel : BaseViewModel
{
	readonly IDispatcher _dispatcher;
	
	[ObservableProperty]
	bool _isSearchBarEnabled = true,
			_isRefreshing = false;
	
	[ObservableProperty]
	string _searchBarText = string.Empty;
	
	public ListViewModel(IDispatcher dispatcher)
	{
		_dispatcher = dispatcher;
	}
	
	public ObservableCollection<TodoTask> MauiLibraries { get; } = new(CreateLibraries());
	
	static List<TodoTask> CreateLibraries() => new()
	{
		new()
		{
			Title = "Microsoft.Maui",
			Details =
				".NET Multi-platform App UI is a framework for building native device applications spanning mobile, tablet, and desktop"
		},
		new()
		{
			Title = "CommunityToolkit.Maui",
			Details =
				"The .NET MAUI Community Toolkit is a community-created library that contains .NET MAUI Extensions, Advanced UI/UX Controls, and Behaviors to help make your life as a .NET MAUI developer easier"
		},
		new()
		{
			Title = "CommunityToolkit.Maui.Markup",
			Details =
				"The .NET MAUI Markup Community Toolkit is a community-created library that contains Fluent C# Extension Methods to easily create your User Interface in C#"		},
		new()
		{
			Title = "CommunityToolkit.MVVM",
			Details =
				"This package includes a .NET MVVM library with helpers such as ObservableObject, ObservableRecipient, ObservableValidator, RelayCommand, AsyncRelayCommand, WeakReferenceMessenger, StrongReferenceMessenger and IoC"		},
		new()
		{
			Title = "Sentry.Maui",
			Details =
				"Bad software is everywhere, and we're tired of it. Sentry is on a mission to help developers write better software faster, so we can get back to enjoying technology",		},
		new()
		{
			Title = "Esri.ArcGISRuntime.Maui",
			Details =
				"Contains APIs and UI controls for building native mobile and desktop apps with the .NET Multi-platform App UI (.NET MAUI) cross-platform framework"		},
		new()
		{
			Title = "Syncfusion.Maui.Core",
			Details =
				"This package contains .NET MAUI Avatar View, .NET MAUI Badge View, .NET MAUI Busy Indicator, .NET MAUI Effects View, and .NET MAUI Text Input Layout components for .NET MAUI application"
		},
		new()
		{
			Title = "DotNet.Meteor",
			Details = "A VSCode extension that can run and debug .NET apps (based on Clancey VSCode.Comet)"
		}
	};

	[RelayCommand]
	async Task RefreshAction()
	{
		IsSearchBarEnabled = false;

		try
		{
			await Task.Delay(TimeSpan.FromSeconds(2));

			MauiLibraries.Add(new()
			{
				Title = "Sharpnado.Tabs",
				Details =
					"Pure MAUI and Xamarin.Forms Tabs, including fixed tabs, scrollable tabs, bottom tabs, badge, segmented control, custom tabs, button tabs, bendable tabs"			});

			IsRefreshing = false;
		}
		finally
		{
			IsSearchBarEnabled = true;
		}
	}
	
	[RelayCommand]
	async Task UserStoppedTyping()
	{
		var searchText = SearchBarText;

		var existingLibraries = new List<TodoTask>(MauiLibraries);
		var originalLibraries = CreateLibraries();

		var distinctLibraries = existingLibraries.Concat(originalLibraries).DistinctBy(x => x.Title);

		await _dispatcher.DispatchAsync(MauiLibraries.Clear);

		foreach (var library in distinctLibraries.Where(x => x.Title.Contains(searchText)))
		{
			await _dispatcher.DispatchAsync(() => MauiLibraries.Add(library));
		}
	}
}