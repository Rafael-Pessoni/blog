
using Blog.Api.Helpers;

namespace Blog.Test.Blog.Api.Helpers.NotificationTest;

public class NotificationTest
{
    [Fact]
    public void Add_AddsMessage()
    {
        // Arrange
        var notification = new Notification();
        var message = "Test message";

        // Act
        notification.Add(message);

        // Assert
        Assert.Contains(message, notification.Get());
    }

    [Fact]
    public void Any_WhenEmpty_ReturnsFalse()
    {
        // Arrange
        var notification = new Notification();

        // Act
        var result = notification.Any();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Any_WhenNotEmpty_ReturnsTrue()
    {
        // Arrange
        var notification = new Notification();
        notification.Add("Test message");

        // Act
        var result = notification.Any();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Get_ReturnsMessages()
    {
        // Arrange
        var notification = new Notification();
        notification.Add("Test message");

        // Act
        var result = notification.Get();

        // Assert
        Assert.Contains("Test message", result);
    }
}
