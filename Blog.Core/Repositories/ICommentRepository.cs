using Blog.Core.Entities;

namespace Blog.Core.Repositories;

public interface ICommentRepository
{
    Task AddAsync(Comment comment, CancellationToken cancellationToken);
}
