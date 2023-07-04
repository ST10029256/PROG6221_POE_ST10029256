using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROG_Part3;

namespace PROG_Part3
{
    public class RecipeClass
    {
        private List<IngredientClass> ingredientsClass;  // Private field to store the list of ingredients

        private List<string> steps { get; set; }  // Private property to store the list of steps

        private double scale = 1;  // Private field to store the scale of the recipe

        public List<string> Steps { get; set; }  // Public property to access the list of steps

        public double Scale { get => scale; set => scale = value; }  // Public property to access and modify the scale of the recipe

        public List<string> StepsList { get; set; }  // Public property to access and modify the list of steps

        public string RecipeName { get; set; }  // Public property to store the name of the recipe

        public List<Ingredient> Ingredients { get; set; }  // Public property to access and modify the list of ingredients

        public RecipeClass(string recipeName)
        {
            RecipeName = recipeName;
            Ingredients = new List<Ingredient>();  // Initialize the list of ingredients
            Steps = new List<string>();  // Initialize the list of steps
        }

        public RecipeClass(List<IngredientClass> ingredientsClass, List<string> steps, double scale)
        {
            this.ingredientsClass = ingredientsClass;  // Set the private field 'ingredients' to the provided list of ingredients
            this.steps = steps;  // Set the private property 'steps' to the provided list of steps
            this.scale = scale;  // Set the private field 'scale' to the provided scale
        }

        public void resetToOriginalSize()
        {
            double prevSize = this.scale;

            foreach (IngredientClass scaledIngredient in this.ingredientsClass)
            {
                scaledIngredient.resetIngredientValues(prevSize);  // Reset the values of each ingredient based on the previous scale
            }
        }


        public double calcCalorieTotal(List<IngredientClass> ingredient)
        {
            if (ingredient == null || ingredient.Count == 0)
            {
                return -1;  // If the list of ingredients is empty or null, return -1
            }

            double totalCalories = 0;

            foreach (var I in ingredientsClass)
            {
                if (I.Calories <= 0)
                {
                    return -1;  // If any ingredient has negative or zero calories, return -1
                }

                totalCalories += I.Calories;  // Calculate the total calories by summing the calories of each ingredient
            }

            return totalCalories;
        }

        public string calcCalorieRange(double totalCalories)
        {
            string selectedRange = "";

            if (totalCalories < 150)
            {
                selectedRange = "less than 150 calories";
            }
            else if (totalCalories <= 450)
            {
                selectedRange = "150-450 calories";
            }
            else if (totalCalories <= 600)
            {
                selectedRange = "450-750 calories";
            }
            else
            {
                selectedRange = "greater than 750 calories";
            }

            return neatCalorieInfoFormat(totalCalories, selectedRange);
        }

        public string neatCalorieInfoFormat(double totalCalories, string range)
        {
            return $"{range}\n{calorieRanges[range]}";  // Return a formatted string with the selected calorie range and its corresponding information
        }

        // A dictionary that maps calorie ranges to their information
        private readonly Dictionary<string, string> calorieRanges = new Dictionary<string, string>
        {
          { "0 - 150 calories", "This range of calories is perfect for snacks, as this is\nlow in calories and are often comprised of light, nutrient\ndense foods such as fruits, vegetables and low-fat dairy\nproducts. This is suitable for those who are closely\nmonitoring their calorie intake or looking for minimal\ncalorie options." },
          { "150 - 450 calories", "This range of calories is perfect for breakfast options\nas this is lower in calories and are suitable for those\nwho prefer a lighter start to their day. This can include\nchoices like a small serving of fruit, a cup of yogurt\na slice of toast with a light spread (e.g., jam, peanut\nbutter), a boiled egg, or a small bowl of oatmeal with\ntoppings." },
          { "450 - 750 calories", "This range of calories is perfect for lunch options\nthis is on the lower end of the calorie spectrum and are\nsuitable for those who prefer a lighter midday meal. This\ncan include choices like a small salad with lean protein,\na cup of soup with whole-grain crackers, a small sandwich\nwith turkey or chicken, a small wrap with vegetarian\nfillings, or a small sushi roll." },
          { "Greater than 750 calories", "This range of calories is perfect for dinner options, as\nthis is on the lower end of the calorie spectrum and are\nsuitable for those who prefer a lighter evening meal. This\ncan include choices like a vegetable stir-fry with tofu, a\nsmall serving of fish or chicken with steamed vegetables,\nsmall portion of vegetarian curry with whole-grain rice, a\nsmall bowl of soup with added protein and vegetables, or a\nvegetable-based pasta dish with a light sauce." }
        };

        public void Size(double newScale)
        {
            if (newScale == 1)
            {
                this.resetToOriginalSize();
            }
            else
            {
                this.scaleRecipe(newScale);
            }

            this.Scale = newScale;  // Update the scale property with the new scale value
        }

        public void scaleRecipe(double multiplier)
        {
            foreach (IngredientClass originalIngredient in this.ingredientsClass)
            {
                originalIngredient.scaleIngredientValues(multiplier);  // Scale the values of each ingredient based on the multiplier
            }
        }
    }
}
