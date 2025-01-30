using Blog.Api.DataModels;
using Blog.Api.DataModels.Comments;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[Route("api/")]
public class CommentsController : ControllerBase
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly ICommentRepository _commentRepository;

    public CommentsController(IBlogPostRepository blogPostRepository, ICommentRepository commentRepository)
    {
        _blogPostRepository = blogPostRepository;
        _commentRepository = commentRepository;
    }

    [HttpPost("posts/{postId}/comments")]
    public async Task<IActionResult> PostAsync(Guid postId, [FromBody] PostCommentRequest model, CancellationToken cancellationToken)
    {
        var post = await _blogPostRepository.GetByIdAsync(postId, cancellationToken);
        if (post == null)
            return NotFound(new DefaultResult<PostCommentResponse>("Blog Post not found"));

        var comment = new Comment(model.Content, post.Id);
        await _commentRepository.AddAsync(comment, cancellationToken);

        var response = new PostCommentResponse(comment);
        return Ok(new DefaultResult<PostCommentResponse>(response));
    }
}
