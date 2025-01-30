
namespace Blog.Core.Entities;

public class BlogPost
{
    public BlogPost(string title, string content)
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    public BlogPost(Guid id, string title, string content, DateTime createdAt)
    {
        Id = id;
        Title = title;
        Content = content;
        CreatedAt = createdAt;
    }

    public BlogPost(Guid id, string title, string content, DateTime createdAt, IEnumerable<Comment> comments)
    {
        Id = id;
        Title = title;
        Content = content;
        CreatedAt = createdAt;
        Comments = comments;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public IEnumerable<Comment>? Comments { get; set; }
}
