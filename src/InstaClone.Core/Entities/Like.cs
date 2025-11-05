namespace InstaClone.Core.Entities;

/// <summary>
/// Represents a like on a post.
/// </summary>
public class Like
{
    /// <summary>
    /// The unique identifier for the like.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The date and time the like was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The ID of the post that was liked.
    /// </summary>
    public Guid PostId { get; set; }

    /// <summary>
    /// The post that was liked.
    /// </summary>
    public Post? Post { get; set; }

    /// <summary>
    /// The ID of the user who liked the post.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The user who liked the post.
    /// </summary>
    public User? User { get; set; }
}
