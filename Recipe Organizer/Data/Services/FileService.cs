using System;

using System.Text.Json;

public class FileService
{
    private readonly string path = "wwwroot/data/recipes.json";

    public void Save(List<Recipe> recipes)
    {
        try
        {
            var json = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
        catch { }
    }

    public List<Recipe> Load()
    {
        try
        {
            if (!File.Exists(path)) return new List<Recipe>();
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
        }
        catch
        {
            return new List<Recipe>();
        }
    }
}
