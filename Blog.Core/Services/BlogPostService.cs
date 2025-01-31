using Blog.Core.Entities;
using Blog.Core.Repositories;

namespace Blog.Core.Services;

public class BlogPostService : IBlogPostService
{
    private readonly IBlogPostRepository _blogPostRepository;

    public BlogPostService(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }

    public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost, CancellationToken cancellationToken)
    {
        // do some business logic here (content validation, etc.)

        await _blogPostRepository.AddAsync(blogPost, cancellationToken);

        // do some other business logic here

        return blogPost;
    }
}
