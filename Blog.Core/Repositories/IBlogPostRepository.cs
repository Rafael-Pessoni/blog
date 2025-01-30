
using Blog.Core.Model;

namespace Blog.Core.Repositories;

public interface IBlogPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllPostsAsync(CancellationToken cancellationToken);
    Task AddPostAsync(BlogPost post, CancellationToken cancellationToken);
}
