using Grpc.Core;

namespace InstaClone.Grpc.Services;

public class UserService : User.UserBase
{
    private readonly ILogger<UserService> _logger;
    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public override Task<GetUserResponse> GetUserProfile(GetUserRequest request, ServerCallContext context)
    {
        // In a real app, you would fetch this from the database via a service.
        _logger.LogInformation("Fetching profile for user {Username}", request.Username);
        return Task.FromResult(new GetUserResponse
        {
            Id = Guid.NewGuid().ToString(),
            Username = request.Username,
            FullName = "John Doe (from gRPC)",
            ProfilePictureUrl = ""
        });
    }
}
