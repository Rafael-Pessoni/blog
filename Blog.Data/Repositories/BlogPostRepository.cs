using Blog.Core.Model;
using Blog.Core.Repositories;
using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories;

public class BlogPostRepository : IBlogPostRepository
{
    private readonly BlogContext _context;

    public BlogPostRepository(BlogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BlogPost>> GetAllPostsAsync(CancellationToken cancellationToken)
    {
        return await _context.BlogPosts.Select(x => new BlogPost
        {
            Id = x.Id,
            Title = x.Title,
            CreatedAt = x.CreatedAt,
            CommentsCount = x.Comments.Count()
        }).ToArrayAsync(cancellationToken);
    }

    public async Task AddPostAsync(BlogPost post, CancellationToken cancellationToken)
    {
        await _context.BlogPosts.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
