using InstaClone.Core.Entities;

namespace InstaClone.Core.Interfaces;

/// <summary>
/// Interface for the post repository.
/// </summary>
public interface IPostRepository
{
    Task<Post?> GetByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize);
    Task AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Guid id);
    Task AddCommentAsync(Comment comment);
    Task AddLikeAsync(Like like);
}
