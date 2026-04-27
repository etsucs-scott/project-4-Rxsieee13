using System;

public class ShoppingListService
{
    // This service generates a shopping list by aggregating ingredients from selected recipes.
    public List<Ingredient> Generate(List<Recipe> recipes)
    {
        var result = new Dictionary<string, Ingredient>();

        // Aggregate ingredients from all recipes, summing quantities for duplicates
        foreach (var recipe in recipes)
        {
            foreach (var ing in recipe.Ingredients)
            {
                if (result.ContainsKey(ing.Name))
                    result[ing.Name].Quantity += ing.Quantity;
                else
                    result[ing.Name] = new Ingredient
                    {
                        Name = ing.Name,
                        Quantity = ing.Quantity,
                        Unit = ing.Unit
                    };
            }
        }

        return result.Values.ToList();
    }
}