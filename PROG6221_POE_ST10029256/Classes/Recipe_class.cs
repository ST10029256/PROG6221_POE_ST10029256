using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10029256.Classes
{
    public class Recipe_class
    {
        public List<Steps_class> stepsList  =new List<Steps_class>();

        public List<Ingredient_class> ingredientsList =  new List<Ingredient_class>();
        //public List<Recipe_class> recipeList  =new List<Recipe_class>();

        public string RecipeName = string.Empty;
        /// <summary>
        /// Default constructor
        /// </summary>
        public Recipe_class() 
        { 
            
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method asks the user to enter a name for the recipe
        /// </summary>
        /// <returns></returns>
        public string GetRecipeName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter name of recipe: ");
            string name = Console.ReadLine();

            bool reloop = false;

            //this do while loop will run until the user enters a valid string
            do
            {
                try
                {

                    if ((!name.Equals(null)) && (!name.Equals(string.Empty))) //Checks if the string is not empty and not null
                    {
                        this.RecipeName = name;
                        reloop = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Re-enter name of recipe: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        name = Console.ReadLine();

                    }

                }
                // Exception handling
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }

            } while (reloop == false);

            // Returns the recipe name
            return this.RecipeName;
        }
    }
}//----------------------------------------------------END OF FILE------------------------------------------------------------------//
