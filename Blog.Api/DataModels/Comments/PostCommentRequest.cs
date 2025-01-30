using Blog.Api.Helpers;

namespace Blog.Api.DataModels.Comments;

public class PostCommentRequest
{
    public required string Content { get; set; }

    public bool IsValid(INotification notification)
    {
        if (string.IsNullOrWhiteSpace(Content))
            notification.Add("Content is required");
        else if (Content.Length > 1000)
            notification.Add("Content must be less than 1000 characters");

        return !notification.Any();
    }
}
