var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:8080");

app.MapGet("/", () => "Це API поштового клієнта.");

app.Run();
