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
        public ObservableCollection<Recipe> Recipes { get; set; }

        public SearchForRecipe()
        {
            InitializeComponent();
            Recipes = new ObservableCollection<Recipe>();
            // Assuming you have the list of recipes available
            GetRecipes(); // Replace GetRecipes() with your actual logic to retrieve the list of Recipe objects
            UpdateDataGrid();
        }

        private void IngredientNameSearch_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientName2TextBox.Text;
            List<Recipe> filteredRecipes = Recipes.Where(r => r.IngredientName.Contains(ingredientName)).ToList();
            UpdateDataGrid(filteredRecipes);
        }

        private void FoodGroupComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event here
            // You can access the selected item using FoodGroup2ComboBox.SelectedItem
        }

        private void CaloriesSearch_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Calories2TextBox.Text, out int calories))
            {
                List<Recipe> filteredRecipes = Recipes.Where(r => r.Calories <= calories).ToList();
                UpdateDataGrid(filteredRecipes);
            }
            else
            {
                MessageBox.Show("Please enter a valid integer for Calories.");
            }
        }

        private void FoodGroupSearch_Click(object sender, RoutedEventArgs e)
        {
            string selectedFoodGroup = ((ComboBoxItem)FoodGroup2ComboBox.SelectedItem)?.Content.ToString();
            if (selectedFoodGroup != null)
            {
                List<Recipe> filteredRecipes = Recipes.Where(r => r.FoodGroup == selectedFoodGroup).ToList();
                UpdateDataGrid(filteredRecipes);
            }
        }

        private void UpdateDataGrid(List<Recipe> recipes = null)
        {
            dataGrid.ItemsSource = recipes != null ? new ObservableCollection<Recipe>(recipes) : Recipes;
        }

        private void GetRecipes()
        {
            // Replace this with your actual logic to retrieve the list of Recipe objects from the data source
            // For testing purposes, creating a dummy list here
            Recipes.Add(new Recipe { RecipeName = "Recipe 1", IngredientName = "Ingredient A", Calories = 100, FoodGroup = "Group 1" });
            Recipes.Add(new Recipe { RecipeName = "Recipe 2", IngredientName = "Ingredient B", Calories = 200, FoodGroup = "Group 2" });
            Recipes.Add(new Recipe { RecipeName = "Recipe 3", IngredientName = "Ingredient C", Calories = 300, FoodGroup = "Group 1" });
            Recipes.Add(new Recipe { RecipeName = "Recipe 4", IngredientName = "Ingredient D", Calories = 150, FoodGroup = "Group 3" });
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            // Retrieve the stored window state
            WindowState windowState = Window.GetWindow(this)?.WindowState ?? WindowState.Normal;

            // Pass the window state to the MainWindow
            mainWindow.WindowState = windowState;

            Application.Current.MainWindow = mainWindow;
            Window.GetWindow(this)?.Close();
            mainWindow.Show();
        }

        private void BackButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Calories2TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle the text changed event of the TextBox here
            // Add your code to handle the new text value or perform any other actions
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event of the ComboBox here
            // Add your code to handle the selected item or perform any other actions
        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Recipe
    {
        public string RecipeName { get; set; }
        public string IngredientName { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}
