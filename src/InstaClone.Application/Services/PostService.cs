using AutoMapper;
using InstaClone.Core.DTOs;
using InstaClone.Core.Entities;
using InstaClone.Core.Interfaces;

namespace InstaClone.Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<PostDto?> GetPostByIdAsync(Guid id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        return post == null ? null : _mapper.Map<PostDto>(post);
    }

    public async Task<IEnumerable<PostDto>> GetPostsAsync(int pageNumber, int pageSize)
    {
        var posts = await _postRepository.GetAllAsync(pageNumber, pageSize);
        return _mapper.Map<IEnumerable<PostDto>>(posts);
    }

    public async Task<PostDto> CreatePostAsync(CreatePostDto createPostDto)
    {
        var post = _mapper.Map<Post>(createPostDto);
        await _postRepository.AddAsync(post);
        // Refetch to include user data
        var createdPost = await _postRepository.GetByIdAsync(post.Id);
        return _mapper.Map<PostDto>(createdPost);
    }

    public async Task<CommentDto> AddCommentToPostAsync(Guid postId, CreateCommentDto createCommentDto)
    {
        var comment = _mapper.Map<Comment>(createCommentDto);
        comment.PostId = postId;
        await _postRepository.AddCommentAsync(comment);
        return _mapper.Map<CommentDto>(comment);
    }

    public async Task AddLikeToPostAsync(Guid postId, Guid userId)
    {
        var like = new Like { PostId = postId, UserId = userId };
        await _postRepository.AddLikeAsync(like);
    }
}
