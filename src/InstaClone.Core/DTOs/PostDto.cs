namespace InstaClone.Core.DTOs;

/// <summary>
/// Data transfer object for a Post.
/// </summary>
public class PostDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string? Caption { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? UserProfilePictureUrl { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public List<CommentDto> Comments { get; set; } = new();
}

/// <summary>
/// Data transfer object for creating a new Post.
/// </summary>
public class CreatePostDto
{
    public string ImageUrl { get; set; } = string.Empty;
    public string? Caption { get; set; }
    public Guid UserId { get; set; }
}

/// <summary>
/// Data transfer object for a Comment.
/// </summary>
public class CommentDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Username { get; set; } = string.Empty;
}

/// <summary>
/// Data transfer object for creating a new Comment.
/// </summary>
public class CreateCommentDto
{
    public string Content { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
