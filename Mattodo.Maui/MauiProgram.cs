using Refit;

namespace Mattodo.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMarkup()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddRefitClient<ITodoTasks>()
			.ConfigureHttpClient(client => client.BaseAddress = new Uri("https://mattodo.tehmatt.com"));

		builder.Services.AddSingleton<App>();
		builder.Services.AddSingleton<AppShell>();
		builder.Services.AddSingleton<TodoTaskApiService>();

		builder.Services.AddTransient<ListPage, ListViewModel>();
		builder.Services.AddTransient<DetailsPage, DetailsViewModel>();

		return builder.Build();
	}
}
