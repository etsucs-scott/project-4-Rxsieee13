using Recipe_Organizer.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<RecipeManager>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddSingleton<ShoppingListService>();

var app = builder.Build();

var fileService = app.Services.GetRequiredService<FileService>();
var manager = app.Services.GetRequiredService<RecipeManager>();
manager.Load(fileService.Load());

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

