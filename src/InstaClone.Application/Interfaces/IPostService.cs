using InstaClone.Core.DTOs;

namespace InstaClone.Application.Interfaces;

public interface IPostService
{
    Task<PostDto?> GetPostByIdAsync(Guid id);
    Task<IEnumerable<PostDto>> GetPostsAsync(int pageNumber, int pageSize);
    Task<PostDto> CreatePostAsync(CreatePostDto createPostDto);
    Task<CommentDto> AddCommentToPostAsync(Guid postId, CreateCommentDto createCommentDto);
    Task AddLikeToPostAsync(Guid postId, Guid userId);
}
