using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROG6221_POE_ST10029256
{
    public class Steps_class
    {
        /// <summary>
        /// This will hold the step
        /// </summary>
        public string ingredientSteps = string.Empty;

        /// <summary>
        /// this will hold the number of steps
        /// </summary>
        public int numberOfSteps { get; private set; } = 0; 

        /// <summary>
        /// Default constructor
        /// </summary>

        public Steps_class() 
        { 
        
        }

        /// <summary>
        /// This method asks the user to enter the number of steps and if the user input is a string
        /// the text will turn red and ask the user to re-ener with an integer
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfSteps()
        {

            
            Console.Write("Enter number of steps: ");
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
                        this.numberOfSteps = num;
                        reloop = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Re-enter number of steps: ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        input = Console.ReadLine();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }

            } while (reloop == false);


            return this.numberOfSteps;
        }

        /// <summary>
        /// This method gets the users input 
        /// </summary>
        /// <param name="counter"></param>
        /// <returns></returns>
        public string GetIngredientSteps(int counter)
        {
            Console.Write("Step " +  counter + ": ");
            string step = Console.ReadLine();

            bool reloop = false;

            //this do while loop will run until the user enters a string

            do
            {
                try
                {

                    if ((!step.Equals(null)) && (!step.Equals(string.Empty))) //Checks if the string is not empty and not null
                    {
                        this.ingredientSteps = step;
                        reloop = true;
                    }
                    else
                    {
                        Console.Write("Step " + counter + ": ");
                        step = Console.ReadLine();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }

            } while (reloop == false);

            return this.ingredientSteps;
        }
    }
}
