using InstaClone.Core.DTOs;
using System.Net.Http.Json;

namespace InstaClone.WinForms;

public partial class MainForm : Form
{
    private readonly HttpClient _httpClient;
    private List<PostDto> _posts = new();

    public MainForm()
    {
        InitializeComponent();
        _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7123/") };
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        try
        {
            _posts = await _httpClient.GetFromJsonAsync<List<PostDto>>("api/posts") ?? new List<PostDto>();
            postsDataGridView.DataSource = _posts;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load posts: {ex.Message}");
        }
    }
}
