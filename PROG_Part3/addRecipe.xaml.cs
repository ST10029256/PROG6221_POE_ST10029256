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
            Recipes = new Dictionary<string, RecipeClass>();
            DataContext = this;
            DeleteCommand = new RelayCommand(DeleteIngredient);
            validate = new Validate();
            manageMyRecipes = MyRecipes.manageMyRecipes;
        }

        private ObservableCollection<Ingredient> ingredients;

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientNameTextBox.Text.Trim();
            string quantity = QuantityTextBox.Text.Trim();
            string unitOfMeasurement = UnitOfMeasurementComboBox.SelectedItem?.ToString();
            string calories = CaloriesTextBox.Text.Trim();
            string foodGroup = FoodGroupComboBox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(ingredientName) || string.IsNullOrEmpty(quantity) ||
                string.IsNullOrEmpty(unitOfMeasurement) || string.IsNullOrEmpty(calories) ||
                string.IsNullOrEmpty(foodGroup))
            {
                MessageBox.Show("Error: Please fill in all the input fields.");
                return;
            }

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

            Ingredient ingredient = new Ingredient(ingredientName, ingredientQuantity, unitOfMeasurement, ingredientCalories, foodGroup);

            RecipeClass recipe = manageMyRecipes.GetRecipe("Recipe 1");
            recipe?.Ingredients.Add(ingredient);

            // Update the Recipes dictionary with the modified recipe
            Recipes["Recipe 1"] = recipe;

            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitOfMeasurementComboBox.SelectedItem = null;
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedItem = null;

            RefreshDataGrid(recipe); // Pass the modified recipe to the RefreshDataGrid method

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

                    // Process the ingredients as needed
                }
            }
        }

        private void RefreshDataGrid(RecipeClass recipe)
        {
            if (recipe != null)
            {
                ingredients = new ObservableCollection<Ingredient>(recipe.Ingredients);
                dataGrid.ItemsSource = ingredients;
                CollectionViewSource.GetDefaultView(ingredients).Refresh(); // Refresh the view
            }
        }

        private void DeleteIngredient(object parameter)
        {
            if (parameter is Ingredient ingredient)
            {
                RecipeClass recipe = manageMyRecipes.GetRecipe("Recipe 1");
                recipe?.Ingredients.Remove(ingredient);
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            string stepText = StepsTextBox.Text;

            if (!string.IsNullOrEmpty(stepText))
            {
                RecipeClass recipe = manageMyRecipes.GetRecipe("Recipe 1");
                recipe?.Steps.Add(stepText);

                // Update the Recipes dictionary with the modified recipe
                Recipes["Recipe 1"] = recipe;

                StepsListBox.Items.Add(stepText);
                StepsTextBox.Clear();
            }
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            RecipeNameTextBox.Clear();

            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Error: Please enter a recipe name.");
                return;
            }

            RecipeClass recipe = manageMyRecipes.GetRecipe("Recipe 1");

            if (recipe == null || recipe.Ingredients.Count == 0)
            {
                MessageBox.Show("Error: Please add at least one ingredient to the recipe.");
                return;
            }

            manageMyRecipes.AddRecipe(recipeName, recipe);
        }

        private void CaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(CaloriesTextBox.Text, out _) && !string.IsNullOrEmpty(CaloriesTextBox.Text))
            {
                MessageBox.Show("Error: Invalid input! Please enter a valid number.");
            }
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(QuantityTextBox.Text, out _) && !string.IsNullOrEmpty(QuantityTextBox.Text))
            {
                MessageBox.Show("Error: Invalid input! Please enter a valid number.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            WindowState windowState = Window.GetWindow(this)?.WindowState ?? WindowState.Normal;
            mainWindow.WindowState = windowState;
            Application.Current.MainWindow = mainWindow;
            Window.GetWindow(this)?.Hide();
            mainWindow.Show();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change in the dataGrid, if needed
        }

        private void StepsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle text change in StepsTextBox, if needed
        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change in the StepsListBox, if needed
        }

        private void UnitOfMeasurementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change in the UnitOfMeasurementComboBox, if needed
        }

        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change in the FoodGroupComboBox, if needed
        }

        private void RecipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle text change in RecipeNameTextBox, if needed
        }
    }

    public class Ingredient
    {
        public string RecipeName { get; set; }
        public string IngredientName { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

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

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Validate
    {
        public string IsStringValid(string input)
        {
            return null;
        }

        public string IsDouble(string input)
        {
            return null;
        }
    }
}
