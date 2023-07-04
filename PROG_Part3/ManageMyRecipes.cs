using System;
using System.Collections.Generic;
using PROG_Part3;

namespace PROG_Part3
{
    public class ManageMyRecipes
    {
        // Dictionary to store recipes with recipe name as the key and RecipeClass object as the value
        private Dictionary<string, RecipeClass> recipes;

        // Constructor to initialize the recipes dictionary
        public ManageMyRecipes()
        {
            recipes = new Dictionary<string, RecipeClass>();
        }

        // Add a recipe to the dictionary
        public void AddRecipe(string recipeName, RecipeClass recipe)
        {
            recipes.Add(recipeName, recipe);
        }

        // Retrieve a recipe from the dictionary based on the recipe name
        public RecipeClass GetRecipe(string recipeName)
        {
            if (recipes.ContainsKey(recipeName))
            {
                return recipes[recipeName];
            }
            return null;
        }

        // Retrieve all the recipes from the dictionary
        public Dictionary<string, RecipeClass> GetRecipes()
        {
            return recipes;
        }
    }
}
