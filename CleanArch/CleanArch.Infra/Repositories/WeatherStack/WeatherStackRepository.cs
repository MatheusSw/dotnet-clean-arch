using CleanArch.Infra.Apis;
using CleanArch.Infra.Models.Responses;
using Serilog;
using Serilog.Context;

namespace CleanArch.Infra.Repositories.WeatherStack;

/// <summary>
/// The main entry point for the Weather Stack API
/// </summary>
public class WeatherStackRepository(IWeatherStackApi weatherStackApi, ILogger logger, string apiKey) : IWeatherStackRepository
{
    public async Task<CurrentWeatherResponse?> FetchWeather(string location)
    {
        _ = LogContext.PushProperty("Location", location);

        logger
            .Information("Received request for fetching current weather from Weather Stack");

        var apiResponse = await weatherStackApi.FetchCurrentWeather(location, apiKey);
        if (!apiResponse.IsSuccessful || apiResponse.Content?.Current is null)
        {
            logger
                .ForContext("Error", apiResponse.Error, true)
                .Error("An error occurred while trying to fetch the current weather from Weather Stack");
            
            return default;
        }
        
        logger.Information("Completed request for fetching current weather from Weather Stack");

        return apiResponse.Content;
    }
}