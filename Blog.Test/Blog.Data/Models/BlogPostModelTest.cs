using Blog.Core.Entities;
using Blog.Data.Models;

namespace Blog.Test.Blog.Data.Models;

public class BlogPostModelTest
{
    [Fact]
    public void FromEntity_ReturnsBlogPostModel()
    {
        // Arrange
        var post = new BlogPost(Guid.NewGuid(), "Test Title", "Test Content", DateTime.UtcNow, null, null);

        // Act
        var result = BlogPostModel.FromEntity(post);

        // Assert
        Assert.Equal(post.Id, result.Id);
        Assert.Equal(post.Title, result.Title);
        Assert.Equal(post.Content, result.Content);
        Assert.Equal(post.CreatedAt, result.CreatedAt);
    }

    [Fact]
    public void ToEntity_ReturnsBlogPost()
    {
        // Arrange
        var commentModel = new CommentModel
        {
            Id = Guid.NewGuid(),
            Content = "Test Content",
            CreatedAt = DateTime.UtcNow,
            BlogPostId = Guid.NewGuid()
        };
        var comments = new List<Comment> { commentModel.ToEntity() };
        var blogPostModel = new BlogPostModel
        {
            Id = Guid.NewGuid(),
            Title = "Test Title",
            Content = "Test Content",
            CreatedAt = DateTime.UtcNow,
            Comments = new List<CommentModel> { commentModel },
            CommentsCount = comments.Count
        };

        // Act
        var result = blogPostModel.ToEntity();

        // Assert
        Assert.Equal(blogPostModel.Id, result.Id);
        Assert.Equal(blogPostModel.Title, result.Title);
        Assert.Equal(blogPostModel.Content, result.Content);
        Assert.Equal(blogPostModel.CreatedAt, result.CreatedAt);
        Assert.Equal(blogPostModel.CommentsCount, result.CommentsCount);
    }

    [Fact]
    public void ToEntity_ReturnsBlogPost_WithEmptyComments()
    {
        // Arrange
        var blogPostModel = new BlogPostModel
        {
            Id = Guid.NewGuid(),
            Title = "Test Title",
            Content = "Test Content",
            CreatedAt = DateTime.UtcNow,
        };

        // Act
        var result = blogPostModel.ToEntity();

        // Assert
        Assert.Equal(blogPostModel.Id, result.Id);
        Assert.Equal(blogPostModel.Title, result.Title);
        Assert.Equal(blogPostModel.Content, result.Content);
        Assert.Equal(blogPostModel.CreatedAt, result.CreatedAt);
        Assert.Equal(0, result.CommentsCount);
    }
}
