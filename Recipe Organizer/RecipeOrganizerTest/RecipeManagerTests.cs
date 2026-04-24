namespace RecipeOrganizerTest;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

public class RecipeManagerTests
{
    private RecipeManager CreateManager()
    {
        return new RecipeManager();
    }

    [Fact]
    public void AddRecipe_ShouldIncreaseCount()
    {
        var manager = CreateManager();

        manager.AddRecipe(new Recipe { Name = "Pizza" });

        Assert.Single(manager.GetAll());
    }

    [Fact]
    public void DeleteRecipe_ShouldRemoveRecipe()
    {
        var manager = CreateManager();
        var recipe = new Recipe { Name = "Burger" };

        manager.AddRecipe(recipe);
        manager.DeleteRecipe(recipe);

        Assert.Empty(manager.GetAll());
    }

    [Fact]
    public void ToggleFavorite_ShouldSetTrue()
    {
        var manager = CreateManager();
        var recipe = new Recipe();

        manager.ToggleFavorite(recipe);

        Assert.True(recipe.IsFavorite);
    }

    [Fact]
    public void ToggleFavorite_Twice_ShouldReturnFalse()
    {
        var manager = CreateManager();
        var recipe = new Recipe();

        manager.ToggleFavorite(recipe);
        manager.ToggleFavorite(recipe);

        Assert.False(recipe.IsFavorite);
    }

    [Fact]
    public void SearchByName_ShouldFindMatch()
    {
        var manager = CreateManager();

        manager.AddRecipe(new Recipe { Name = "Tacos" });

        var result = manager.SearchByName("Tac");

        Assert.Single(result);
    }

    [Fact]
    public void SearchByName_ShouldBeCaseInsensitive()
    {
        var manager = CreateManager();

        manager.AddRecipe(new Recipe { Name = "Pasta" });

        var result = manager.SearchByName("pasta");

        Assert.Single(result);
    }

    [Fact]
    public void SearchByName_NoMatch_ShouldReturnEmpty()
    {
        var manager = CreateManager();

        manager.AddRecipe(new Recipe { Name = "Soup" });

        var result = manager.SearchByName("Cake");

        Assert.Empty(result);
    }

    [Fact]
    public void GetRecentRecipes_ShouldReturnNewestFirst()
    {
        var manager = CreateManager();

        manager.AddRecipe(new Recipe
        {
            Name = "Old",
            CreatedAt = DateTime.Now.AddDays(-1)
        });

        manager.AddRecipe(new Recipe
        {
            Name = "New",
            CreatedAt = DateTime.Now
        });

        var result = manager.GetRecentRecipes();

        Assert.Equal("New", result.First().Name);
    }

    [Fact]
    public void GetRecentRecipes_ShouldReturnMaxFive()
    {
        var manager = CreateManager();

        for (int i = 0; i < 10; i++)
        {
            manager.AddRecipe(new Recipe
            {
                Name = $"Recipe{i}",
                CreatedAt = DateTime.Now.AddMinutes(i)
            });
        }

        var result = manager.GetRecentRecipes();

        Assert.Equal(5, result.Count);
    }

    [Fact]
    public void GetMostUsedIngredients_ShouldCountCorrectly()
    {
        var manager = CreateManager();

        manager.AddRecipe(new Recipe
        {
            Ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Cheese" }
            }
        });

        manager.AddRecipe(new Recipe
        {
            Ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Cheese" }
            }
        });

        var stats = manager.GetMostUsedIngredients();

        Assert.Equal(2, stats["Cheese"]);
    }

    [Fact]
    public void AddMultipleRecipes_ShouldStoreAll()
    {
        var manager = CreateManager();

        manager.AddRecipe(new Recipe());
        manager.AddRecipe(new Recipe());
        manager.AddRecipe(new Recipe());

        Assert.Equal(3, manager.GetAll().Count);
    }

    [Fact]
    public void Favorite_DefaultShouldBeFalse()
    {
        var recipe = new Recipe();

        Assert.False(recipe.IsFavorite);
    }
}