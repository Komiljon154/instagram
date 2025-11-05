using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace InstaClone.Functions;

public class GetPostStats
{
    private readonly ILogger _logger;

    public GetPostStats(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<GetPostStats>();
    }

    [Function("GetPostStats")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "posts/{postId}/stats")] HttpRequestData req, string postId)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request for post stats.");

        // In a real app, this would fetch data from the database.
        var stats = new { PostId = postId, Likes = 123, Comments = 45 };

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteAsJsonAsync(stats);

        return response;
    }
}
