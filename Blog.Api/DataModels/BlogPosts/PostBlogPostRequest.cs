using Blog.Api.Helpers;

namespace Blog.Api.DataModels.BlogPosts;

public class PostBlogPostRequest
{
    public required string Title { get; set; }
    public required string Content { get; set; }

    public bool IsValid(INotification notification)
    {
        if (string.IsNullOrWhiteSpace(Title))
            notification.Add("Title is required");
        else if (Title.Length > 100)
            notification.Add("Title must be less than 100 characters");

        if (string.IsNullOrWhiteSpace(Content))
            notification.Add("Content is required");

        return !notification.Any();
    }
}
