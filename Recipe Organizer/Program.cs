using Recipe_Organizer.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register services for dependency injection
builder.Services.AddSingleton<RecipeManager>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddSingleton<ShoppingListService>();

// Add Antiforgery services for CSRF protection
var app = builder.Build();

// Load recipes from file on startup
var fileService = app.Services.GetRequiredService<FileService>();
var manager = app.Services.GetRequiredService<RecipeManager>();
manager.Load(fileService.Load());

// Save recipes to file on shutdown
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// Serve static files (like CSS, JS, and the JSON data file)
app.UseStaticFiles();
app.UseAntiforgery();

// Map Razor components to the app
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

