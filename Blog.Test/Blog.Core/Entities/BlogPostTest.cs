using Blog.Core.Entities;

namespace Blog.Test.Blog.Core.Entities;

public class BlogPostTest
{
    [Fact]
    public void Constructor_WhenTitleAndContentAreValid_SetsProperties()
    {
        // Arrange
        var title = "Title";
        var content = "Content";

        // Act
        var blogPost = new BlogPost(title, content);

        // Assert
        Assert.Equal(title, blogPost.Title);
        Assert.Equal(content, blogPost.Content);
    }

    [Fact]
    public void Constructor_WhenTitleAndContentAreValid_SetsCreatedAt()
    {
        // Arrange
        var title = "Title";
        var content = "Content";

        // Act
        var blogPost = new BlogPost(title, content);

        // Assert
        Assert.True(blogPost.CreatedAt <= DateTime.UtcNow);
    }

    [Fact]
    public void Constructor_WhenTitleAndContentAreValid_SetsId()
    {
        // Arrange
        var title = "Title";
        var content = "Content";

        // Act
        var blogPost = new BlogPost(title, content);

        // Assert
        Assert.NotEqual(Guid.Empty, blogPost.Id);
    }
}
