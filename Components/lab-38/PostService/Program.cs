using System.Text.Json.Serialization;
using PostService.Models;

var postings = new List<Posting>
{
    new Posting
    {
        Id = 1,
        From = "Alice",
        To = "Bob",
        Content = "Books",
        DeliveryType = DeliveryType.Courier,
        Weight = 2.5f,
        Width = 30,
        Height = 20,
        Depth = 10,
        Value = 50.0f,
        Price = 10.0f,
        CreatedAt = DateTime.UtcNow
    },
    new Posting
    {
        Id = 2,
        From = "Charlie",
        To = "Dave",
        Content = "Clothes",
        DeliveryType = DeliveryType.ExpressCourier,
        Weight = 1.0f,
        Width = 25,
        Height = 15,
        Depth = 5,
        Value = 30.0f,
        Price = 15.0f,
        CreatedAt = DateTime.UtcNow
    },
    new Posting
    {
        Id = 3,
        From = "Eve",
        To = "Frank",
        Content = "Electronics",
        DeliveryType = DeliveryType.Department,
        Weight = 5.0f,
        Width = 40,
        Height = 30,
        Depth = 20,
        Value = 200.0f,
        Price = 25.0f,
        CreatedAt = DateTime.UtcNow
    }
};

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

app.Urls.Add("http://localhost:8080");

app.MapPost("/postings", (Posting posting) =>
{
    posting.Id = postings.Max(p => p.Id) + 1;
    posting.CreatedAt = DateTime.UtcNow;

    postings.Add(posting);

    return Results.Created($"/postings/{posting.Id}", posting);
});

app.MapGet("/postings", () => postings);

app.MapGet("/postings/{id}", (int id) =>
{
    var posting = postings.FirstOrDefault(p => p.Id == id);

    return posting is not null
        ? Results.Ok(posting)
        : Results.NotFound();
});

app.MapPut("/postings/{id}", (int id, Posting updatedPosting) =>
{
    var posting = postings.FirstOrDefault(p => p.Id == id);

    if (posting is null)
    {
        return Results.NotFound();
    }

    posting.From = updatedPosting.From;
    posting.To = updatedPosting.To;
    posting.Content = updatedPosting.Content;
    posting.DeliveryType = updatedPosting.DeliveryType;
    posting.Weight = updatedPosting.Weight;
    posting.Width = updatedPosting.Width;
    posting.Height = updatedPosting.Height;
    posting.Depth = updatedPosting.Depth;
    posting.Value = updatedPosting.Value;
    posting.Price = updatedPosting.Price;

    return Results.Ok(posting);
});

app.MapDelete("/postings/{id}", (int id) =>
{
    var posting = postings.FirstOrDefault(p => p.Id == id);

    if (posting is null)
    {
        return Results.NotFound();
    }

    postings.Remove(posting);

    return Results.NoContent();
});

app.Run();