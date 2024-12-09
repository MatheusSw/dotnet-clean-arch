using CleanArch.Application.Services;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace CleanArch.Controllers;

[ApiController]
[Route("api")]
public class WeatherController(IWeatherService weatherService, ILogger logger) : ControllerBase
{
    [HttpGet("weathers")]
    public async Task<IActionResult> Get([FromQuery] string location)
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