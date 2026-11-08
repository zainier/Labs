using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using PostService.Dtos;

namespace PostService.App;

public partial class PostingList : Form
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("http://localhost:8080")
    };

    private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public PostingList()
    {
        InitializeComponent();
        gridPostings.AutoGenerateColumns = false;
    }

    private async Task LoadPostingsAsync()
    {
        try
        {
            var postings = await _httpClient.GetFromJsonAsync<PostingGetDto[]>("postings", _jsonOptions);

            gridPostings.DataSource = postings;
        }
        catch (HttpRequestException)
        {
            MessageBox.Show("Не вдалося отримати дані з сервера. Перевірте, чи запущено PostService.");
        }
    }

    private async void PostingList_Load(object? sender, EventArgs e)
    {
        await LoadPostingsAsync();
    }

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadPostingsAsync();
    }

    private async void btnDelete_Click(object? sender, EventArgs e)
    {
        if (gridPostings.CurrentRow?.DataBoundItem is not PostingGetDto selectedPosting)
        {
            MessageBox.Show("Виберіть відправлення, яке потрібно видалити.");
            return;
        }

        var response = await _httpClient.DeleteAsync($"postings/{selectedPosting.Id}");

        if (!response.IsSuccessStatusCode)
        {
            MessageBox.Show($"Не вдалося видалити відправлення. Сервер повернув статус {(int)response.StatusCode}.");
        }

        await LoadPostingsAsync();
    }
}
