using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROG6221_POE_ST10029256
{
    public class Ingredient_class
    {
        // Number of ingredients (initialized to 0)
        public int numberOfIngredients { get; private set; } = 0;

        // Name of the ingredient
        public string ingredientName = string.Empty;

        // Quantity of the ingredient
        public float quantityOfIngredient = 0.0f;

        // Unit of measurement for the ingredient
        public string unitOfIngredient = string.Empty;

        // Number of calories in the ingredient
        public double numberOfCalories = 0.0f;

        // Food group of the ingredient
        public string FoodGroup { get; set; } = string.Empty;

        // A copy of the quantity of the ingredient
        public float CopyOfQuantityOfIngredient = 0.0f;

        // A copy of the unit of measurement
        public string CopyOfUnitOfIngredient = string.Empty;

        // A copy of the number of calories
        public double CopyOfNnumberOfCalories = 0.0f;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Ingredient_class()
        {

        }
        //-------------------------------------------------------------------------------------------------------------------------//
        public List<string> FoodGroups { get; set; } = new List<string>
        {
            "Starchy foods",
            "Vegetables and fruits",
            "Dry beans, peas, lentils and soya",
            "Chicken, fish, meat and eggs",
            "Milk and dairy products",
            "Fats and oil",
            "Water"
        };
        //-------------------------------------------------------------------------------------------------------------------------//
        public string GetFoodGroup()

        {
            bool reloop = false;
            string input = string.Empty;
            int index = 0; // Index of the selected food group

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please select a food group from the list below: ");

            do
            {
                for (int i = 0; i < FoodGroups.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + FoodGroups[i]);
                }

                Console.WriteLine((FoodGroups.Count + 1) + ". " + "More information on a specific food group");
                Console.Write(">");
                
                // Read user input
                input = Console.ReadLine();

                // Check if the input is a valid integer
                if (int.TryParse(input, out int choice))
                {
                    
                    if ((choice >= 1 && choice <= FoodGroups.Count) && (FoodGroups.Count >= 0 && index < FoodGroups.Count))
                    {
                        // Update the index based on the user's choice
                        index = choice - 1;

                        // Exit the loop
                        reloop = true;

                        // Store the selected food group
                        FoodGroup = FoodGroups[index];
                    }
                    else
                    {
                        if (choice == FoodGroups.Count + 1)
                        {
                            // Exit the loop
                            reloop = true;

                            // Display more information on a specific food group
                            DisplayFoodGroupInformation();
                        }
                        else
                        {
                            // Continue the loop if the choice is invalid
                            reloop = false;
                        }
                    }
                }
                if (reloop == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;

                    // Prompt the user to re-select a food group
                    Console.WriteLine("Please re-select a food group from the list below: ");
                }

            } while (reloop == false);

            // Return the selected food group
            return FoodGroup;
        }
        //-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method asks the user to enter the number of ingredients and if the user input is a string
        /// the text will turn red and ask the user to re-ener with an integer
        /// </summary>
        public double GetNumberOfCalories()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Please enter the number of Calories: ");
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
                        this.numberOfCalories = num;
                        reloop = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Please re-enter the number of Calories: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        input = Console.ReadLine();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }

            } while (reloop == false);

            return this.numberOfCalories;
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method will get the number of the ingredients the user enters
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfIngredients()
        {
            Console.Write("Please enter the number of ingredients: ");
            string input = Console.ReadLine();
            int num = 0;
            bool reloop = false;

            //this do while loop will run until the user enters a valid integer
            do
            {
                try
                {

                    if (Int32.TryParse(input, out num) && num > 0)
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
        //-------------------------------------------------------------------------------------------------------------------------//
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
        //-------------------------------------------------------------------------------------------------------------------------//
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
        //-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method will get the users unit of measurement input and check if the users input is a valid string and within
        /// the units array otherwise the text will turn red by reasking the user to re-enter a string containing the element 
        /// within the array
        /// </summary>
        /// <returns></returns>
        public string GetUnitOfIngredient()
        {
            string[] units = { "cups", "cup", "tablespoons", "tablespoon", "teaspoons", "teaspoon", "ml", "l", "gallon", "gallons" };

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter the unit of mesurement (ml,l,tablesppon,etc): ");
            string unit = Console.ReadLine();

            bool reloop = false;

            //this do while loop will run until the user enters a valid string containg one of the elements within the array
            do
            {
                try
                {
                    //Checks if the string is not empty and not null
                    if ((!unit.Equals(null)) && (!unit.Equals(string.Empty)))
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
        //-------------------------------------------------------------------------------------------------------------------------//
        private void DisplayFoodGroupInformation()
        {
            bool reloop = false;
            string input = string.Empty;
            int index = 0;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please select a food group from the list below to view: ");

            do
            {
                for (int i = 0; i < FoodGroups.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + FoodGroups[i]);
                }

                Console.WriteLine((FoodGroups.Count + 1) + ". " + "Back");
                Console.Write(">");

                input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= FoodGroups.Count)
                    {
                        index = choice - 1;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        switch (index)
                        {
                            case 0://this will be Starchy foods

                                Console.WriteLine("Starchy foods: Starchy foods include carbohydrates that \r\n" +
                                                  "provide energy and are typically rich in complex carbohydrates, \r\n" +
                                                  "fiber, vitamins, and minerals. Examples include grains \r\n" +
                                                  "(rice, wheat, oats), bread, pasta, cereals, potatoes, corn, " +
                                                  "and other starchy vegetables. They form an important part \r\n" +
                                                  "of a balanced diet and are a source of sustained energy.");
                                break;
                            case 1: // this will be Vegetables and fruits
                                Console.WriteLine("Vegetables and fruits: Vegetables and fruits are essential \r\n" +
                                                  "for a well-rounded diet, providing a wide range of vitamins, \r\n" +
                                                  "minerals, fiber, and antioxidants. They are low in calories \r\n" +
                                                  "and high in nutrients, offering various health benefits. \r\n" +
                                                  "Examples include leafy greens, broccoli, carrots,tomatoes, \r\n" +
                                                  "berries, apples, oranges, and bananas.");
                                break;
                            case 2://this will be Dry beans, peas, lentils and soya
                                Console.WriteLine("Dry beans, peas, lentils, and soya: This food group consists \r\n" +
                                                  "of legumes, which are excellent sources of plant-based \r\n" +
                                                  "protein, fiber, vitamins, and minerals. They include foods \r\n" +
                                                  "like beans (black beans, kidney beans), lentils, chickpeas, \r\n" +
                                                  "peas, and soybeans. Legumes are versatile ingredients and can \r\n" +
                                                  "be used in various dishes.");
                                break;
                            case 3://this will be Chicken, fish, meat and eggs
                                Console.WriteLine("Chicken, fish, meat, and eggs: This food group encompasses \r\n" +
                                                  "animal-based protein sources. Chicken, fish, lean meat, and \r\n" +
                                                  "eggs are rich in protein, vitamins (such as B vitamins), \r\n" +
                                                  "minerals (like iron and zinc) and essential fatty acids. \r\n" +
                                                  "They provide the building blocks for tissue repair, growth, \r\n" +
                                                  "and overall maintenance of the body.");
                                break;
                            case 4://this will be Milk and dairy products
                                Console.WriteLine("Milk and dairy products: This group includes milk, yogurt, \r\n" +
                                                  "cheese, and other dairy products. They are excellent sources \r\n" +
                                                  "of calcium, protein, and other essential nutrients like \r\n" +
                                                  "vitamin D. Dairy products contribute to bone health, muscle \r\n" +
                                                  "function, and overall growth and development.");
                                break;
                            case 5://this will be  Fats and oil
                                Console.WriteLine("Fats and oils: Fats and oils are concentrated sources of \r\n" +
                                                  "energy and provide essential fatty acids that are important \r\n" +
                                                  "for various bodily functions. They include sources like oils \r\n" +
                                                  "(olive oil, coconut oil), butter, margarine, nuts, seeds, \r\n" +
                                                  "and avocados. It's important to consume them in moderation \r\n" +
                                                  "and choose healthier options, focusing on unsaturated fats.");
                                break;
                            case 6://this will be Water
                                Console.WriteLine("Water: While not a food group, water is vital for hydration \r\n" +
                                                  "and overall well-being. It helps maintain bodily functions, \r\n" +
                                                  "regulate body temperature, and supports digestion. It's \r\n" +
                                                  "recommended to drink an adequate amount of water throughout \r\n" +
                                                  "the day to stay hydrated.");
                                break;
                        }

                        Console.ForegroundColor = ConsoleColor.Magenta;

                        reloop = true;
                    }
                    else
                    {
                        if (choice == FoodGroups.Count + 1)
                        {
                            GetFoodGroup();
                            reloop = true;
                        }
                        else
                        {
                            reloop = false;
                        }
                    }
                }
                if (reloop == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Please re-select a food group from the list below to view: ");
                }

            } while (reloop == false);

            GetFoodGroup();

        }
    }
}//----------------------------------------------------END OF FILE------------------------------------------------------------------//
