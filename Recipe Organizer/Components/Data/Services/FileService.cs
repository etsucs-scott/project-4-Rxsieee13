using System;

using System.Text.Json;

public class FileService
{
    // Path to the JSON file where recipes will be stored
    private readonly string path = "wwwroot/data/recipes.json";

    // Save recipes to a JSON file
    public void Save(List<Recipe> recipes)
    {
        try
        {
            var json = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
        catch { }
    }

    // Load recipes from a JSON file
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
