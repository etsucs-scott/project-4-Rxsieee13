using Recipe_Organizer.Components;

builder.Services.AddSingleton<RecipeManager>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddSingleton<ShoppingListService>();

var app = builder.Build();

var fileService = app.Services.GetRequiredService<FileService>();
var manager = app.Services.GetRequiredService<RecipeManager>();

manager.Load(fileService.Load());


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
