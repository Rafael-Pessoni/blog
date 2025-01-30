namespace Blog.Core.Model;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid BlogPostId { get; set; }
    public BlogPost BlogPost { get; set; }
}
