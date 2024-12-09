using CleanArch.Extensions;
using CleanArch.Infra.Extensions;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json",
        true)
    .Build();

builder.Services.AddSerilog(configuration);

builder.Services.AddWeatherApi()
    .AddWeatherServices();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapMetrics();

app.Run();