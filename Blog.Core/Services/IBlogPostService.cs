using Blog.Core.Entities;

namespace Blog.Core.Services;

public interface IBlogPostService
{
    Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost, CancellationToken cancellationToken);
}
