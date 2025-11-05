using FluentValidation;
using InstaClone.Api.Hubs;
using InstaClone.Application.Interfaces;
using InstaClone.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace InstaClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IValidator<CreatePostDto> _createPostValidator;
    private readonly IHubContext<NotificationHub> _hubContext;

    public PostsController(IPostService postService, IValidator<CreatePostDto> createPostValidator, IHubContext<NotificationHub> hubContext)
    {
        _postService = postService;
        _createPostValidator = createPostValidator;
        _hubContext = hubContext;
    }

    /// <summary>
    /// Gets a paginated list of posts.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of posts per page.</param>
    /// <returns>A list of posts.</returns>
    [HttpGet]
    public async Task<IActionResult> GetPosts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var posts = await _postService.GetPostsAsync(pageNumber, pageSize);
        return Ok(posts);
    }

    /// <summary>
    /// Gets a specific post by its ID.
    /// </summary>
    /// <param name="id">The ID of the post.</param>
    /// <returns>The requested post.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(Guid id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null) return NotFound();
        return Ok(post);
    }

    /// <summary>
    /// Creates a new post.
    /// </summary>
    /// <param name="createPostDto">The data for the new post.</param>
    /// <returns>The newly created post.</returns>
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto)
    {
        var validationResult = await _createPostValidator.ValidateAsync(createPostDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var newPost = await _postService.CreatePostAsync(createPostDto);
        await _hubContext.Clients.All.SendAsync("ReceiveNewPost", newPost);
        return CreatedAtAction(nameof(GetPost), new { id = newPost.Id }, newPost);
    }

    /// <summary>
    /// Adds a comment to a post.
    /// </summary>
    /// <param name="postId">The ID of the post to comment on.</param>
    /// <param name="createCommentDto">The comment data.</param>
    /// <returns>The newly created comment.</returns>
    [HttpPost("{postId}/comments")]
    public async Task<IActionResult> AddComment(Guid postId, [FromBody] CreateCommentDto createCommentDto)
    {
        var newComment = await _postService.AddCommentToPostAsync(postId, createCommentDto);
        await _hubContext.Clients.All.SendAsync("ReceiveNewComment", postId, newComment);
        return Ok(newComment);
    }

    /// <summary>
    /// Likes a post.
    /// </summary>
    /// <param name="postId">The ID of the post to like.</param>
    /// <param name="userId">The ID of the user liking the post.</param>
    [HttpPost("{postId}/like")]
    public async Task<IActionResult> LikePost(Guid postId, [FromQuery] Guid userId)
    {
        await _postService.AddLikeToPostAsync(postId, userId);
        await _hubContext.Clients.All.SendAsync("ReceiveNewLike", postId, userId);
        return NoContent();
    }
}
