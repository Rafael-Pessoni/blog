using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Blog.Api.Configurations;
public static class OpenTelemetryConfiguration
{
    private static string AppSettingsKey = "AspireDashboard:Url";

    public static IServiceCollection AddOpenTelemetry(this IServiceCollection services, IConfiguration configuration)
    {
        var aspireDashboard = configuration.GetValue<string>(AppSettingsKey);
        if (string.IsNullOrEmpty(aspireDashboard))
            return services;

        services.AddOpenTelemetry()
            .ConfigureResource((resource) => resource.AddService("Blog.Api"))
            .WithMetrics(metrics =>
            {
                metrics
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter(option =>
                    {
                        option.Endpoint = new Uri(aspireDashboard);
                    });
            })
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter(option =>
                    {
                        option.Endpoint = new Uri(aspireDashboard);
                    });
            });

        return services;
    }

    public static ILoggingBuilder AddOpenTelemetry(this ILoggingBuilder logging, IConfiguration configuration)
    {
        var aspireDashboard = configuration.GetValue<string>(AppSettingsKey);
        if (string.IsNullOrEmpty(aspireDashboard))
            return logging;

        logging.AddOpenTelemetry(options =>
        {
            options.AddOtlpExporter(option =>
            {
                option.Endpoint = new Uri(aspireDashboard);
            });
        });

        return logging;
    }
}
