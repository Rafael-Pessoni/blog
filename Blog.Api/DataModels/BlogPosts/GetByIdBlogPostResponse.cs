using Blog.Core.Entities;

namespace Blog.Api.DataModels.BlogPosts;

public class GetByIdBlogPostResponse
{
    public GetByIdBlogPostResponse(BlogPost blogPost)
    {
        Id = blogPost.Id;
        Title = blogPost.Title;
        Content = blogPost.Content;
        CreatedAt = blogPost.CreatedAt;
        Comments = blogPost.Comments?.Select(c => new GetByIdBlogPostCommentsResponse(c)) ?? Enumerable.Empty<GetByIdBlogPostCommentsResponse>();
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<GetByIdBlogPostCommentsResponse> Comments { get; set; }
}
