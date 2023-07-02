using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace PROG_Part3
{
    public partial class AddRecipe : UserControl
    {
        public static NavigationService NavigationService { get; set; }
        public ObservableCollection<Ingredient> Recipes { get; set; }

        public ICommand DeleteCommand { get; set; }

        public AddRecipe()
        {
            InitializeComponent();
            Recipes = new ObservableCollection<Ingredient>();
            DataContext = this;

            DeleteCommand = new RelayCommand(DeleteIngredient);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            string ingredientName = IngredientNameTextBox.Text;
            string quantity = QuantityTextBox.Text;
            string unitOfMeasurement = ((ComboBoxItem)UnitOfMeasurementComboBox.SelectedItem)?.Content.ToString();
            string calories = CaloriesTextBox.Text;
            string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem)?.Content.ToString();

            Ingredient ingredient = new Ingredient
            {
                RecipeName = recipeName,
                IngredientName = ingredientName,
                Quantity = quantity,
                UnitOfMeasurement = unitOfMeasurement,
                Calories = calories,
                FoodGroup = foodGroup
            };

            Recipes.Add(ingredient);

            // Clear input fields
            RecipeNameTextBox.Clear();
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitOfMeasurementComboBox.SelectedItem = null;
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedItem = null;
        }

        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteIngredient(object parameter)
        {
            if (parameter is Ingredient ingredient)
            {
                Recipes.Remove(ingredient);
            }
        }

        private void UnitOfMeasurementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changed event
        }

        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changed event
        }

        private void StepsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changed event
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            string stepText = StepsTextBox.Text;

            if (!string.IsNullOrEmpty(stepText))
            {
                StepsListBox.Items.Add(stepText);
                StepsTextBox.Clear();
            }
        }

        public void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveIngredientButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Ingredient
    {
        public string RecipeName { get; set; }
        public string IngredientName { get; set; }
        public string Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string Calories { get; set; }
        public string FoodGroup { get; set; }
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
}
