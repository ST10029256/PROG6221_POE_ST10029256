using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10029256
{
    public class Worker_class
    {
        public Ingredient_class ingredients = new Ingredient_class();
        
        public Steps_class steps = new Steps_class();

        public Ingredient_class[] ingredientsArray;

        public Steps_class[] stepsArray;

        public int listerner;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Worker_class() 
        { 
        
        }

        public void StoreDataInArray()
        {
            ingredientsArray = new Ingredient_class[ingredients.GetNumberOfIngredients()];

            for (int i = 0; i < ingredientsArray.Length; i++)
            {
                ingredientsArray[i] = new Ingredient_class();
                ingredientsArray[i].quantityOfIngredient = ingredients.GetQuantityOfIngredient();
                ingredientsArray[i].unitOfIngredient = ingredients.GetUnitOfIngredient();
                ingredientsArray[i].ingredientName = ingredients.GetingredientName();

            }

            stepsArray = new Steps_class[steps.GetNumberOfSteps()];

            for (int j = 0; j < stepsArray.Length; j++)
            {

                stepsArray[j] = new Steps_class();
                stepsArray[j].ingredientSteps = steps.GetIngredientSteps(j+1);

            }


        }

        /// <summary>
        /// method will display user input
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < ingredientsArray.Length; i++)
            {
                Console.WriteLine(ingredientsArray[i].quantityOfIngredient+" "+ ingredientsArray[i].unitOfIngredient+
                    " of " + ingredientsArray[i].ingredientName);
            }

            Console.WriteLine();

            for (int j = 0; j < stepsArray.Length; j++)
            {
                Console.WriteLine((j + 1) + "\t" + stepsArray[j].ingredientSteps);
            }

            Console.ReadLine();

        }
    }
}
