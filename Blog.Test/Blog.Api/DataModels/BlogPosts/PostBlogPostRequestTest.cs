using Blog.Api.DataModels.BlogPosts;
using Blog.Api.Helpers;

namespace Blog.Test.Blog.Api.DataModels.BlogPosts;

public class PostBlogPostRequestTest
{
    [Fact]
    public void IsValid_WhenTitleIsNull_ReturnsFalse()
    {
        // Arrange
        var request = new PostBlogPostRequest
        {
            Title = string.Empty,
            Content = "Content"
        };

        var notification = new Notification();

        // Act
        var result = request.IsValid(notification);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValid_WhenContentIsNull_ReturnsFalse()
    {
        // Arrange
        var request = new PostBlogPostRequest
        {
            Title = "Title",
            Content = string.Empty
        };

        var notification = new Notification();

        // Act
        var result = request.IsValid(notification);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValid_WhenTitleIsMoreThan100Characters_ReturnsFalse()
    {
        // Arrange
        var request = new PostBlogPostRequest
        {
            Title = new string('a', 101),
            Content = "Content"
        };

        var notification = new Notification();

        // Act
        var result = request.IsValid(notification);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValid_WhenBlogPostIsValid_ReturnsTrue()
    {
        // Arrange
        var request = new PostBlogPostRequest
        {
            Title = "Title",
            Content = "Content"
        };

        var notification = new Notification();

        // Act
        var result = request.IsValid(notification);

        // Assert
        Assert.True(result);
    }
}
