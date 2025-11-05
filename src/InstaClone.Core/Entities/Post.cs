namespace InstaClone.Core.Entities;

/// <summary>
/// Represents a post made by a user.
/// </summary>
public class Post
{
    /// <summary>
    /// The unique identifier for the post.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The URL of the image for the post.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// The caption or description of the post.
    /// </summary>
    public string? Caption { get; set; }

    /// <summary>
    /// The date and time the post was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The ID of the user who created the post.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The user who created the post.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Collection of comments on the post.
    /// </summary>
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    /// <summary>
    /// Collection of likes on the post.
    /// </summary>
    public ICollection<Like> Likes { get; set; } = new List<Like>();
}
