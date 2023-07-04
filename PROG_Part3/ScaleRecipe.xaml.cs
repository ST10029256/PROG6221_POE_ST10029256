using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using PROG6221_POE_ST10029256;
using PROG6221_POE_ST10029256.Classes;

namespace PROG_Part3
{
    public partial class ScaleRecipe : UserControl
    {
        private Dictionary<string, RecipeClass> Recipes { get; set; }
        private ObservableCollection<IngredientClass> Ingredients { get; set; }
        private ObservableCollection<string> Steps { get; set; }

        public ScaleRecipe()
        {
            InitializeComponent();

            // Initialize properties
            Recipes = new Dictionary<string, RecipeClass>();
            Ingredients = new ObservableCollection<IngredientClass>();
            Steps = new ObservableCollection<string>();

            // Set the data context
            DataContext = this;

            // Retrieve the ingredients and steps from the AddRecipe user control
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                if (mainWindow.Content is AddRecipe addRecipeControl)
                {
                    // Get the ingredients from AddRecipe user control
                    if (addRecipeControl.dataGrid.ItemsSource is ObservableCollection<Ingredient> ingredients)
                    {
                        foreach (Ingredient ingredient in ingredients)
                        {
                            Ingredients.Add(ConvertToIngredientClass(ingredient));
                        }
                    }

                    // Get the steps from AddRecipe user control
                    foreach (var step in addRecipeControl.StepsListBox.Items)
                    {
                        Steps.Add(step.ToString());
                    }
                }
            }

        }

            private void LoadRecipeNames()
        {
            // Retrieve the recipe names from the Recipes dictionary
            var recipeNames = Recipes.Keys.ToList();

            // Clear the Items collection of RecipeNameComboBox
            RecipeNameComboBox.Items.Clear();

            // Load the recipe names into the RecipeNameComboBox
            RecipeNameComboBox.ItemsSource = recipeNames;
        }

        private void LoadRecipeNamesFromDictionary()
        {
            // Retrieve the recipe names from the Recipes dictionary
            var recipeNames = Recipes.Keys.ToList();

            // Clear the Items collection of RecipeNameComboBox
            RecipeNameComboBox.Items.Clear();

            // Load the recipe names into the RecipeNameComboBox
            RecipeNameComboBox.ItemsSource = recipeNames;
        }



        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new MainWindow instance
            MainWindow mainWindow = new MainWindow();

            // Get the current window state
            WindowState windowState = Window.GetWindow(this)?.WindowState ?? WindowState.Normal;

            // Set the new MainWindow's window state to match the current state
            mainWindow.WindowState = windowState;

            // Set the Application's MainWindow to the new MainWindow instance
            Application.Current.MainWindow = mainWindow;

            // Hide the current window and show the new MainWindow
            Window.GetWindow(this)?.Hide();
            mainWindow.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the data grid selection change, if needed
        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the steps list box selection change, if needed
        }

        private void RecipeNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the recipe name selection change
            string selectedRecipeName = RecipeNameComboBox.SelectedItem as string;

            if (selectedRecipeName != null)
            {
                // Get the selected recipe from the Recipes dictionary
                if (Recipes.TryGetValue(selectedRecipeName, out RecipeClass selectedRecipe))
                {
                    // Update the DataGrid and StepsListBox with the selected recipe's ingredients
                    Ingredients.Clear();
                    Steps.Clear();

                    foreach (var ingredient in selectedRecipe.Ingredients)
                    {
                        Ingredients.Add(ingredient);
                    }

                    foreach (string step in selectedRecipe.Steps)
                    {
                        Steps.Add(step);
                    }
                }
            }
        }

        private void ScaleFactorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the scale factor selection change
            string selectedScaleFactor = ScaleFactorComboBox.SelectedItem as string;

            if (selectedScaleFactor != null)
            {
                // Get the selected recipe from the Recipes dictionary
                string selectedRecipeName = RecipeNameComboBox.SelectedItem as string;

                if (selectedRecipeName != null && Recipes.TryGetValue(selectedRecipeName, out RecipeClass selectedRecipe))
                {
                    // Scale the ingredients based on the selected scale factor
                    if (selectedScaleFactor == "Half")
                    {
                        ScaleIngredients(selectedRecipe, 0.5);
                    }
                    else if (selectedScaleFactor == "Double")
                    {
                        ScaleIngredients(selectedRecipe, 2);
                    }
                    else if (selectedScaleFactor == "Triple")
                    {
                        ScaleIngredients(selectedRecipe, 3);
                    }
                    else if (selectedScaleFactor == "Reset")
                    {
                        // Reset the ingredients to their original quantities
                        ResetIngredients(selectedRecipe);
                    }
                }
            }
        }

        private void ScaleIngredients(RecipeClass recipe, double scaleFactor)
        {
            // Scale the quantities of the ingredients based on the given scale factor
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
            }
        }

        private void ResetIngredients(RecipeClass recipe)
        {
            // Reset the quantities of the ingredients to their original values
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        private IngredientClass ConvertToIngredientClass(Ingredient ingredient)
        {
            // Convert the Ingredient object to an IngredientClass object
            return new IngredientClass(ingredient.IngredientName, ingredient.Quantity, ingredient.UnitOfMeasurement, 0, "");
        }
    }
}
