using Blog.Api.Configurations;
using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;

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

app.MapControllers();

app.Run();
