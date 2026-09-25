using System.Text.Json.Serialization;
using PostService.Dtos;
using PostService.Mappings;
using PostService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPostingService, PostingService>();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter()
    );
});

var app = builder.Build();

app.Urls.Add("http://localhost:8080");

app.MapPost(
    "/postings",
    (PostingPostDto dto, IPostingService postingService) =>
    {
        var posting = PostingMapper.ToPosting(dto);
        var savedPosting = postingService.Create(posting);
        var resultDto = PostingMapper.ToPostingGetDto(savedPosting);

        return Results.Created(
            $"/postings/{resultDto.Id}",
            resultDto
        );
    });

app.MapGet(
    "/postings",
    (IPostingService postingService) =>
    {
        var postings = postingService.GetAll();

        var result = postings
            .Select(PostingMapper.ToPostingGetDto)
            .ToList();

        return Results.Ok(result);
    });

app.MapGet(
    "/postings/{id}",
    (int id, IPostingService postingService) =>
    {
        var posting = postingService.Find(id);

        if (posting is null)
        {
            return Results.NotFound();
        }

        var resultDto = PostingMapper.ToPostingGetDto(posting);

        return Results.Ok(resultDto);
    });

app.MapPut(
    "/postings/{id}",
    (int id, PostingPutDto dto, IPostingService postingService) =>
    {
        dto.Id = id;

        var posting = PostingMapper.ToPosting(dto);
        var updatedPosting = postingService.Update(posting);

        if (updatedPosting is null)
        {
            return Results.NotFound();
        }

        var resultDto = PostingMapper.ToPostingGetDto(updatedPosting);

        return Results.Ok(resultDto);
    });

app.MapDelete(
    "/postings/{id}",
    (int id, IPostingService postingService) =>
    {
        var deletedCount = postingService.Delete(id);

        return deletedCount == 0
            ? Results.NotFound()
            : Results.NoContent();
    });

app.Run();