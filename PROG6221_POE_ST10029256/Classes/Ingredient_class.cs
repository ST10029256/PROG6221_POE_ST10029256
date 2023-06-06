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
        public int numberOfIngredients { get; private set; } = 0;
        public string ingredientName = string.Empty;
        public float quantityOfIngredient = 0.0f;
        public string unitOfIngredient  = string.Empty;
        public double numberOfCalories = 0.0f;
        public string FoodGroup {  get; set; } = string.Empty;

        public  float CopyOfQuantityOfIngredient = 0.0f;
        public string CopyOfUnitOfIngredient = string.Empty;
        public double CopyOfNnumberOfCalories = 0.0f;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Ingredient_class() 
        { 
        
        }

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

        public string GetFoodGroup()
            
        {
            bool reloop = false;
            string input = string.Empty;
            int index = 0;

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

                input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if ((choice >= 1 && choice <= FoodGroups.Count) && (FoodGroups.Count >= 0 && index < FoodGroups.Count))
                    {
                        index = choice - 1;
                        reloop = true;
                        FoodGroup = FoodGroups[index];
                    }
                    else
                    {
                        if (choice == FoodGroups.Count + 1)
                        {
                            reloop = true;
                            DisplayFoodGroupInformation();
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
                    Console.Write("Please re-select a food group from the list below: ");
                }

            } while (reloop == false); 
            
            return FoodGroup;
        }

    /// <summary>
    /// This method asks the user to enter the number of ingredients and if the user input is a string
    /// the text will turn red and ask the user to re-ener with an integer
    /// </summary>
    /// <returns></returns>

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
            public int GetNumberOfIngredients()
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

                        switch (index)
                        {
                            case 0://this will be Starchy foods
                                Console.WriteLine("");
                                break;
                            case 1: // this will be Vegetables and fruits
                                Console.WriteLine("");
                                break;
                            case 2://this will be Dry beans, peas, lentils and soya
                                Console.WriteLine("");
                                break;
                            case 3://this will be Chicken, fish, meat and eggs
                                Console.WriteLine("");
                                break;
                            case 4://this will be Milk and dairy products
                                Console.WriteLine("");
                                break;
                            case 5://this will be  Fats and oil
                                Console.WriteLine("");
                                break;
                            case 6://this will be Water
                                Console.WriteLine("");
                                break;
                        }
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
                    Console.Write("Please re-select a food group from the list below to view: ");
                }

            } while (reloop == false);
        }


        private void DisplayCalorieInformation()
        {   //general information about what calories are
            Console.WriteLine("");
        }
    }
}
