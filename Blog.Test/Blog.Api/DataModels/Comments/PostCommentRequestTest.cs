using Blog.Api.DataModels.Comments;
using Blog.Api.Helpers;

namespace Blog.Test.Blog.Api.DataModels.Comments;

public class PostCommentRequestTest
{
    [Fact]
    public void IsValid_WhenContentIsNull_ReturnsFalse()
    {
        // Arrange
        var request = new PostCommentRequest
        {
            Content = string.Empty
        };

        var notification = new Notification();

        // Act
        var result = request.IsValid(notification);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValid_WhenContentIsMoreThan1000Characters_ReturnsFalse()
    {
        // Arrange
        var request = new PostCommentRequest
        {
            Content = new string('a', 1001)
        };

        var notification = new Notification();

        // Act
        var result = request.IsValid(notification);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValid_WhenContentIsValid_ReturnsTrue()
    {
        // Arrange
        var request = new PostCommentRequest
        {
            Content = new string('a', 1000)
        };

        var notification = new Notification();

        // Act
        var result = request.IsValid(notification);

        // Assert
        Assert.True(result);
    }
}
