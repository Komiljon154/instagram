namespace InstaClone.Core.Entities;

/// <summary>
/// Represents a comment on a post.
/// </summary>
public class Comment
{
    /// <summary>
    /// The unique identifier for the comment.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The content of the comment.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// The date and time the comment was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The ID of the post this comment belongs to.
    /// </summary>
    public Guid PostId { get; set; }

    /// <summary>
    /// The post this comment belongs to.
    /// </summary>
    public Post? Post { get; set; }

    /// <summary>
    /// The ID of the user who made the comment.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The user who made the comment.
    /// </summary>
    public User? User { get; set; }
}
