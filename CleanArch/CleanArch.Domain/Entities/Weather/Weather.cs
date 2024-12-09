namespace CleanArch.Domain.Entities.Weather;

public class Weather
{
    public required string Country { get; set; }

    public required string Region { get; set; }

    public required DateTime ObservationTime { get; set; }

    public required int Temperature { get; set; }

    public required List<string> WeatherDescriptions { get; set; }

    public required int FeelsLike { get; set; }
}