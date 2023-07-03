using System;
using System.Collections.Generic;
using PROG_Part3;

namespace PROG_Part3
{
    public class ManageMyRecipes
    {
        private Dictionary<string, RecipeClass> recipes;

        public ManageMyRecipes()
        {
            recipes = new Dictionary<string, RecipeClass>();
        }

        public void AddRecipe(string recipeName, RecipeClass recipe)
        {
            recipes.Add(recipeName, recipe);
        }

        public RecipeClass GetRecipe(string recipeName)
        {
            if (recipes.ContainsKey(recipeName))
            {
                return recipes[recipeName];
            }
            return null;
        }

        public Dictionary<string, RecipeClass> GetRecipes()
        {
            return recipes;
        }

    }
}
