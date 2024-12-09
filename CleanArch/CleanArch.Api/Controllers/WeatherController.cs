using CleanArch.Application.Services;
using CleanArch.Domain.Entities.Weather;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace CleanArch.Controllers;

[ApiController]
[Route("api")]
public class WeatherController(IWeatherService weatherService, ILogger logger) : ControllerBase
{
    /// <summary>
    /// Returns the current weather for the given location
    /// <remarks>For the sake of repetition the controller returns the domain entity directly, however it could be an
    /// API specific model; say that the consumers actually want the weather description as ints instead of string
    /// that'd call for an api-layer specific model</remarks>
    /// </summary>
    /// <param name="location">The location for the weather to be fetched</param>
    /// <returns>The Weather entity</returns>
    [HttpGet("weathers")]
    public async Task<ActionResult<Weather>> Get([FromQuery] string location)
    {
        try
        {
            var weather = await weatherService.GetWeatherAsync(location);

            if (weather is null)
            {
                return NotFound($"Weather data not found for the specified location: {location}");
            }

            return Ok(weather);
        }
        catch (Exception ex)
        {
            logger
                .ForContext("Location", location)
                .Error(ex, "An error has occured while trying to fetch the weather for the given location");

            return Problem();
        }
    }
}