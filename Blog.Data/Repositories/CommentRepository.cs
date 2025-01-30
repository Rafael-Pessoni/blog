using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Data.Context;
using Blog.Data.Models;

namespace Blog.Data.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly BlogContext _context;

    public CommentRepository(BlogContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Comment comment, CancellationToken cancellationToken)
    {
        var model  = CommentModel.FromEntity(comment);
        await _context.Comments.AddAsync(model, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
