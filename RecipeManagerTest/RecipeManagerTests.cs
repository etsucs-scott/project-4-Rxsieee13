using System;
using System.Collections.Generic;
using System.Linq;
using Recipe_Organizer.Components;
namespace RecipeManagerTest
{
    public class RecipeManagerTests
    {
        // Helper method to create a new RecipeManager instance for each test
        private RecipeManager CreateManager()
        {
            return new RecipeManager();
        }

        // Test to verify that adding a recipe increases the count of recipes
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

        // Test to verify that deleting a recipe removes it from the list
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

        // Test to verify the toggle favorite functionality
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

        // Test to verify that toggling favorite twice returns it to false
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

        // Test to verify that searching by name returns the correct recipe
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

        // Test to verify that searching by name is case insensitive
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

        // Test to verify that searching by name with no matches returns an empty list
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

        // Test to verify that getting recent recipes returns them in the correct order
        [Fact]
        public void GetRecentRecipes_ShouldReturnNewestFirst()
        {
            // Arrange
            var manager = CreateManager();
            manager.AddRecipe(new Recipe
            {
                Name = "Old Recipe",
                CreatedAt = DateTime.Now.AddHours(-1)
            });
            manager.AddRecipe(new Recipe
            {
                Name = "New Recipe",
                CreatedAt = DateTime.Now
            });
            // Act
            var result = manager.GetRecentRecipes();
            // Assert
            Assert.Equal("New Recipe", result.First().Name);
        }

        // Test to verify that getting recent recipes returns a maximum of 5 recipes
        [Fact]
        public void GetRecentRecipes_ShouldReturnMaxFive()
        {
            // Arrange
            var manager = CreateManager();
            for (int i = 0; i < 10; i++)
            {
                manager.AddRecipe(new Recipe
                {
                    Name = $"Recipe {i}",
                    CreatedAt = DateTime.Now.AddMinutes(-i)
                });
            }
            // Act
            var result = manager.GetRecentRecipes();
            // Assert
            Assert.Equal(5, result.Count);
        }

        // Test to verify that getting the most used ingredients counts them correctly across all recipes
        [Fact]
        public void GetMostUsedIngredients_ShouldCountCorrectly()
        {
            // Arrange
            var manager = CreateManager();
            manager.AddRecipe(new Recipe
            {
                Name = "Recipe 1",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Eggs" },
                    new Ingredient { Name = "Flour" },
                    new Ingredient { Name = "Sugar" }
                }
            });
            manager.AddRecipe(new Recipe
            {
                Name = "Recipe 2",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Eggs" },
                    new Ingredient { Name = "Milk" }
                }
            });
            manager.AddRecipe(new Recipe
            {
                Name = "Recipe 3",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Flour" },
                    new Ingredient { Name = "Butter" }
                }
            });
            // Act
            var result = manager.GetMostUsedIngredients();
        }

        // Test to verify that adding multiple recipes stores all of them correctly
        [Fact]
        public void AddMultipleRecipes_ShouldStoreAll()
        {
            // Arrange
            var manager = CreateManager();
            // Act
            manager.AddRecipe(new Recipe { Name = "Recipe A" });
            manager.AddRecipe(new Recipe { Name = "Recipe B" });
            manager.AddRecipe(new Recipe { Name = "Recipe C" });
            // Assert
            var allRecipes = manager.GetAll();
            Assert.Equal(3, allRecipes.Count);
        }

        // Test to verify that the default value of IsFavorite is false when a new recipe is created
        [Fact]
        public void Favorite_DefaultShouldBeFalse()
        {
            // Arrange
            var recipe = new Recipe { Name = "Test Cake Recipe" };
            // Assert
            Assert.False(recipe.IsFavorite);
        }
    }
}