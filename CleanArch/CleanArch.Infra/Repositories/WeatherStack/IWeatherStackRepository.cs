using CleanArch.Infra.Models.Responses;

namespace CleanArch.Infra.Repositories.WeatherStack;

public interface IWeatherStackRepository
{
    public Task<CurrentWeatherResponse?> FetchWeather(string location);
}