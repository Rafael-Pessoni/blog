using Blog.Api.DataModels;
using Blog.Api.DataModels.BlogPosts;
using Blog.Api.Helpers;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[Route("api/posts")]
public class BlogPostsController : ControllerBase
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IBlogPostService _blogPostService;
    private readonly INotification _notification;

    public BlogPostsController(IBlogPostRepository blogPostRepository, IBlogPostService blogPostService, INotification notification)
    {
        _blogPostRepository = blogPostRepository;
        _blogPostService = blogPostService;
        _notification = notification;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int? offset, int? limit, CancellationToken cancellationToken)
    {
        var posts = await _blogPostRepository.GetAllAsync(offset, limit, cancellationToken);

        var response = posts.Select(x => new GetAllBlogPostsResponse(x));

        return Ok(new DefaultResult<IEnumerable<GetAllBlogPostsResponse>>(response));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var post = await _blogPostRepository.GetByIdAsync(id, cancellationToken);
        if (post == null)
            return NotFound(new DefaultResult<BlogPost>("Blog Post not found"));

        var response = new GetByIdBlogPostResponse(post);

        return Ok(new DefaultResult<GetByIdBlogPostResponse>(response));
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] PostBlogPostRequest model, CancellationToken cancellationToken)
    {
        if (!model.IsValid(_notification))
            return BadRequest(new DefaultResult<BlogPost>(_notification.Get()));

        var post = new BlogPost(model.Title, model.Content);
        await _blogPostService.CreateBlogPostAsync(post, cancellationToken);

        var response = new PostBlogPostResponse(post);

        return Ok(new DefaultResult<PostBlogPostResponse>(response));
    }
}
