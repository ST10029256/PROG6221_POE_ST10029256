using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CaloriesUnitTest;
using PROG6221_POE_ST10029256;
using System.Collections.Generic;

namespace CaloriesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ///In the summary comments, include what the test will be testing, why it is tested  (what will happen if it is not tested, importance), what the output must be
        [TestMethod]
        public void CalcTotalCalories_WithEmptyList_ReturnsZero()
        {
            //  Create an empty list of recipesIngredientsList
            List<List<Ingredient_class>> recipesIngredientsList = new List<List<Ingredient_class>>();

            // Create an instance of Worker_class
            Worker_class calculator = new Worker_class();

            // Call the CalcTotalCalories method with the empty list
            double result = calculator.CalcTotalCalories(recipesIngredientsList);

            // Check if the result is equal to 0
            Assert.AreEqual(0, result);
        }
//-------------------------------------------------------------------------------------------------------------------------//
        [TestMethod]
        public void CalcTotalCalories_WithPositiveCalories_ReturnsCorrectTotal()
        {
            // Create a list of recipesIngredientsList with positive calories
            List<List<Ingredient_class>> recipesIngredientsList = new List<List<Ingredient_class>>
        {
            // Create a list of recipesIngredientsList with positive calories
            new List<Ingredient_class>
            {
                new Ingredient_class { ingredientName = "Cake", numberOfCalories = 10 },
                new Ingredient_class { ingredientName = "Pizza", numberOfCalories = 150 }
            },
            // Create a list of recipesIngredientsList with positive calories
            new List<Ingredient_class>
            {
                new Ingredient_class { ingredientName = "Pasta", numberOfCalories = 50 }
            }
        };

            // Create an instance of Worker_class
            Worker_class calculator = new Worker_class();

            // Call the CalcTotalCalories method with the list of recipesIngredientsList
            double result = calculator.CalcTotalCalories(recipesIngredientsList);

            // Check if the result is equal to 210
            Assert.AreEqual(210, result);
        }
//-------------------------------------------------------------------------------------------------------------------------//
        [TestMethod]
        public void CalcTotalCalories_WithNegativeCalories_ReturnsZero()
        {
            // Create a list of recipesIngredientsList with negative calories
            List<List<Ingredient_class>> recipesIngredientsList = new List<List<Ingredient_class>>
        {
            // Create a list of ingredients for the recipe
            new List<Ingredient_class>
            {
                new Ingredient_class { ingredientName = "Bread", numberOfCalories = -50 },
                new Ingredient_class { ingredientName = "Cupcakes", numberOfCalories = 100 }
            }
        };

            // Create an instance of Worker_class
            Worker_class calculator = new Worker_class();

            // Call the CalcTotalCalories method with the list of recipesIngredientsList
            double result = calculator.CalcTotalCalories(recipesIngredientsList);

            // Check if the result is equal to 100
            Assert.AreEqual(100, result);
        }
    }
}//----------------------------------------------------END OF FILE------------------------------------------------------------------//
