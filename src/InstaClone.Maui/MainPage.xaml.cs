using InstaClone.Core.DTOs;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace InstaClone.Maui;

public partial class MainPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public ObservableCollection<PostDto> Posts { get; set; }

    public MainPage()
    {
        InitializeComponent();
        Posts = new ObservableCollection<PostDto>();
        BindingContext = this;
        _httpClient = new HttpClient { BaseAddress = new Uri("http://10.0.2.2:5123/") }; // Use http and 10.0.2.2 for Android emulator
        LoadPosts();
    }

    private async void LoadPosts()
    {
        try
        {
            var posts = await _httpClient.GetFromJsonAsync<List<PostDto>>("api/posts");
            if (posts != null)
            {
                foreach (var post in posts)
                {
                    Posts.Add(post);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load posts: {ex.Message}", "OK");
        }
    }
}
