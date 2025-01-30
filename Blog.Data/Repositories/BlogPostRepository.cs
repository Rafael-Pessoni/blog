using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Data.Context;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories;

public class BlogPostRepository : IBlogPostRepository
{
    private readonly BlogContext _context;

    public BlogPostRepository(BlogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync(int? offset, int? limit, CancellationToken cancellationToken)
    {
        var query = _context.BlogPosts.AsQueryable();

        if (offset != null)
            query = query.Skip(offset.Value);

        if (limit != null)
            query = query.Take(limit.Value);

        var blogPost = await query.Select(x => new BlogPostModel
        {
            Id = x.Id,
            Title = x.Title,
            CreatedAt = x.CreatedAt,
            Comments = x.Comments
        }).OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);

        return blogPost.Select(x => x.ToEntity());
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var blogPost = await _context.BlogPosts
            .Select(x => new BlogPostModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedAt = x.CreatedAt,
                Comments = x.Comments
            }).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return blogPost?.ToEntity();
    }

    public async Task AddAsync(BlogPost post, CancellationToken cancellationToken)
    {
        var model = BlogPostModel.FromEntity(post);
        await _context.BlogPosts.AddAsync(model, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
