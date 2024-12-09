using CleanArch.Application.Services;
using CleanArch.Infra.Apis;
using CleanArch.Infra.Repositories.WeatherStack;
using CleanArch.Infra.Services;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Serilog;

namespace CleanArch.Infra.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherApi(this IServiceCollection services)
    {
        var weatherApiKey = Environment.GetEnvironmentVariable("WEATHER_STACK_API_KEY");

        if (weatherApiKey is null)
        {
            throw new ApplicationException("No WEATHER_STACK_API_KEY environment variable was found");
        }

        services
            .AddRefitClient<IWeatherStackApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.weatherstack.com"));

        return services;
    }

    public static IServiceCollection AddWeatherServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherStackRepository, WeatherStackRepository>(provider => new WeatherStackRepository(
            provider.GetRequiredService<IWeatherStackApi>(),
            provider.GetRequiredService<ILogger>(), Environment.GetEnvironmentVariable("WEATHER_STACK_API_KEY")!));
        
        services.AddScoped<IWeatherService, WeatherService>();

        return services;
    }
}