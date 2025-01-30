
using Blog.Core.Entities;

namespace Blog.Api.DataModels.BlogPosts;

public class PostBlogPostResponse
{
    public PostBlogPostResponse(BlogPost blogPost)
    {
        Id = blogPost.Id;
        Title = blogPost.Title;
        Content = blogPost.Content;
        CreatedAt = blogPost.CreatedAt;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}
