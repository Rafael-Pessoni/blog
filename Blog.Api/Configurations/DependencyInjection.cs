using Blog.Core.Repositories;
using Blog.Data.Context;
using Blog.Data.Repositories;

namespace Blog.Api.Configurations;

public static class DependencyInjection
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<BlogContext>();

        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
    }
}