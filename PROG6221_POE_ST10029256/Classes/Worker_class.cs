using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public float[] resetIngredientQuantity;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Worker_class() 
        { 
        
        }

        public void StoreDataInArray()
        {
            int numberOfIngredients = ingredients.GetNumberOfIngredients();
            ingredientsArray = new Ingredient_class[numberOfIngredients];
            resetIngredientQuantity = new float[numberOfIngredients]; 

            for (int i = 0; i < ingredientsArray.Length; i++)
            {
                ingredientsArray[i] = new Ingredient_class();
                ingredientsArray[i].quantityOfIngredient = ingredients.GetQuantityOfIngredient();
                resetIngredientQuantity[i] = ingredientsArray[i].quantityOfIngredient;
                ingredientsArray[i].unitOfIngredient = ingredients.GetUnitOfIngredient();
                ingredientsArray[i].ingredientName = ingredients.GetingredientName();

                Console.WriteLine("---------------------------------");

            }

            stepsArray = new Steps_class[steps.GetNumberOfSteps()];

            for (int j = 0; j < stepsArray.Length; j++)
            {

                stepsArray[j] = new Steps_class();
                stepsArray[j].ingredientSteps = steps.GetIngredientSteps(j+1);

            }


        }

        public float ScalingCalc(int i, int num)
        {
            
            var half = 0.5f;
            int double1 = 2;
            int tripple = 3;
            float final = 0.0f;

            if(num == 1)
            {       
                final = half * ingredientsArray[i].quantityOfIngredient;
            }
            else
            {
                if(num == 2)
                {
                    final = double1 * ingredientsArray[i].quantityOfIngredient;
                }
                else
                {
                    if(num == 3)
                    {
                        final = tripple * ingredientsArray[i].quantityOfIngredient;
                    }
                    else 
                    { 

                    }
                }
            }

            return final;
        }

        /// <summary>
        /// Scaling half, double or tripple
        /// </summary>
        public void Scaling()
        {
            int num = 0;
            var choice = string.Empty;

            Console.Write("Would youlike to scale your recipe? (YES/NO): ");
            choice =  (Console.ReadLine()).ToUpper();

            if(choice == "YES")
            {
                Console.WriteLine("Please choose one of the following by entering the number: ");
                Console.WriteLine("1: (Half) ");
                Console.WriteLine("2: (Double) ");
                Console.WriteLine("3: (Tripple) ");
                Console.WriteLine("4: (Reset) ");
                num = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < ingredientsArray.Length; i++)
                {
                    switch (num)
                    {
                        case 1:
                            ingredientsArray[i].quantityOfIngredient = ScalingCalc(i, num);
                            break;

                        case 2:
                            ingredientsArray[i].quantityOfIngredient = ScalingCalc(i, num);
                            break;

                        case 3:
                            ingredientsArray[i].quantityOfIngredient = ScalingCalc(i, num);
                            break;

                        case 4:
                            ingredientsArray[i].quantityOfIngredient = resetIngredientQuantity[i];
                            break;

                        default:
                            Console.WriteLine();
                            break;

                    }
                }

            }
            else
            {
                Display();
            }

        }

        /// <summary>
        /// method will display user input
        /// </summary>
        public void Display()
        {

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Ingredients:\r\n");

            for (int i = 0; i < ingredientsArray.Length; i++)
            {

                Console.WriteLine(ingredientsArray[i].quantityOfIngredient + " " + ingredientsArray[i].unitOfIngredient +
                    " of " + ingredientsArray[i].ingredientName);
            }

            Console.WriteLine();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Steps:\r\n");

            for (int j = 0; j < stepsArray.Length; j++)
            {
                Console.WriteLine((j + 1) + ". " +  stepsArray[j].ingredientSteps);
            }

            Console.ReadLine();

        }
    }
}
