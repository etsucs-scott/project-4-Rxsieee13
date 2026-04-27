using System;

public class RecipeManager
{
    // In-memory storage for recipes and category mapping
    private List<Recipe> _recipes = new();
    // Key: Category name, Value: List of recipes in that category
    private Dictionary<string, List<Recipe>> _categoryMap = new();

    // Load recipes and build category map
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

    // Add a new recipe
    public void AddRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);

        if (!_categoryMap.ContainsKey(recipe.Category))
            _categoryMap[recipe.Category] = new List<Recipe>();

        _categoryMap[recipe.Category].Add(recipe);
    }

    // Delete a recipe
    public void DeleteRecipe(Recipe recipe)
    {
        _recipes.Remove(recipe);

        if (_categoryMap.ContainsKey(recipe.Category))
            _categoryMap[recipe.Category].Remove(recipe);
    }

    // Update an existing recipe
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

    // Toggle favorite status
    public void ToggleFavorite(Recipe recipe)
    {
        recipe.IsFavorite = !recipe.IsFavorite;
    }

    // Get all recipes
    public List<Recipe> GetAll() => _recipes;

    // Search recipes by name
    public List<Recipe> SearchByName(string keyword)
    {
        return _recipes
            .Where(r => r.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Filter recipes by ingredient
    public List<Recipe> FilterByIngredient(string ingredient)
    {
        return _recipes
            .Where(r => r.Ingredients.Any(i =>
                i.Name.Contains(ingredient, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }

    // Get recipes by category
    public List<Recipe> GetRecentRecipes()
    {
        return _recipes
            .OrderByDescending(r => r.CreatedAt)
            .Take(5)
            .ToList();
    }

    // Get a count of how many times each ingredient is used across all recipes
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