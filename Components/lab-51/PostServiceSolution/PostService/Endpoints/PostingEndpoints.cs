using Microsoft.AspNetCore.Http.HttpResults;
using PostService.BusinessLogic;
using PostService.Dtos;
using PostService.Mappings;
using PostService.Validation;

namespace PostService.Endpoints;

/// <summary>
/// Ендпоінти REST API для роботи з поштовими відправленнями.
/// </summary>
public static class PostingEndpoints
{
    /// <summary>
    /// Реєструє ендпоінти групи /postings.
    /// </summary>
    /// <param name="app">Побудовник маршрутів застосунку.</param>
    public static void MapPostingEndpoints(this IEndpointRouteBuilder app)
    {
        var postings = app.MapGroup("/postings").WithTags("Поштові відправлення");

        postings.MapGet("", GetAll);
        postings.MapGet("/{id}", GetById);
        postings.MapPost("", Create);
        postings.MapPut("/{id}", Update);
        postings.MapDelete("/{id}", Delete);
    }

    /// <summary>
    /// Отримати список відправлень
    /// </summary>
    /// <remarks>
    /// Повертає всі поштові відправлення, збережені в сервісі.
    /// </remarks>
    /// <param name="postingService">Сервіс бізнес-логіки відправлень.</param>
    /// <response code="200">Список відправлень (може бути порожнім).</response>
    public static Ok<List<PostingGetDto>> GetAll(IPostingService postingService)
    {
        var result = postingService.GetAll()
            .Select(PostingMapper.ToPostingGetDto)
            .ToList();

        return TypedResults.Ok(result);
    }

    /// <summary>
    /// Отримати відправлення за ідентифікатором
    /// </summary>
    /// <remarks>
    /// Повертає одне поштове відправлення з указаним ідентифікатором.
    /// </remarks>
    /// <param name="id">Ідентифікатор відправлення.</param>
    /// <param name="postingService">Сервіс бізнес-логіки відправлень.</param>
    /// <response code="200">Знайдене відправлення.</response>
    /// <response code="404">Відправлення з таким ідентифікатором не існує.</response>
    public static Results<Ok<PostingGetDto>, NotFound> GetById(int id, IPostingService postingService)
    {
        var posting = postingService.Find(id);

        return posting is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(PostingMapper.ToPostingGetDto(posting));
    }

    /// <summary>
    /// Створити відправлення
    /// </summary>
    /// <remarks>
    /// Перевіряє дані, обчислює вартість доставки (вага × тариф типу доставки)
    /// і зберігає нове відправлення.
    /// </remarks>
    /// <param name="dto">Дані нового відправлення.</param>
    /// <param name="postingService">Сервіс бізнес-логіки відправлень.</param>
    /// <response code="201">Відправлення створено; у тілі — збережений запис, у заголовку Location — його адреса.</response>
    /// <response code="400">Дані не пройшли перевірку; у тілі — помилки по полях.</response>
    public static Results<Created<PostingGetDto>, ValidationProblem> Create(
        PostingPostDto dto, IPostingService postingService)
    {
        var errors = PostingValidator.Validate(dto);

        if (errors.Count > 0)
        {
            return TypedResults.ValidationProblem(errors);
        }

        var savedPosting = postingService.Create(PostingMapper.ToPosting(dto));
        var resultDto = PostingMapper.ToPostingGetDto(savedPosting);

        return TypedResults.Created($"/postings/{resultDto.Id}", resultDto);
    }

    /// <summary>
    /// Змінити відправлення
    /// </summary>
    /// <remarks>
    /// Перевіряє дані, перераховує вартість доставки й оновлює відправлення з указаним ідентифікатором.
    /// </remarks>
    /// <param name="id">Ідентифікатор відправлення, яке змінюється.</param>
    /// <param name="dto">Нові дані відправлення.</param>
    /// <param name="postingService">Сервіс бізнес-логіки відправлень.</param>
    /// <response code="200">Відправлення змінено; у тілі — оновлений запис.</response>
    /// <response code="400">Дані не пройшли перевірку; у тілі — помилки по полях.</response>
    /// <response code="404">Відправлення з таким ідентифікатором не існує.</response>
    public static Results<Ok<PostingGetDto>, ValidationProblem, NotFound> Update(
        int id, PostingPutDto dto, IPostingService postingService)
    {
        dto.Id = id;

        var errors = PostingValidator.Validate(dto);

        if (errors.Count > 0)
        {
            return TypedResults.ValidationProblem(errors);
        }

        var updatedPosting = postingService.Update(PostingMapper.ToPosting(dto));

        return updatedPosting is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(PostingMapper.ToPostingGetDto(updatedPosting));
    }

    /// <summary>
    /// Видалити відправлення
    /// </summary>
    /// <remarks>
    /// Видаляє поштове відправлення з указаним ідентифікатором.
    /// </remarks>
    /// <param name="id">Ідентифікатор відправлення, яке видаляється.</param>
    /// <param name="postingService">Сервіс бізнес-логіки відправлень.</param>
    /// <response code="204">Відправлення видалено.</response>
    /// <response code="404">Відправлення з таким ідентифікатором не існує.</response>
    public static Results<NoContent, NotFound> Delete(int id, IPostingService postingService)
    {
        return postingService.Delete(id) == 0
            ? TypedResults.NotFound()
            : TypedResults.NoContent();
    }
}
