using PostService.Dtos;

namespace PostService.App;

/// <summary>
/// Контракт клієнта сервісу PostService: по одному методу на кожен ендпоінт /postings.
/// </summary>
internal interface IPostServiceClient
{
    // GET /postings
    Task<PostingGetDto[]> GetPostingsAsync();

    // GET /postings/{id}
    Task<PostingGetDto> GetPostingByIdAsync(int id);

    // POST /postings
    Task<PostingGetDto> CreatePostingAsync(PostingPostDto posting);

    // PUT /postings/{id}
    Task<PostingGetDto> UpdatePostingAsync(int id, PostingPutDto posting);

    // DELETE /postings/{id}
    Task DeletePostingAsync(int id);
}
