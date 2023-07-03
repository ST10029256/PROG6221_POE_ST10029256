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
        //public event calorieLimitExceed caloriesExceeded;
        
        private List<IngredientClass> ingredients;

        private List<string> steps { get; set; }

        private double scale = 1;

        public List<string> Steps { get; set; }

        //public List<string> Steps { get => steps; set => steps = value; }

        public double Scale { get => scale; set => scale = value; }

        //public List<IngredientClass> Ingredients { get => ingredients; set => ingredients = value; }

        public List<Ingredient> IngredientsList { get; set; }
        public List<string> StepsList { get; set; }

        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }


        public RecipeClass(string recipeName)
        {
            RecipeName = recipeName;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public RecipeClass(List<IngredientClass> ingredients, List<string> steps, double scale)
        {
            this.ingredients = ingredients;
            this.steps = steps;
            this.scale = scale;
        }

        public void resetToOriginalSize()
        {
            double prevSize = this.scale;

            foreach (IngredientClass scaledIngredient in this.ingredients)
            {
                scaledIngredient.resetIngredientValues(prevSize);
            }
        }

        public double calcCalorieTotal(List<IngredientClass> ingredients)
        {
            if (ingredients == null || ingredients.Count == 0)
            {
                return -1;
            }

            double totalCalories = 0;

            foreach (var ingredient in ingredients)
            {
                if (ingredient.Calories <= 0)
                {
                    return -1;
                }

                totalCalories += ingredient.Calories;
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
            return $"{range}\n{calorieRanges[range]}";
        }

        private readonly Dictionary<string, string> calorieRanges = new Dictionary<string, string>
        {
          { "0 - 150 calories", "This range of calories is perfect for snacks, as this is\nlow in calories and are often comprised of light, nutrient\ndense foods such as fruits, vegetables and low-fat dairy\nproducts. This is suitable for those who are closely\nmonitoring their calorie intake or looking for minimal\ncalorie options." },
          { "150 - 450 calories", "This range of calories is perfect for breakfast options\nas this is lower in calories and are suitable for those\nwho prefer a lighter start to their day. This can include\nchoices like a small serving of fruit, a cup of yogurt\na slice of toast with a light spread (e.g., jam, peanut\nbutter), a boiled egg, or a small bowl of oatmeal with\ntoppings." },
          { "450 - 750 calories", "This range of calories is perfect for lunch options\nthis is on the lower end of the calorie spectrum and are\nsuitable for those who prefer a lighter midday meal. This\ncan include choices like a small salad with lean protein,\na cup of soup with whole-grain crackers, a small sandwich\nwith turkey or chicken, a small wrap with vegetarian\nfillings, or a small sushi roll." },
          { "Greater than 750 calories", "This range of calories is perfect for dinner options, as\nthis is on the lower end of the calorie spectrum and are\nsuitable for those who prefer a lighter evening meal. This\ncan include choices like a vegetable stir-fry with tofu, a\nsmall serving of fish or chicken with steamed vegetables,\nsmall portion of vegetarian curry with whole-grain rice, a\nsmall bowl of soup with added protein and vegetables, or a\nvegetable-based pasta dish with a light sauce." }
        };

        public void changeSize(double newScale)
        {
            if (newScale == 1)
            {
                this.resetToOriginalSize();
            }
            else 
            {
                this.scaleRecipe(newScale);
            }

            this.Scale = newScale;
        }

        public void scaleRecipe(double multiplier)
        {
            foreach (IngredientClass originalIngredient in this.ingredients)
            {
                originalIngredient.scaleIngredientValues(multiplier);
            }

        }
    }
}

