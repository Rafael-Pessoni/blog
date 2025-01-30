
using Blog.Core.Entities;

namespace Blog.Core.Repositories;

public interface IBlogPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllAsync(CancellationToken cancellationToken);
    Task<BlogPost?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(BlogPost post, CancellationToken cancellationToken);
}
