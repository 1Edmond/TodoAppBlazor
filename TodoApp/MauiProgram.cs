﻿using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using TodoApp.Data;
using TodoApp.Services;

namespace TodoApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<HttpClient>();
		builder.Services.AddSingleton<ToDoService>();
		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddMudServices();
		return builder.Build();
	}
}
