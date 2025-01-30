using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Model;

public class BlogPost
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    [NotMapped] // TODO: change this to a view model or something like that
    public int? CommentsCount { get; set; }

    public IEnumerable<Comment> Comments { get; set; }
}