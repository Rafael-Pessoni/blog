namespace Blog.Core.Entities;

public class Comment
{
    public Comment(string content, Guid blogPostId)
    {
        Id = Guid.NewGuid();
        Content = content;
        CreatedAt = DateTime.UtcNow;
        BlogPostId = blogPostId;
    }

    public Comment(Guid id, string content, DateTime createdAt, Guid blogPostId)
    {
        Id = id;
        Content = content;
        CreatedAt = createdAt;
        BlogPostId = blogPostId;
    }

    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid BlogPostId { get; set; }
}
