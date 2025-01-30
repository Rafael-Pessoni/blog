using Blog.Core.Entities;

namespace Blog.Api.DataModels.BlogPosts;

public class GetByIdBlogPostCommentsResponse
{
    public GetByIdBlogPostCommentsResponse(Comment comment)
    {
        Id = comment.Id;
        Content = comment.Content;
        CreatedAt = comment.CreatedAt;
    }

    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}
