using CleanArch.Infra.Apis;
using CleanArch.Infra.Models.Responses;
using Prometheus;
using Serilog;
using Serilog.Context;

namespace CleanArch.Infra.Repositories.WeatherStack;

/// <summary>
/// The main entry point for the Weather Stack API
/// </summary>
public class WeatherStackRepository(IWeatherStackApi weatherStackApi, ILogger logger, string apiKey)
    : IWeatherStackRepository
{
    private Counter FailedRequests { get; } = Metrics
        .CreateCounter("weather_stack_failed_requests_total", "Number of failed requests from weather stack");

    private Counter TotalRequests { get; } = Metrics
        .CreateCounter("weather_stack_requests_total", "Number of total requests made to weather stack");

    public async Task<CurrentWeatherResponse?> FetchWeather(string location)
    {
        _ = LogContext.PushProperty("Location", location);

        logger
            .Information("Received request for fetching current weather from Weather Stack");

        var apiResponse = await weatherStackApi.FetchCurrentWeather(location, apiKey);

        TotalRequests.Inc();

        if (!apiResponse.IsSuccessful || apiResponse.Content?.Current is null)
        {
            logger
                .ForContext("Error", apiResponse.Error, true)
                .Error("An error occurred while trying to fetch the current weather from Weather Stack");

            FailedRequests.Inc();

            return default;
        }

        logger.Information("Completed request for fetching current weather from Weather Stack");

        return apiResponse.Content;
    }
}