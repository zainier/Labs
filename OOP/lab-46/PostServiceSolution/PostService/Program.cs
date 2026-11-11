using System.Text.Json.Serialization;
using Microsoft.OpenApi;
using PostService.BusinessLogic;
using PostService.DataAccess;
using PostService.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPostingRepository, PostingRepository>();
builder.Services.AddScoped<IPostingService, PostingService>();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter()
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend", policy =>
        policy.WithOrigins("http://localhost:3000", "http://localhost:60648")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PostService API",
        Version = "v1",
        Description = "REST API сервісу обліку поштових відправлень."
    });

    // Щоб у властивості-посилання (deliveryType) був власний опис, а не лише $ref на схему переліку.
    options.UseAllOfToExtendReferenceSchemas();

    // Ненульові рядки (string) у DTO не позначаються як nullable, лише string? — так.
    options.SupportNonNullableReferenceTypes();

    // XML-коментарі: ендпоінти (PostService), моделі контракту (Dtos) і перелік DeliveryType (CommonTypes).
    foreach (var xmlFile in new[] { "PostService.xml", "PostService.Dtos.xml", "PostService.CommonTypes.xml" })
    {
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
    }
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var repository = (PostingRepository)scope.ServiceProvider.GetRequiredService<IPostingRepository>();
    repository.CreateDb();
}

app.UseCors("frontend");

app.UseSwagger();
app.UseSwaggerUI();

app.Urls.Add("http://localhost:8080");

app.MapPostingEndpoints();

app.Run();
