using Blog.Core.Entities;
using Blog.Data.Models;

namespace Blog.Test.Blog.Data.Models;

public class CommentModelTest
{
    [Fact]
    public void FromEntity_ReturnsCommentModel()
    {
        // Arrange
        var comment = new Comment(Guid.NewGuid(), "Test Content", DateTime.UtcNow, Guid.NewGuid());

        // Act
        var result = CommentModel.FromEntity(comment);

        // Assert
        Assert.Equal(comment.Id, result.Id);
        Assert.Equal(comment.Content, result.Content);
        Assert.Equal(comment.CreatedAt, result.CreatedAt);
    }

    [Fact]
    public void ToEntity_ReturnsComment()
    {
        // Arrange
        var commentModel = new CommentModel
        {
            Id = Guid.NewGuid(), 
            Content = "Test Content",
            CreatedAt = DateTime.UtcNow,
            BlogPostId = Guid.NewGuid()
        };

        // Act
        var result = commentModel.ToEntity();

        // Assert
        Assert.Equal(commentModel.Id, result.Id);
        Assert.Equal(commentModel.Content, result.Content);
        Assert.Equal(commentModel.CreatedAt, result.CreatedAt);
    }
}
