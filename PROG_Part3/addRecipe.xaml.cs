using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PROG_Part3
{
    public partial class AddRecipe : UserControl
    {
        public Dictionary<string, RecipeClass> Recipes { get; set; }

        private Validate validate;
        public ICommand DeleteCommand { get; set; }

        private ManageMyRecipes manageMyRecipes;

        public AddRecipe()
        {
            InitializeComponent();

            // Initialize properties and dependencies
            Recipes = new Dictionary<string, RecipeClass>();
            DataContext = this;
            DeleteCommand = new RelayCommand(DeleteIngredient);
            validate = new Validate();
            manageMyRecipes = MyRecipes.manageMyRecipes;
        }

        private ObservableCollection<Ingredient> ingredients;

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from input fields
            string ingredientName = IngredientNameTextBox.Text.Trim();
            string quantity = QuantityTextBox.Text.Trim();
            string unitOfMeasurement = UnitOfMeasurementComboBox.SelectedItem?.ToString();
            string calories = CaloriesTextBox.Text.Trim();
            string foodGroup = FoodGroupComboBox.SelectedItem?.ToString();

            // Check if any field is empty
            if (string.IsNullOrEmpty(ingredientName) || string.IsNullOrEmpty(quantity) ||
                string.IsNullOrEmpty(unitOfMeasurement) || string.IsNullOrEmpty(calories) ||
                string.IsNullOrEmpty(foodGroup))
            {
                MessageBox.Show("Error: Please fill in all the input fields.");
                return;
            }

            // Parse quantity and calories as double
            if (!double.TryParse(quantity, out double ingredientQuantity))
            {
                MessageBox.Show("Error: Invalid quantity value.");
                return;
            }

            if (!double.TryParse(calories, out double ingredientCalories))
            {
                MessageBox.Show("Error: Invalid calories value.");
                return;
            }

            // Create a new Ingredient instance
            Ingredient ingredient = new Ingredient(ingredientName, ingredientQuantity, unitOfMeasurement, ingredientCalories, foodGroup);

            // Get the RecipeClass object for "Recipe 1"
            RecipeClass recipe = manageMyRecipes.GetRecipe("Recipe 1");

            // Add the ingredient to the recipe's Ingredients collection
            recipe?.Ingredients.Add(ingredient);

            // Update the Recipes dictionary with the modified recipe
            Recipes["Recipe 1"] = recipe;

            // Access the ingredients from the DataGrid and their properties
            if (dataGrid.ItemsSource is ObservableCollection<Ingredient> ingredients)
            {
                foreach (Ingredient ing in ingredients)
                {
                    // Access the individual ingredients and their properties
                    string ingName = ing.IngredientName;
                    double ingQuantity = ing.Quantity;
                    string ingUnit = ing.UnitOfMeasurement;
                    double ingCalories = ing.Calories;
                    string ingFoodGroup = ing.FoodGroup;

                }
            }

            // Refresh the DataGrid with the modified recipe
            RefreshDataGrid(recipe);
            // Clear input fields

            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitOfMeasurementComboBox.SelectedItem = null;
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedItem = null;

        }

        private void RefreshDataGrid(RecipeClass recipe)
        {
            if (recipe != null)
            {
                // Create a new ObservableCollection with the recipe's ingredients
                ingredients = new ObservableCollection<Ingredient>(recipe.Ingredients);

                // Set the DataGrid's ItemsSource to the new ObservableCollection
                dataGrid.ItemsSource = ingredients;

                // Refresh the view to update the DataGrid
                CollectionViewSource.GetDefaultView(ingredients).Refresh();
            }
        }

        private void DeleteIngredient(object parameter)
        {
            // Check if the parameter is an Ingredient object
            if (parameter is Ingredient ingredient)
            {
                // Get the RecipeClass object for "Recipe 1"
                RecipeClass recipe = manageMyRecipes.GetRecipe("Recipe 1");

                // Remove the ingredient from the recipe's Ingredients collection
                recipe?.Ingredients.Remove(ingredient);
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            // Get the step text from the StepsTextBox
            string stepText = StepsTextBox.Text;

            // Check if the step text is not empty
            if (!string.IsNullOrEmpty(stepText))
            {
                // Get the RecipeClass object for "Recipe 1"
                RecipeClass recipe = manageMyRecipes.GetRecipe("Recipe 1");

                // Add the step text to the recipe's Steps collection
                recipe?.Steps.Add(stepText);

                // Update the Recipes dictionary with the modified recipe
                Recipes["Recipe 1"] = recipe;

                // Add the step text to the StepsListBox
                StepsListBox.Items.Add(stepText);

                // Clear the StepsTextBox
                StepsTextBox.Clear();
            }
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the recipe name from the RecipeNameTextBox
            string recipeName = RecipeNameTextBox.Text;

            // Clear the RecipeNameTextBox
            RecipeNameTextBox.Clear();

            // Check if the recipe name is not empty
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Error: Please enter a recipe name.");
                return;
            }

            // Get the RecipeClass object for "Recipe 1"
            RecipeClass recipe = manageMyRecipes.GetRecipe("Recipe 1");

            // Check if the recipe is valid (contains at least one ingredient)
            if (recipe == null || recipe.Ingredients.Count == 0)
            {
                MessageBox.Show("Error: Please add at least one ingredient to the recipe.");
                return;
            }

            // Add the recipe to the ManageMyRecipes instance
            manageMyRecipes.AddRecipe(recipeName, recipe);
        }

        private void CaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle text change in CaloriesTextBox, if needed
            // Check if the input is a valid double value
            if (!double.TryParse(CaloriesTextBox.Text, out _) && !string.IsNullOrEmpty(CaloriesTextBox.Text))
            {
                MessageBox.Show("Error: Invalid input! Please enter a valid number.");
            }
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle text change in QuantityTextBox, if needed
            // Check if the input is a valid double value
            if (!double.TryParse(QuantityTextBox.Text, out _) && !string.IsNullOrEmpty(QuantityTextBox.Text))
            {
                MessageBox.Show("Error: Invalid input! Please enter a valid number.");
            }
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

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StepsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UnitOfMeasurementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RecipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class Ingredient
    {
        // Properties of the Ingredient class
        public string RecipeName { get; set; }
        public string IngredientName { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor for creating an Ingredient object
        public Ingredient(string ingredientName, double quantity, string unitOfMeasurement, double calories, string foodGroup)
        {
            IngredientName = ingredientName;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        // Event for handling changes in the ability to execute the command
        public event EventHandler CanExecuteChanged;

        // Constructor for creating a RelayCommand object
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        // Determines whether the command can be executed
        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        // Executes the command
        public void Execute(object parameter)
        {
            execute(parameter);
        }

        // Raises the CanExecuteChanged event
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Validate
    {
        // Validates a string input (not implemented)
        public string IsStringValid(string input)
        {
            return null;
        }

        // Validates a double input (not implemented)
        public string IsDouble(string input)
        {
            return null;
        }
    }
}
