using Blog.Core.Entities;

namespace Blog.Test.Blog.Core.Entities;

public class CommentTest
{
    [Fact]
    public void Constructor_WhenContentAndBlogPostIdAreValid_SetsProperties()
    {
        // Arrange
        var content = "Content";
        var blogPostId = Guid.NewGuid();

        // Act
        var comment = new Comment(content, blogPostId);

        // Assert
        Assert.Equal(content, comment.Content);
        Assert.Equal(blogPostId, comment.BlogPostId);
    }

    [Fact]
    public void Constructor_WhenContentAndBlogPostIdAreValid_SetsCreatedAt()
    {
        // Arrange
        var content = "Content";
        var blogPostId = Guid.NewGuid();

        // Act
        var comment = new Comment(content, blogPostId);

        // Assert
        Assert.True(comment.CreatedAt <= DateTime.UtcNow);
    }

    [Fact]
    public void Constructor_WhenContentAndBlogPostIdAreValid_SetsId()
    {
        // Arrange
        var content = "Content";
        var blogPostId = Guid.NewGuid();

        // Act
        var comment = new Comment(content, blogPostId);

        // Assert
        Assert.NotEqual(Guid.Empty, comment.Id);
    }
}
