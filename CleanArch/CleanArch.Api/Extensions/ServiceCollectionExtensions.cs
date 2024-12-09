using Serilog;

namespace CleanArch.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        Log.Logger = logger;

        services.AddSingleton(Log.Logger);

        return services;
    }
}