using CleanArch.Application.Models.Weather;
using CleanArch.Application.Services;
using CleanArch.Infra.Repositories.WeatherStack;
using Serilog;

namespace CleanArch.Infra.Services;

public class WeatherService(IWeatherStackRepository weatherRepository, ILogger logger) : IWeatherService
{
    public async Task<CurrentWeather?> GetWeatherAsync(string location)
    {
        var response = await weatherRepository.FetchWeather(location);
        if (response?.Current is null || response.Location is null || response.Request is null)
        {
            logger
                .ForContext("Location", location)
                .Error("An error has occurred while trying to fetch the weather");

            return default;
        }

        var currentWeather = new CurrentWeather
        {
            Country = response.Location.Country,
            Region = response.Location.Region,
            Temperature = response.Current.Temperature,
            FeelsLike = response.Current.FeelsLike,
            ObservationTime = DateTime.Parse(response.Current.ObservationTime),
            WeatherDescriptions = response.Current.WeatherDescriptions
        };

        logger
            .ForContext("Current weather", currentWeather, true)
            .ForContext("Response", response, true)
            .Information("Current weather was successfully fetched and parsed");

        return currentWeather;
    }
}