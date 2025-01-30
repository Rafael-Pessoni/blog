using Blog.Core.Entities;

namespace Blog.Data.Models;

public class BlogPostModel
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<CommentModel>? Comments { get; set; }

    public static BlogPostModel FromEntity(BlogPost post)
    {
        return new BlogPostModel
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            CreatedAt = post.CreatedAt
        };
    }

    public BlogPost ToEntity()
    {
        return new BlogPost(Id, Title, Content, CreatedAt, Comments?.Select(x => x.ToEntity()) ?? Enumerable.Empty<Comment>());
    }
}
