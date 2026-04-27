namespace RecipeOrganizerTest;
using Recipe_Organizer.Components;
using Xunit;


public class RecipeManagerTests
{
    private RecipeManager CreateManager()
    {
        return new RecipeManager();
    }

    [Fact]
    public void AddRecipe_ShouldIncreaseCount()
    {
        // Arrange
        var manager = CreateManager();
        // Act
        manager.AddRecipe(new Recipe { Name = "Pancakes" });
        // Assert
        Assert.Single(manager.GetAll());

    }

    [Fact]
    public void DeleteRecipe_ShouldRemoveRecipe()
    {
        // Arrange
        var manager = CreateManager();
        var recipe = new Recipe { Name = "Salad" };
        manager.AddRecipe(recipe);
        // Act
        manager.DeleteRecipe(recipe);
        // Assert
        Assert.Empty(manager.GetAll());
    }

    [Fact]
    public void ToggleFavorite_ShouldSetTrue()
    {
        // Arrange
        var manager = CreateManager();
        var recipe = new Recipe { Name = "Pizza" };
        // Act
        manager.ToggleFavorite(recipe);
        // Assert
        Assert.True(recipe.IsFavorite);
    }

    [Fact]
    public void ToggleFavorite_Twice_ShouldReturnFalse()
    {
        // Arrange
        var manager = CreateManager();
        var recipe = new Recipe { Name = "Burger" };
        // Act
        manager.ToggleFavorite(recipe);
        manager.ToggleFavorite(recipe);
        // Assert
        Assert.False(recipe.IsFavorite);
    }

    [Fact]
    public void SearchByName_ShouldFindMatch()
    {
        // Arrange
        var manager = CreateManager();
        manager.AddRecipe(new Recipe { Name = "Chocolate Cake" });
        // Act
        var result = manager.SearchByName("Cake");
        // Assert
        Assert.Single(result);
    }

    [Fact]
    public void SearchByName_ShouldBeCaseInsensitive()
    {
        // Arrange
        var manager = CreateManager();
        manager.AddRecipe(new Recipe { Name = "Vanilla Ice Cream" });
        // Act
        var result = manager.SearchByName("ice cream");
        // Assert
        Assert.Single(result);
    }

    [Fact]
    public void SearchByName_NoMatch_ShouldReturnEmpty()
    {
        // Arrange
        var manager = CreateManager();
        manager.AddRecipe(new Recipe { Name = "Spaghetti" });
        // Act
        var result = manager.SearchByName("Pizza");
        // Assert
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