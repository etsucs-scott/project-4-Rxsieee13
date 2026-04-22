using Recipe_Organizer.Components;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var fileService = app.Services.GetRequiredService<FileService>();
var manager = app.Services.GetRequiredService<RecipeManager>();

manager.Load(fileService.Load());

builder.Services.AddSingleton<RecipeManager>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddSingleton<ShoppingListService>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapFallbackToPage( "/index.html");
app.MapFallbackToPage( "/recipes/{*path}", "/_Host");

app.Run();


