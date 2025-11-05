namespace InstaClone.Core.Entities;

/// <summary>
/// Represents a user in the system.
/// </summary>
public class User
{
    /// <summary>
    /// The unique identifier for the user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's unique username.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The user's full name.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// The URL of the user's profile picture.
    /// </summary>
    public string? ProfilePictureUrl { get; set; }

    /// <summary>
    /// The date and time the user account was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Collection of posts created by the user.
    /// </summary>
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
