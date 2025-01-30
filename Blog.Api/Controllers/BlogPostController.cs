using Blog.Core.Model;
using Blog.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[Route("api/posts")]
public class BlogPostController : ControllerBase
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly ILogger<BlogPostController> _logger;

    public BlogPostController(IBlogPostRepository blogPostRepository, ILogger<BlogPostController> logger)
    {
        _blogPostRepository = blogPostRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all blog posts");

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
