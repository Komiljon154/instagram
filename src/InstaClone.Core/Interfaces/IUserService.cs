using InstaClone.Core.Entities;

namespace InstaClone.Core.Interfaces;

/// <summary>
/// Interface for the user service.
/// </summary>
public interface IUserService
{
    Task<User?> GetUserByUsernameAsync(string username);
}
