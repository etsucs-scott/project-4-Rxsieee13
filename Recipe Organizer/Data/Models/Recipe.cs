using System;

public class Recipe
{
    public string Name { get; set; } = "";
    public List<Ingredient> Ingredients { get; set; } = new();
    public string Instructions { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsFavorite { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
