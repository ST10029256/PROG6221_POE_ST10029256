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

        public string ingredientSteps = string.Empty;
        public int numberOfSteps { get; private set; } = 0;

        /// <summary>
        /// Default constructor
        /// </summary>

        public Steps_class() 
        { 
        
        }

        public int GetNumberOfSteps()
        {
            Console.Write("Enter number of steps: ");
            string input = Console.ReadLine();
            int num = 0;
            bool reloop = false;

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

        public string GetIngredientSteps(int counter)
        {
            Console.Write("Step " +  counter + ": ");
            string step = Console.ReadLine();

            bool reloop = false;

            do
            {
                try
                {

                    if ((!step.Equals(null)) && (!step.Equals(string.Empty)))
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
