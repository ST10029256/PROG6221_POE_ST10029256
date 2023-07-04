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

        // Event handler for IngredientNameSearch button click
        private void IngredientNameSearch_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientName2TextBox.Text;
            List<Recipe> filteredRecipes = Recipes.Where(r => r.IngredientName.Contains(ingredientName)).ToList();  // Filter recipes based on the ingredient name
            UpdateDataGrid(filteredRecipes);  // Update the data grid with the filtered recipes
        }

        // Event handler for FoodGroupComboBox selection changed event
        private void FoodGroupComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // No implementation provided
        }

        // Event handler for CaloriesSearch button click
        private void CaloriesSearch_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Calories2TextBox.Text, out int calories))
            {
                List<Recipe> filteredRecipes = Recipes.Where(r => r.Calories <= calories).ToList();  // Filter recipes based on calories
                UpdateDataGrid(filteredRecipes);  // Update the data grid with the filtered recipes
            }
            else
            {
                MessageBox.Show("Please enter a valid integer for Calories.");  // Show error message for invalid input
            }
        }

        // Event handler for FoodGroupSearch button click
        private void FoodGroupSearch_Click(object sender, RoutedEventArgs e)
        {
            string selectedFoodGroup = ((ComboBoxItem)FoodGroup2ComboBox.SelectedItem)?.Content.ToString();
            if (selectedFoodGroup != null)
            {
                List<Recipe> filteredRecipes = Recipes.Where(r => r.FoodGroup == selectedFoodGroup).ToList();  // Filter recipes based on selected food group
                UpdateDataGrid(filteredRecipes);  // Update the data grid with the filtered recipes
            }
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

        private void Calories2TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
