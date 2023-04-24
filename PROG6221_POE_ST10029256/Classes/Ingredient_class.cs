using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10029256
{
    public class Ingredient_class
    {
        public int numberOfIngredients { get; private set; } = 0;
        public string ingredientName = string.Empty;
        public float quantityOfIngredient = 0.0f;
        public string unitOfIngredient  = string.Empty;
       
        /// <summary>
        /// Default constructor
        /// </summary>
        public Ingredient_class() 
        { 
        
        }

        public int GetNumberOfIngredients()//1
        {

            Console.Write("Please enter the number of ingredients: ");
            this.numberOfIngredients = Convert.ToInt32(Console.ReadLine());

            return this.numberOfIngredients;
        }

        public string GetingredientName() 
        {

            Console.Write("\r\nEnter name of Ingredient: ");
            this.ingredientName = Console.ReadLine();

            return this.ingredientName;
        }

        public float GetQuantityOfIngredient() 
        {

            Console.Write("\r\nEnter the quantity of the ingredient: ");
            this.quantityOfIngredient = float.Parse(Console.ReadLine());

            return this.quantityOfIngredient;
        }

        public string GetUnitOfIngredient()
        {
            Console.Write("\r\nEnter the unit of mesurement: ");
            this.unitOfIngredient= Console.ReadLine();

            return this.unitOfIngredient;
        }


    }
}
