using Blog.Core.Entities;

namespace Blog.Api.DataModels.Comments;

public class PostCommentResponse
{
    public PostCommentResponse(Comment comment)
    {
        Id = comment.Id;
        Content = comment.Content;
        CreatedAt = comment.CreatedAt;
        BlogPostId = comment.BlogPostId;
    }

    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid BlogPostId { get; set; }
}
