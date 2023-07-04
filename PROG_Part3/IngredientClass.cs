using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROG6221_POE_ST10029256;
using PROG6221_POE_ST10029256.Classes;

namespace PROG_Part3
{
    public class IngredientClass
    {
        // Properties to store ingredient details
        private string name { get; set; }
        private double quantity { get; set; }
        private string unit { get; set; }
        private double calories { get; set; }
        private string foodGroup { get; set; }

        // Instance of the Worker_class from another namespace
        PROG6221_POE_ST10029256.Worker_class worker_Class = new PROG6221_POE_ST10029256.Worker_class();

        // Constructor to initialize the IngredientClass object with provided details
        public IngredientClass(string name, double quantity, string unit, double calories, string foodGroup)
        {
            this.name = name;
            this.quantity = quantity;
            this.unit = convertUnitToStandardFormat(unit);
            this.calories = calories;
            this.foodGroup = foodGroup;
        }

        // Property for accessing and modifying the calorie value
        public double Calories { get => calories; set => calories = value; }

        // Convert the unit of measurement to a standard format
        private string convertUnitToStandardFormat(string unit)
        {
            // Lists of unit inputs for different measurements
            List<string> mlInputs = new List<string> { "ml" };
            List<string> litreInputs = new List<string> { "l" };
            List<string> teaspoonInputs = new List<string> { "teaspoon", "teaspoons" };
            List<string> tablespoonInputs = new List<string> { "tablespoon", "tablespoons" };
            List<string> cupInputs = new List<string> { "cup", "cups" };
            List<string> gallonInputs = new List<string> { "gallon", "gallons" };

            // Convert the unit to a standard format based on the input lists
            if (mlInputs.Contains(unit.ToLower()))
            {
                unit = "ml";
            }
            else if (litreInputs.Contains(unit.ToLower()))
            {
                unit = "l";
            }
            else if (teaspoonInputs.Contains(unit.ToLower()))
            {
                unit = "teaspoon";
            }
            else if (tablespoonInputs.Contains(unit.ToLower()))
            {
                unit = "tablespoon";
            }
            else if (cupInputs.Contains(unit.ToLower()))
            {
                unit = "cup";
            }
            else if (gallonInputs.Contains(unit.ToLower()))
            {
                unit = "gallon";
            }

            return unit;
        }

        // Scale the ingredient values based on a multiplier
        public void scaleIngredientValues(double multiplier)
        {
            scaleQuantitiesOfIngredients(multiplier);
            simplifyUnitOfMeasurement();
            scaleCalories(multiplier);
        }

        // Scale the quantities of ingredients by a multiplier
        public void scaleQuantitiesOfIngredients(double multiplier)
        {
            this.quantity *= multiplier;
        }

        // Simplify the unit of measurement by converting to a higher unit if possible
        public void simplifyUnitOfMeasurement()
        {
            if (this.unit == "teaspoon")
            {
                if (this.quantity % 3 == 0)
                {
                    this.quantity = this.quantity / 3;
                    this.unit = "Tablespoon";
                }
            }
            else if (this.unit == "tablespoon")
            {
                if (this.quantity % 16 == 0)
                {
                    this.quantity = this.quantity / 16;
                    this.unit = "cup";
                }
            }
            else if (this.unit == "cup")
            {
                if (this.quantity % 4 == 0)
                {
                    this.quantity = this.quantity / 4;
                    this.unit = "l";
                }
            }
            else if (this.unit == "l")
            {
                if (this.quantity % 3.78 == 0)
                {
                    this.quantity = this.quantity / 3.78;
                    this.unit = "gallon";
                }
            }
            else if (this.unit == "ml")
            {
                if (this.quantity % 1000 == 0)
                {
                    this.quantity = this.quantity / 3785.41;
                    this.unit = "gallon";
                }
            }
        }

        // Scale the calories by a multiplier
        public void scaleCalories(double multiplier)
        {
            this.Calories *= multiplier;
        }

