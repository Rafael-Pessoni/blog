using Blog.Core.Repositories;
using Blog.Data.Context;

namespace Blog.Data.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly BlogContext _context;

    public CommentRepository(BlogContext context)
    {
        _context = context;
    }
}
