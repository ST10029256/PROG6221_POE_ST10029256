using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PROG_Part3
{
    public partial class addRecipe : UserControl
    {
        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public addRecipe()
        {
            InitializeComponent();
            Ingredients = new ObservableCollection<Ingredient>();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Add button click logic here
            string recipeName = RecipeNameTextBox.Text;
            string ingredientName = IngredientNameTextBox.Text;
            string quantity = QuantityTextBox.Text;
            string unitOfMeasurement = (UnitOfMeasurementComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string calories = CaloriesTextBox.Text;
            string foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            Ingredient ingredient = new Ingredient()
            {
                RecipeName = recipeName,
                IngredientName = ingredientName,
                Quantity = quantity,
                UnitOfMeasurement = unitOfMeasurement,
                Calories = calories,
                FoodGroup = foodGroup
            };

            Ingredients.Add(ingredient);

            // Clear input fields
            RecipeNameTextBox.Clear();
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitOfMeasurementComboBox.SelectedIndex = -1;
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedIndex = -1;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Delete ingredient button click logic here
            if (sender is Button button && button.DataContext is Ingredient ingredient)
            {
                Ingredients.Remove(ingredient);
            }
        }

        private void AddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Add new recipe button click logic here
            RecipeNameTextBox.Clear();
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitOfMeasurementComboBox.SelectedIndex = -1;
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedIndex = -1;
        }

        private void UnitOfMeasurementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // UnitOfMeasurementComboBox selection changed logic here
        }

        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // FoodGroupComboBox selection changed logic here
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event for the first ComboBox
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event for the second ComboBox
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
}
