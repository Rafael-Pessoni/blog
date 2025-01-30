using Blog.Core.Entities;

namespace Blog.Api.DataModels.BlogPosts;

public class GetAllBlogPostsResponse
{
    public GetAllBlogPostsResponse(BlogPost blogPost)
    {
        Id = blogPost.Id;
        Title = blogPost.Title;
        CreatedAt = blogPost.CreatedAt;
        //TODO: This is not the best way to get the comments count
        CommentsCount = blogPost?.Comments?.Count() ?? 0;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CommentsCount { get; set; }
}
