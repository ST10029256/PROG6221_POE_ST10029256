using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        /// <summary>
        /// This method asks the user to enter the number of ingredients and if the user input is a string
        /// the text will turn red and ask the user to re-ener with an integer
        /// </summary>
        /// <returns></returns>

        public int GetNumberOfIngredients()//1
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Please enter the number of ingredients: ");
            string input = Console.ReadLine();
            int num = 0;
            bool reloop = false;

            //this do while loop will run until the user enters a valid integer

            do
            {
                try
                {

                    if (Int32.TryParse(input, out num))
                    {
                        num = Convert.ToInt32(input);
                        this.numberOfIngredients = num;
                        reloop = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Please re-enter the number of ingredients: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        input = Console.ReadLine();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }

            } while (reloop == false);
     
            return this.numberOfIngredients;
        }

        /// <summary>
        /// This method asks the user to enter a name for the ingredient
        /// </summary>
        /// <returns></returns>
        public string GetingredientName() 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter name of Ingredient: ");
            string name = Console.ReadLine();

            bool reloop = false;

            //this do while loop will run until the user enters a valid string

            do
            {
                try
                {

                    if ((!name.Equals(null)) && (!name.Equals(string.Empty))) //Checks if the string is not empty and not null
                    {
                        this.ingredientName = name;
                        reloop = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Re-enter name of Ingredient: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        name = Console.ReadLine();

                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }

            } while (reloop == false);

            return this.ingredientName;
        }

        /// <summary>
        /// This method asks the user to enter the quantity of the desired ingredient and will only be valid if the user enters
        /// a integer not a string and if the user entrs a string the text will turn red and re-ask the user to enter a integer
        /// </summary>
        /// <returns></returns>
        public float GetQuantityOfIngredient() 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter the quantity of the ingredient: ");
            string quantity = Console.ReadLine();

            float num = 0;
            bool reloop = false;

            //this do while loop will run until the user enters a valid integer

            do
            {
                try
                {

                    if (float.TryParse(quantity, out num))
                    {
                        num = float.Parse(quantity);
                        this.quantityOfIngredient = num;
                        reloop = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Re-enter the quantity of the ingredient: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        quantity = Console.ReadLine();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }

            } while (reloop == false);

            return this.quantityOfIngredient;
        }

        /// <summary>
        /// This method will get the users unit of measurement input and check if the users input is a valid string and within
        /// the units array otherwise the text will turn red by reasking the user to re-enter a string containing the element 
        /// within the array
        /// </summary>
        /// <returns></returns>

        public string GetUnitOfIngredient()
        {
            string[] units = {"cups", "cup", "tablespoons", "tablespoon", "teaspoons" , "teaspoon", "ml", "l", "gallon", "gallons"};

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter the unit of mesurement (ml,l,tablesppon,etc): ");
            string unit = Console.ReadLine();

            bool reloop = false;

            //this do while loop will run until the user enters a valid string containg one of the elements within the array

            do
            {
                try
                {

                    if ((!unit.Equals(null)) && (!unit.Equals(string.Empty))) //Checks if the string is not empty and not null
                    {
                        this.unitOfIngredient = unit;

                        if (units.Contains(unit))
                        {
                            reloop = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Re-enter the unit of mesurement: ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            unit = Console.ReadLine();
                            reloop = false;
                        }
                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Re-enter the unit of mesurement: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        unit = Console.ReadLine();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }

            } while (reloop == false);

            return this.unitOfIngredient;
        }


    }
}
