using InstaClone.Core.DTOs;
using System.Net.Http.Json;

namespace InstaClone.BlazorServer.Data;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PostDto>?> GetPostsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<PostDto>>("api/posts");
    }
}
