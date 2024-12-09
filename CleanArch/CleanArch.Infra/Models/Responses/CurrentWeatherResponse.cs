﻿using System.Text.Json.Serialization;

namespace CleanArch.Infra.Models.Responses;

public class CurrentWeatherResponse
{
    [JsonPropertyName("request")] public Request? Request { get; set; }

    [JsonPropertyName("location")] public Location? Location { get; set; }

    [JsonPropertyName("current")] public Current? Current { get; set; }
}

public class Request
{
    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("query")] public string Query { get; set; }

    [JsonPropertyName("language")] public string Language { get; set; }

    [JsonPropertyName("unit")] public string Unit { get; set; }
}

public class Location
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("country")] public string Country { get; set; }

    [JsonPropertyName("region")] public string Region { get; set; }

    [JsonPropertyName("lat")] public string Latitude { get; set; }

    [JsonPropertyName("lon")] public string Longitude { get; set; }

    [JsonPropertyName("timezone_id")] public string TimezoneId { get; set; }

    [JsonPropertyName("localtime")] public string LocalTime { get; set; }

    [JsonPropertyName("localtime_epoch")] public long LocalTimeEpoch { get; set; }

    [JsonPropertyName("utc_offset")] public string UtcOffset { get; set; }
}

public class Current
{
    [JsonPropertyName("observation_time")] public string ObservationTime { get; set; }

    [JsonPropertyName("temperature")] public int Temperature { get; set; }

    [JsonPropertyName("weather_code")] public int WeatherCode { get; set; }

    [JsonPropertyName("weather_icons")] public List<string> WeatherIcons { get; set; }

    [JsonPropertyName("weather_descriptions")]
    public List<string> WeatherDescriptions { get; set; }

    [JsonPropertyName("wind_speed")] public int WindSpeed { get; set; }

    [JsonPropertyName("wind_degree")] public int WindDegree { get; set; }

    [JsonPropertyName("wind_dir")] public string WindDirection { get; set; }

    [JsonPropertyName("pressure")] public int Pressure { get; set; }

    [JsonPropertyName("precip")] public int Precipitation { get; set; }

    [JsonPropertyName("humidity")] public int Humidity { get; set; }

    [JsonPropertyName("cloudcover")] public int CloudCover { get; set; }

    [JsonPropertyName("feelslike")] public int FeelsLike { get; set; }

    [JsonPropertyName("uv_index")] public int UvIndex { get; set; }

    [JsonPropertyName("visibility")] public int Visibility { get; set; }
}