using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Configurations;

public static class SqlServerConfiguration
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        return services;
    }

    public static WebApplication ExecPendingMigrations(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BlogContext>();

        var migrations = context.Database.GetPendingMigrations();
        if (migrations != null && migrations.Any())
            context.Database.Migrate();

        return app;
    }
}
