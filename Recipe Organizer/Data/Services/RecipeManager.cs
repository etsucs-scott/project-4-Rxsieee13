using System;

public class RecipeManager
{
    private List<Recipe> _recipes = new();
    private Dictionary<string, List<Recipe>> _categoryMap = new();

    public void Load(List<Recipe> recipes)
    {
        _recipes = recipes;
        _categoryMap.Clear();

        foreach (var recipe in recipes)
        {
            if (!_categoryMap.ContainsKey(recipe.Category))
                _categoryMap[recipe.Category] = new List<Recipe>();

            _categoryMap[recipe.Category].Add(recipe);
        }
    }

    public void AddRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);

        if (!_categoryMap.ContainsKey(recipe.Category))
            _categoryMap[recipe.Category] = new List<Recipe>();

        _categoryMap[recipe.Category].Add(recipe);
    }

    public void DeleteRecipe(Recipe recipe)
    {
        _recipes.Remove(recipe);

        if (_categoryMap.ContainsKey(recipe.Category))
            _categoryMap[recipe.Category].Remove(recipe);
    }

    public void UpdateRecipe(Recipe updated)
    {
        var existing = _recipes.FirstOrDefault(r => r.Name == updated.Name);
        if (existing != null)
        {
            existing.Category = updated.Category;
            existing.Ingredients = updated.Ingredients;
            existing.Instructions = updated.Instructions;
            existing.IsFavorite = updated.IsFavorite;
        }
    }

    public void ToggleFavorite(Recipe recipe)
    {
        recipe.IsFavorite = !recipe.IsFavorite;
    }

    public List<Recipe> GetAll() => _recipes;

    public List<Recipe> SearchByName(string keyword)
    {
        return _recipes
            .Where(r => r.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Recipe> FilterByIngredient(string ingredient)
    {
        return _recipes
            .Where(r => r.Ingredients.Any(i =>
                i.Name.Contains(ingredient, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }

    public List<Recipe> GetRecentRecipes()
    {
        return _recipes
            .OrderByDescending(r => r.CreatedAt)
            .Take(5)
            .ToList();
    }

    public Dictionary<string, int> GetMostUsedIngredients()
    {
        var count = new Dictionary<string, int>();

        foreach (var recipe in _recipes)
        {
            foreach (var ing in recipe.Ingredients)
            {
                if (count.ContainsKey(ing.Name))
                    count[ing.Name]++;
                else
                    count[ing.Name] = 1;
            }
        }

        return count.OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
    }
}