using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.numberOfSteps = Convert.ToInt32(Console.ReadLine());

            return this.numberOfSteps;
        }

        public string GetIngredientSteps(int counter)
        {
            Console.Write("\r\nStep " +  counter + ":");
            this.ingredientSteps = Console.ReadLine();

            return this.ingredientSteps;
        }
    }
}
