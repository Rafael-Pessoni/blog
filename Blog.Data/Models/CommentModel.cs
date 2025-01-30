using Blog.Core.Entities;

namespace Blog.Data.Models;

public class CommentModel
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid BlogPostId { get; set; }
    public BlogPostModel? BlogPost { get; set; }

    public static CommentModel FromEntity(Comment comment)
    {
        return new CommentModel
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            BlogPostId = comment.BlogPostId
        };
    }

    public Comment ToEntity()
    {
        return new Comment(Id, Content, CreatedAt, BlogPostId);
    }
}
