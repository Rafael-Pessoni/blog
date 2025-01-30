using Blog.Core.Entities;

namespace Blog.Api.DataModels.BlogPosts;

public class GetAllBlogPostsResponse
{
    public GetAllBlogPostsResponse(BlogPost blogPost)
    {
        Id = blogPost.Id;
        Title = blogPost.Title;
        CreatedAt = blogPost.CreatedAt;
        CommentsCount = blogPost?.CommentsCount ?? 0;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CommentsCount { get; set; }
}
