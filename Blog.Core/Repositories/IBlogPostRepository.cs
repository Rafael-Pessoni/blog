
using Blog.Core.Entities;

namespace Blog.Core.Repositories;

public interface IBlogPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllAsync(int? offset, int? limit, CancellationToken cancellationToken);
    Task<BlogPost?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(BlogPost post, CancellationToken cancellationToken);
}
