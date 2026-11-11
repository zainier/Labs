// Вебсервер, що роздає сторінки клієнтського застосунку з папки wwwroot.
// Дані сторінки отримують безпосередньо з REST API PostService (http://localhost:8080).
var app = WebApplication.CreateBuilder(args).Build();

app.Urls.Add("http://localhost:3000");

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
