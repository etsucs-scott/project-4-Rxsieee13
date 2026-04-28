using System;

public class ShoppingListService
{
    // Generates a consolidated shopping list from a list of recipes.
    public List<Ingredient> Generate(List<Recipe> recipes)
    {
        // Key: ingredient name (lowercase), Value: consolidated ingredient
        var result = new Dictionary<string, Ingredient>();

        // Loop through each recipe and its ingredients to aggregate quantities.
        foreach (var recipe in recipes)
        {
            foreach (var ing in recipe.Ingredients)
            {
                string key = ing.Name.ToLower();

                if (result.ContainsKey(key))
                {
                    result[key].Quantity += ing.Quantity;
                }
                else
                {
                    result[key] = new Ingredient
                    {
                        Name = ing.Name,
                        Quantity = ing.Quantity,
                        Unit = ing.Unit
                    };
                }
            }
        }

        return result.Values.ToList();
    }
}