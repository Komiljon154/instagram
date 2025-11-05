using InstaClone.Core.DTOs;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace InstaClone.Wpf;

public partial class MainWindow : Window
{
    private readonly HttpClient _httpClient;
    public ObservableCollection<PostDto> Posts { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        Posts = new ObservableCollection<PostDto>();
        _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7123/") };
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
            MessageBox.Show($"Failed to load posts: {ex.Message}");
        }
    }
}
