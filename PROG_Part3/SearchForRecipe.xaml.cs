using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using PROG_Part3;

namespace PROG_Part3
{
    public partial class SearchForRecipe : UserControl
    {
        public ObservableCollection<Recipe> Recipes { get; set; }  // Collection to store the recipes

        public SearchForRecipe()
        {
            InitializeComponent();
            Recipes = new ObservableCollection<Recipe>();  // Initialize the recipe collection

            GetRecipes();  // Populate the recipe collection
            UpdateDataGrid();  // Update the data grid with the recipes
        }

        // Method to update the data grid with the provided recipes
        private void UpdateDataGrid(List<Recipe> recipes = null)
        {
            dataGrid.ItemsSource = recipes != null ? new ObservableCollection<Recipe>(recipes) : Recipes;  // Set the data grid's items source to the provided recipes or the entire recipe collection
        }

        // Method to populate the recipe collection with sample recipes
        private void GetRecipes()
        {
            // Add recipes to the collection
            Recipes.Add(new Recipe { RecipeName = "Recipe 1", IngredientName = "Ingredient A", Calories = 100, FoodGroup = "Group 1" });
            Recipes.Add(new Recipe { RecipeName = "Recipe 2", IngredientName = "Ingredient B", Calories = 200, FoodGroup = "Group 2" });
            Recipes.Add(new Recipe { RecipeName = "Recipe 3", IngredientName = "Ingredient C", Calories = 300, FoodGroup = "Group 1" });
            Recipes.Add(new Recipe { RecipeName = "Recipe 4", IngredientName = "Ingredient D", Calories = 150, FoodGroup = "Group 3" });
        }

        // Event handler for BackButton click
        private void BackButton_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            WindowState windowState = Window.GetWindow(this)?.WindowState ?? WindowState.Normal;

            // Pass the window state to the MainWindow
            mainWindow.WindowState = windowState;

            Application.Current.MainWindow = mainWindow;
            Window.GetWindow(this)?.Hide();
            mainWindow.Show();
        }

        private void CaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public Dictionary<string, RecipeClass> Search_Click(bool caloriesFilter, double maximumCalories, bool ingredientFilter, string ingredientName, bool foodGroupFilter, string foodGroup)
        {
            Dictionary<string, RecipeClass> filteredRecipes = new Dictionary<string, RecipeClass>();

            foreach (var recipe in Recipes)
            {
                bool meetsCriteria = true;

                // Apply calorie filter if enabled
                if (caloriesFilter)
                {
                    double recipeCalories = recipe.CalcCalorieTotal();
                    if (recipeCalories > maximumCalories)
                    {
                        meetsCriteria = false; // Exclude recipe if calorie limit exceeded
                    }
                }

                // Apply ingredient filter if enabled
                if (ingredientFilter && meetsCriteria)
                {
                    if (!recipe.Ingredients.Any(i => i.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase)))
                    {
                        meetsCriteria = false; // Exclude recipe if ingredient not found
                    }
                }

                // Apply food group filter if enabled
                if (foodGroupFilter && meetsCriteria)
                {
                    if (!recipe.Ingredients.Any(i => i.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase)))
                    {
                        meetsCriteria = false; // Exclude recipe if food group not found
                    }
                }

                if (meetsCriteria)
                {
                    filteredRecipes.Add(recipe.RecipeName, recipe); // Add recipe to filtered dictionary if it meets all criteria
                }
            }

            return filteredRecipes;
        }
    }



        // Class representing a recipe
        public class Recipe
    {
        public string RecipeName { get; set; }
        public string IngredientName { get; set; }

        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

}

