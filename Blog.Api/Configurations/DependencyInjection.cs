using Blog.Api.Helpers;
using Blog.Core.Repositories;
using Blog.Core.Services;
using Blog.Data.Context;
using Blog.Data.Repositories;

namespace Blog.Api.Configurations;

public static class DependencyInjection
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<INotification, Notification>();

        services.AddScoped<BlogContext>();

        services.AddScoped<IBlogPostService, BlogPostService>();

        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
    }
}
