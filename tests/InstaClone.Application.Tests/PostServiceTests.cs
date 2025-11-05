using AutoMapper;
using InstaClone.Application.Mapping;
using InstaClone.Application.Services;
using InstaClone.Core.DTOs;
using InstaClone.Core.Entities;
using InstaClone.Core.Interfaces;
using Moq;
using Xunit;

namespace InstaClone.Application.Tests;

public class PostServiceTests
{
    private readonly Mock<IPostRepository> _mockPostRepository;
    private readonly IMapper _mapper;
    private readonly PostService _postService;

    public PostServiceTests()
    {
        _mockPostRepository = new Mock<IPostRepository>();
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        _mapper = mappingConfig.CreateMapper();
        _postService = new PostService(_mockPostRepository.Object, _mapper);
    }

    [Fact]
    public async Task GetPostByIdAsync_ShouldReturnPostDto_WhenPostExists()
    {
        // Arrange
        var postId = Guid.NewGuid();
        var post = new Post { Id = postId, Caption = "Test Post", User = new User { Username = "testuser" } };
        _mockPostRepository.Setup(repo => repo.GetByIdAsync(postId)).ReturnsAsync(post);

        // Act
        var result = await _postService.GetPostByIdAsync(postId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(postId, result.Id);
        Assert.Equal("Test Post", result.Caption);
        Assert.Equal("testuser", result.Username);
    }

    [Fact]
    public async Task GetPostByIdAsync_ShouldReturnNull_WhenPostDoesNotExist()
    {
        // Arrange
        _mockPostRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Post)null);

        // Act
        var result = await _postService.GetPostByIdAsync(Guid.NewGuid());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreatePostAsync_ShouldCallAddAsync_AndReturnPostDto()
    {
        // Arrange
        var createDto = new CreatePostDto { Caption = "New Post", UserId = Guid.NewGuid(), ImageUrl = "http://example.com/img.png" };
        var postId = Guid.NewGuid();

        // Mock the AddAsync to do nothing, and GetByIdAsync to return a post to simulate creation
        _mockPostRepository.Setup(repo => repo.AddAsync(It.IsAny<Post>()))
            .Callback<Post>(p => p.Id = postId) // Assign an ID to the post when it's "added"
            .Returns(Task.CompletedTask);

        _mockPostRepository.Setup(repo => repo.GetByIdAsync(postId))
            .ReturnsAsync(new Post { Id = postId, Caption = createDto.Caption, UserId = createDto.UserId, ImageUrl = createDto.ImageUrl, User = new User { Username = "newuser" } });

        // Act
        var result = await _postService.CreatePostAsync(createDto);

        // Assert
        _mockPostRepository.Verify(repo => repo.AddAsync(It.IsAny<Post>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(createDto.Caption, result.Caption);
        Assert.Equal("newuser", result.Username);
    }
}
