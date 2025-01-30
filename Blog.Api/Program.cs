using Blog.Api.Configurations;
using Blog.Api.Configurations.Middlewares;
using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: move to other file: sql server configuration
builder.Services.AddDbContext<BlogContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// TODO: move to other file: open telemetry configuration
var aspireDashboard = builder.Configuration.GetValue<string>("AspireDashboard:Url");
if (!string.IsNullOrEmpty(aspireDashboard))
{
    builder.Services.AddOpenTelemetry()
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

    builder.Logging.AddOpenTelemetry(logging =>
    {
        logging
            .AddOtlpExporter(option =>
            {
                option.Endpoint = new Uri(aspireDashboard);
            });
    });
}

var app = builder.Build();

// TODO: move to other file: sql server configuration
var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<BlogContext>();
var pendingMigrations = db.Database.GetPendingMigrations();
if (pendingMigrations != null && pendingMigrations.Any())
    db.Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();
