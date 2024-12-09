using CleanArch.Application.Models.Weather;

namespace CleanArch.Application.Services;

public interface IWeatherService
{
    /// <summary>
    /// Fetches the current weather for the given location
    /// </summary>
    /// <param name="location">Location for weather to be fetched</param>
    /// <returns>Information about the current weather at the given location</returns>
    public Task<CurrentWeather?> GetWeatherAsync(string location);
}