        // Reset the ingredient values based on a scale
        public void resetIngredientValues(double scale)
        {
            resetUnitOfMeasurement();
            resetQuantity(scale);
            resetCalories(scale);
        }

        // Reset the unit of measurement to a lower unit if possible
        public void resetUnitOfMeasurement()
        {
            if (this.unit == "tablespoon")
            {
                this.quantity = this.quantity * 3;
                this.unit = "teaspoon";
            }
            else if (this.unit == "cup")
            {
                this.quantity = this.quantity * 16;
                this.unit = "tablespoon";
            }
            else if (this.unit == "l")
            {
                this.quantity = this.quantity * 4;
                this.unit = "cup";
            }
            else if (this.unit == "gallon")
            {
                this.quantity = this.quantity * 3.78;
                this.unit = "l";
            }
            else if (this.unit == "gallon")
            {
                this.quantity = this.quantity * 3785.41;
                this.unit = "ml";
            }
        }

        // Reset the quantity based on a scale
        public void resetQuantity(double scale)
        {
            if (scale == 0.5)
            {
                this.quantity = this.quantity * 2;
            }
            else if (scale == 2 || scale == 3)
            {
                this.quantity = this.quantity / scale;
            }
        }

        // Reset the calories based on a scale
        public void resetCalories(double scale)
        {
            if (scale == 0.5)
            {
                this.calories *= 2;
            }
            else if (scale == 2 || scale == 3)
            {
                this.calories /= scale;
            }
        }

        // Dictionary containing food group options with their descriptions
        public static readonly Dictionary<int, (string, string)> FoodGroupsOptions = new Dictionary<int, (string, string)>
        {
            { 1, ("Starchy foods", "Starchy foods include carbohydrates that provide energy and are typically rich in complex carbohydrates, \nfiber, vitamins, and minerals. Examples include grains (rice, wheat, oats), bread, pasta, cereals, potatoes, corn, \nand other starchy vegetables. They form an important part of a balanced diet and are a source of sustained energy.") },
            { 2, ("Vegetables and fruits", "Vegetables and fruits are essential for a well-rounded diet, providing a wide range of vitamins, \nminerals, fiber, and antioxidants. They are low in calories and high in nutrients, offering various health benefits. \nExamples include leafy greens, broccoli, carrots, tomatoes, berries, apples, oranges, and bananas.") },
            { 3, ("Dry beans, peas, lentils, and soya", "This food group consists of legumes, which are excellent sources of plant-based protein, \nfiber, vitamins, and minerals. They include foods like beans (black beans, kidney beans), lentils, chickpeas, \npeas, and soybeans. Legumes are versatile ingredients and can be used in various dishes.") },
            { 4, ("Chicken, fish, meat, and eggs", "This food group encompasses animal-based protein sources. Chicken, fish, lean meat, and eggs \nare rich in protein, vitamins (such as B vitamins), minerals (like iron and zinc), and essential fatty acids. \nThey provide the building blocks for tissue repair, growth, and overall maintenance of the body.") },
            { 5, ("Milk and dairy products", "This group includes milk, yogurt, cheese, and other dairy products. They are excellent sources of \ncalcium, protein, and other essential nutrients like vitamin D. Dairy products contribute to bone health, muscle \nfunction, and overall growth and development.") },
            { 6, ("Fats and oils", "Fats and oils are concentrated sources of energy and provide essential fatty acids that are important for \nvarious bodily functions. They include sources like oils (olive oil, coconut oil), butter, margarine, nuts, seeds, \nand avocados. It's important to consume them in moderation and choose healthier options, focusing on unsaturated fats.") },
            { 7, ("Water", "While not a food group, water is vital for hydration and overall well-being. It helps maintain bodily functions, \nregulate body temperature, and support digestion. It's recommended to drink an adequate amount of water throughout \nthe day to stay hydrated.") }
        };
    }
}
