using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using PostService.Dtos;

namespace PostService.App;

/// <summary>
/// Клієнт REST API PostService. Єдине місце, яке знає адресу сервера й перевіряє його відповіді.
/// Неуспішна відповідь перетворюється на виняток: 400 — <see cref="PostingValidationException"/>,
/// інші коди — <see cref="HttpRequestException"/> зі статус-кодом. Якщо сервер недоступний,
/// HttpClient генерує <see cref="HttpRequestException"/> без статус-коду.
/// </summary>
internal class PostServiceClient : IPostServiceClient
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("http://localhost:8080")
    };

    private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public async Task<PostingGetDto[]> GetPostingsAsync()
    {
        using var response = await _httpClient.GetAsync("/postings");
        await EnsureSuccessAsync(response);

        return await ReadAsync<PostingGetDto[]>(response);
    }

    public async Task<PostingGetDto> GetPostingByIdAsync(int id)
    {
        using var response = await _httpClient.GetAsync($"/postings/{id}");
        await EnsureSuccessAsync(response);

        return await ReadAsync<PostingGetDto>(response);
    }

    public async Task<PostingGetDto> CreatePostingAsync(PostingPostDto posting)
    {
        using var response = await _httpClient.PostAsJsonAsync("/postings", posting, _jsonOptions);
        await EnsureSuccessAsync(response);

        return await ReadAsync<PostingGetDto>(response);
    }

    public async Task<PostingGetDto> UpdatePostingAsync(int id, PostingPutDto posting)
    {
        using var response = await _httpClient.PutAsJsonAsync($"/postings/{id}", posting, _jsonOptions);
        await EnsureSuccessAsync(response);

        return await ReadAsync<PostingGetDto>(response);
    }

    public async Task DeletePostingAsync(int id)
    {
        using var response = await _httpClient.DeleteAsync($"/postings/{id}");
        await EnsureSuccessAsync(response);
    }

    private async Task EnsureSuccessAsync(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problem = await response.Content.ReadFromJsonAsync<ValidationErrorResponse>(_jsonOptions);
            throw new PostingValidationException(problem?.Errors ?? []);
        }

        throw new HttpRequestException(
            $"Сервер повернув помилку {(int)response.StatusCode}.",
            null,
            response.StatusCode);
    }

    private async Task<T> ReadAsync<T>(HttpResponseMessage response)
    {
        return await response.Content.ReadFromJsonAsync<T>(_jsonOptions)
            ?? throw new JsonException("Сервер повернув порожню відповідь.");
    }
}
