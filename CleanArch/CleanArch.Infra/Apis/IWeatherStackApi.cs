using CleanArch.Infra.Models.Responses;
using Refit;

namespace CleanArch.Infra.Apis;

//https://weatherstack.com/documentation
public interface IWeatherStackApi
{
    /// <summary>
    /// Fetches the current weather for the given location 
    /// </summary>
    /// <param name="query">Single or multiple locations</param>
    /// <param name="apiKey">The api key</param>
    /// <returns>The current weather for the given location</returns>
    [Get("/current")]
    Task<IApiResponse<CurrentWeatherResponse>> FetchCurrentWeather([Query] string query, [AliasAs("access_key")] string apiKey);
}