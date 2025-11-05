using Microsoft.AspNetCore.SignalR;

namespace InstaClone.Api.Hubs;

/// <summary>
/// SignalR hub for real-time notifications.
/// </summary>
public class NotificationHub : Hub
{
    /// <summary>
    /// Sends a message to all clients about a new post.
    /// </summary>
    /// <param name="user">The user who posted.</param>
    /// <param name="message">The post content.</param>
    public async Task SendNewPostNotification(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveNewPost", user, message);
    }
}
