using Blog.Api.Configurations;
using Blog.Api.Configurations.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer(builder.Configuration);
builder.Services.AddOpenTelemetry(builder.Configuration);
builder.Logging.AddOpenTelemetry(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.ExecPendingMigrations();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();
