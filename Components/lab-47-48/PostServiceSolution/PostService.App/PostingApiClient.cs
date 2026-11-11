using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using PostService.Dtos;

namespace PostService.App;

/// <summary>
/// Клієнт REST API сервісу PostService. Інкапсулює HTTP-виклики до ендпоінтів /postings.
/// У разі помилки з'єднання або неуспішного статусу відповіді викидає <see cref="HttpRequestException"/>.
/// </summary>
public class PostingApiClient
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("http://localhost:8080")
    };

    private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public async Task<PostingGetDto[]> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<PostingGetDto[]>("postings", _jsonOptions) ?? [];
    }

    public async Task<PostingGetDto> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<PostingGetDto>($"postings/{id}", _jsonOptions)
            ?? throw new HttpRequestException(null, null, HttpStatusCode.NotFound);
    }

    public async Task CreateAsync(PostingPostDto posting)
    {
        var response = await _httpClient.PostAsJsonAsync("postings", posting, _jsonOptions);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(PostingPutDto posting)
    {
        var response = await _httpClient.PutAsJsonAsync($"postings/{posting.Id}", posting, _jsonOptions);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"postings/{id}");
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Формує зрозуміле користувачеві повідомлення про помилку виконання запиту.
    /// </summary>
    public static string DescribeError(HttpRequestException exception)
    {
        return exception.StatusCode switch
        {
            null => "Не вдалося з'єднатися із сервером.\nПеревірте, чи запущено PostService.",
            HttpStatusCode.NotFound => "Відправлення не знайдено.\nМожливо, його вже видалено.",
            HttpStatusCode.BadRequest => "Сервер відхилив дані відправлення як некоректні.",
            _ => $"Сервер повернув помилку {(int)exception.StatusCode}."
        };
    }
}
