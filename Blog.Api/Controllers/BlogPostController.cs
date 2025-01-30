using Blog.Core.Model;
using Blog.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[Route("api/posts")]
public class BlogPostController : ControllerBase
{
    private readonly IBlogPostRepository _blogPostRepository;

    public BlogPostController(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var posts = await _blogPostRepository.GetAllPostsAsync(cancellationToken);

        return Ok(posts);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] BlogPost post, CancellationToken cancellationToken)
    {
        await _blogPostRepository.AddPostAsync(post, cancellationToken);
        return Ok();
    }
}
