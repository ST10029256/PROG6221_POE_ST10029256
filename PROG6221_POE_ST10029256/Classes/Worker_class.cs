using PROG6221_POE_ST10029256.Classes;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10029256
{
    public class Worker_class
    {
        /// <summary>
        /// Instantiate ingredient class
        /// </summary>
       public Ingredient_class ingredient_class = new Ingredient_class();

        public List<Ingredient_class> ingredientsList { get; set; }
        /// <summary>
        /// Instantiate step class
        /// </summary>

        public Steps_class steps_class = new Steps_class();

        public List<Steps_class> stepsList { get; set; }


        public List<Recipe_class> recipeList { get; set; }
        /// <summary>
        /// Array holds ingredient data
        /// </summary>

        //public Ingredient_class[] ingredientsArray;

        /// <summary>
        /// Array holds steps data
        /// </summary>

        //public Steps_class[] stepsArray;

        /// <summary>
        /// Array Holds the reset ingredient quantity data
        /// </summary>

        public float[] resetIngredientQuantity;

        /// <summary>
        /// Array Holds the ingredient mesurement data
        /// </summary>

        public string[] resetIngredientUnits;

        public Recipe_class recipe_Class = new Recipe_class();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Worker_class()
        {

        }

        public void PrintWelcomeMessage()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();

            Console.WriteLine("W       W  EEEEE  L       CCCCC  OOOOO  M     M  EEEEE");
            Console.WriteLine("W       W  E      L      C       O   O  MM   MM  E    ");
            Console.WriteLine("W   W   W  EEEEE  L      C       O   O  M M M M  EEEEE");
            Console.WriteLine("W  W W  W  E      L      C       O   O  M  M  M  E    ");
            Console.WriteLine("W W   W W  EEEEE  LLLLL   CCCCC  OOOOO  M     M  EEEEE");

            Console.WriteLine();

            Console.WriteLine("  TTTTTTTTT  OOOOOO         TTTTTTTTT  H    H  EEEEE");
            Console.WriteLine("      T      O    O             T      H    H  E");
            Console.WriteLine("      T      O    O             T      HHHHHH  EEEEE");
            Console.WriteLine("      T      0    O             T      H    H  E");
            Console.WriteLine("      T      OOOO O             T      H    H  EEEEE");

            Console.WriteLine();

            Console.WriteLine("AAAAAA   PPPPPP   PPPPP  L      IIIII   CCCC  AAAAAA  TTTTTT  IIIII  OOOOO  N   N");
            Console.WriteLine("A    A   P    P   P   P  L        I    C      A    A     T      I    O   O  NN  N");
            Console.WriteLine("AAAAAA   PPPPPP   PPPPP  L        I    C      AAAAAA     T      I    O   O  N N N");
            Console.WriteLine("A    A   P        P      L        I    C      A    A     T      I    O   O  N  NN");
            Console.WriteLine("A    A   P        P      LLLLL  IIIII   CCCC  A    A     T    IIIII  OOOOO  N   N");

            Console.WriteLine(); 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Please press the ENTER key to continue: ");
            Console.ReadLine();
        }

        public void PrintThankYouMessage()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();

            Console.WriteLine("TTTTT H    H  AAAAA  N   N  K   K     Y   Y  OOOOO  U   U");
            Console.WriteLine("  T   H    H  A   A  NN  N  K  K       Y Y   O   O  U   U");
            Console.WriteLine("  T   HHHHHH  AAAAA  N N N  K K         Y    O   O  U   U");
            Console.WriteLine("  T   H    H  A   A  N  NN  K  K        Y    O   O  U   U");
            Console.WriteLine("  T   H    H  A   A  N   N  K   K       Y    OOOOO  UUUUU");

            Console.WriteLine();

            Console.WriteLine("FFFFF  OOOOO  RRRRR      U   U   SSSS  IIIII  N   N  GGGGG");
            Console.WriteLine("F      O   O  R   R      U   U  S        I    NN  N  G");
            Console.WriteLine("FFFFF  O   O  RRRRR      U   U   SSS     I    N N N  GGGGG");
            Console.WriteLine("F      O   O  R  R       U   U      S    I    N  NN  G   G");
            Console.WriteLine("F      OOOOO  R   R      UUUUU  SSSS   IIIII  N   N  GGGGG");

            Console.WriteLine();

            Console.WriteLine("              TTTTTTTTT  H    H  EEEEE");
            Console.WriteLine("                  T      H    H  E");
            Console.WriteLine("                  T      HHHHHH  EEEEE");
            Console.WriteLine("                  T      H    H  E");
            Console.WriteLine("                  T      H    H  EEEEE");

            Console.WriteLine();

            Console.WriteLine("AAAAAA   PPPPPP   PPPPP  L      IIIII   CCCC  AAAAAA  TTTTTT  IIIII  OOOOO  N   N");
            Console.WriteLine("A    A   P    P   P   P  L        I    C      A    A     T      I    O   O  NN  N");
            Console.WriteLine("AAAAAA   PPPPPP   PPPPP  L        I    C      AAAAAA     T      I    O   O  N N N");
            Console.WriteLine("A    A   P        P      L        I    C      A    A     T      I    O   O  N  NN");
            Console.WriteLine("A    A   P        P      LLLLL  IIIII   CCCC  A    A     T    IIIII  OOOOO  N   N");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Please press the ENTER key to Exit: ");
            Console.ReadLine();

        }

        /// <summary>
        /// This method stores data into all arrays
        /// </summary>

        public void StoreDataInArray()
        {
            var ingredients = new Ingredient_class();

            int numberOfIngredients = ingredients.GetNumberOfIngredients();
            //ingredientsArray = new Ingredient_class[numberOfIngredients];
            //resetIngredientQuantity = new float[numberOfIngredients];
            //resetIngredientUnits = new string[numberOfIngredients];

            recipeList = new List<Recipe_class>();

            var recipes = new Recipe_class
            {
                RecipeName = recipe_Class.GetRecipeName()
            };


            recipeList.Add(recipes);

            ingredientsList = new List<Ingredient_class>();

            for (int i = 0; i < numberOfIngredients; i++) //This will loop through the total numberOfIngredients and get the users input for all the ingredient
                                                              //data and stores the data into the arrays 
            {
                var ingredient = new Ingredient_class
                {
                    quantityOfIngredient = ingredient_class.GetQuantityOfIngredient(),
                    unitOfIngredient = ingredient_class.GetUnitOfIngredient(),
                    ingredientName = ingredient_class.GetingredientName(),
                    numberOfCalories = ingredient_class.GetNumberOfCalories(),
                    FoodGroup = ingredient_class.GetFoodGroup()
                };

                ingredientsList.Add(ingredient);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");

            }
            var step = new Steps_class();
            stepsList = new List<Steps_class>();

            int numberOfSteps = steps_class.GetNumberOfSteps();

            for (int j = 0; j <numberOfSteps; j++) //This will loop through the total numberOfSteps and get the users input for all the steps
                                                        //data and stores the data into the arrays
            {
                var steps = new Steps_class
                {
                    ingredientSteps = steps_class.GetIngredientSteps(j + 1)
                };

            stepsList.Add(steps);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void WriteReipeToList()
        {
            
        }

        /// <summary>
        /// This method scales the ingredient quantity according to the users input
        /// </summary>
        /// <param name="i"></param>
        /// <param name="num"></param>
        /// <returns></returns>

        public float ScalingCalc(int i, int num)
        {

            var half = 0.5f;
            int double1 = 2;
            int tripple = 3;
            float final = 0.0f;

            if (num == 1)
            {
                final = half * ingredientsList[i].quantityOfIngredient;
            }
            else
            {
                if (num == 2)
                {
                    final = double1 * ingredientsList[i].quantityOfIngredient;
                }
                else
                {
                    if (num == 3)
                    {
                        final = tripple * ingredientsList[i].quantityOfIngredient;
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
            bool reAsk = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Would you like to scale your recipe? (YES/NO): ");
            choice = (Console.ReadLine()).ToUpper();

            //this do while loop will run until the user enters YES or NO in caps or lowercase

            do
            {

                if ((choice.Equals("YES")) || (choice.Equals("NO"))) //if the user enters Yes the user will be asked to half, double or tripple the quantity
                                                                     //of the ingredient
                {
                    reAsk = true;
                }
                else
                {
                   
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter YES or NO: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    choice = (Console.ReadLine()).ToUpper();
                    
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reAsk = false;
                }

            } while (reAsk == false);

            if (choice == "YES")
            {
                Console.WriteLine("Please choose one of the following by entering the number: ");
                Console.WriteLine("1: (Half) ");
                Console.WriteLine("2: (Double) ");
                Console.WriteLine("3: (Tripple) ");
                Console.WriteLine("4: (Reset) ");
                string input = Console.ReadLine();

                int option = 0;
                bool reloop = false;

                //this do while loop will run until the user enters a integer number between 0 and 5

                do
                {
                    try //This will try to convert the string to a integer and if not able to it will re-ask the user to enter a intager between 0 and 5
                    {

                        if (Int32.TryParse(input, out option))
                        {
                            option = Convert.ToInt32(input);

                            if ((option > 0) && (option < 5))
                            {

                                reloop = true;
                                num = option;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\r\nPlease choose one of the following by re-entering the number: ");
                                Console.WriteLine("1: (Half) ");
                                Console.WriteLine("2: (Double) ");
                                Console.WriteLine("3: (Tripple) ");
                                Console.WriteLine("4: (Reset) ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                input = Console.ReadLine();
                                reloop = false;
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\r\nPlease choose one of the following by re-entering the number: ");
                            Console.WriteLine("1: (Half) ");
                            Console.WriteLine("2: (Double) ");
                            Console.WriteLine("3: (Tripple) ");
                            Console.WriteLine("4: (Reset) ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            input = Console.ReadLine();
                            reloop = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        if (reloop != false)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }

                } while (reloop == false);


                for (int i = 0; i < ingredientsList.Count; i++) //Calls the ScalingCalc method and the ChangeUnits method
                {
                    switch (num) //runs if the users input is 1,2,3 or 4 
                    {
                        case 1:
                            ingredientsList[i].quantityOfIngredient = ScalingCalc(i, num);
                            ChangeUnits(i, num);
                            break;

                        case 2:
                            ingredientsList[i].quantityOfIngredient = ScalingCalc(i, num);
                            ChangeUnits(i, num);
                            break;

                        case 3:
                            ingredientsList[i].quantityOfIngredient = ScalingCalc(i, num);
                            ChangeUnits(i, num);
                            break;

                        default:
                            ingredientsList[i].quantityOfIngredient = resetIngredientQuantity[i];
                            ingredientsList[i].unitOfIngredient = resetIngredientUnits[i];
                            break;

                    }
                }

            }
            else
            {
                MainMenu();
            }

        }

        /// <summary>
        /// This method will convert the quantity within the array to the correct unit of which the users would like to scale the recipe to.
        /// The data will then be rounded to the nearest 1 decimal place. If the quantity of the ingredient is 1 the word will be displayed 
        /// in a singular form and if more than one it will be dispalyed in a plural form.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="num"></param>
        public void ChangeUnits(int i, int num)
        {
            string newUnit = string.Empty;

            if (ingredientsList[i].unitOfIngredient == "l")
            {
                ingredientsList[i].quantityOfIngredient = ingredientsList[i].quantityOfIngredient * 1000;
                ingredientsList[i].unitOfIngredient = "ml";
            }
            if (ingredientsList[i].unitOfIngredient == "ml")
            {
                if (ingredientsList[i].quantityOfIngredient >= 3785)
                {
                    ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsList[i].quantityOfIngredient / 3785), 1);
                    ingredientsList[i].unitOfIngredient = "gallon";
                }
                else
                {
                    if (ingredientsList[i].quantityOfIngredient >= 240)
                    {
                        ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsList[i].quantityOfIngredient / 240),1);
                        ingredientsList[i].unitOfIngredient = "cups";
                    }
                    else
                    {
                        if (ingredientsList[i].quantityOfIngredient >= 15)
                        {
                            ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsList[i].quantityOfIngredient / 15), 1);
                            ingredientsList[i].unitOfIngredient = "tablespoons";
                        }
                        else
                        {
                            if (ingredientsList[i].quantityOfIngredient >= 5)
                            {
                                ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsList[i].quantityOfIngredient / 5),1);
                                ingredientsList[i].unitOfIngredient = "teaspoons";
                            }
                            else
                            {
                                ingredientsList[i].unitOfIngredient = "ml";
                            }
                        }
                    }
                }
            }

            if ((ingredientsList[i].unitOfIngredient == "teaspoon") || ingredientsList[i].unitOfIngredient == "teaspoons")
            {
                if (ingredientsList[i].quantityOfIngredient >= 3)
                {
                    ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsList[i].quantityOfIngredient / 3),1);
                    ingredientsList[i].unitOfIngredient = "tablespoons";
                }
                else
                {
                    if (ingredientsList[i].quantityOfIngredient == 1)
                    {
                        ingredientsList[i].unitOfIngredient = "teaspoon";
                    }
                }
            }
            else
            {
                if ((ingredientsList[i].unitOfIngredient == "tablespoon") || ingredientsList[i].unitOfIngredient == "tablespoons")
                {
                    if (ingredientsList[i].quantityOfIngredient >= 16)
                    {
                        ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsList[i].quantityOfIngredient / 16),1);
                        ingredientsList[i].unitOfIngredient = "cups";
                    }
                    else
                    {
                        if (ingredientsList[i].quantityOfIngredient == 1)
                        {
                            ingredientsList[i].unitOfIngredient = "tablespoon";
                        }
                    }

                }

                if ((ingredientsList[i].unitOfIngredient == "cup") || ingredientsList[i].unitOfIngredient == "cups")
                {
                    if (ingredientsList[i].quantityOfIngredient >= 16)
                    {
                        ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsList[i].quantityOfIngredient / 16),1);
                        ingredientsList[i].unitOfIngredient = "gallons";
                    }
                    else
                    {
                        if (ingredientsList [i].quantityOfIngredient == 1)
                        {
                                ingredientsList[i].unitOfIngredient = "cup";
                        }
                        else
                        {
                            if (ingredientsList[i].quantityOfIngredient < 16)
                            {
                                ingredientsList[i].unitOfIngredient = "cups";
                            }
                        }
                    }
                }

            }

            if ((ingredientsList[i].unitOfIngredient == "gallon") || ingredientsList[i].unitOfIngredient == "gallons")
            {
                if (ingredientsList[i].quantityOfIngredient == 1)
                {
                    ingredientsList[i].unitOfIngredient = "gallon";
                }
                else
                {
                    ingredientsList[i].unitOfIngredient = "gallons";
                }
            }
        }
    
        /// <summary>
        /// This method is where the application starts and will be called in the main.
        /// </summary>
       public void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please choose one of the folling by entering the number:");
            Console.WriteLine("1: Enter a recipe");
            Console.WriteLine("2: Display recipe");
            Console.WriteLine("3: Scale recipe");
            Console.WriteLine("4: Clear recipe");
            Console.WriteLine("5: Exit application");

            string input = Console.ReadLine();
            int option = 0;
            bool reloop = false;

            //this do while loop will run until the user enters a integer number between 0 and 6

            do
            {
                try
                {
                    if (Int32.TryParse(input, out option))
                    {
                        option = Convert.ToInt32(input);

                        if((option > 0) && (option < 6))
                        {

                            reloop = true;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\r\nPlease choose one of the folling by re-entering the number:");
                            Console.WriteLine("1: Enter a recipe");
                            Console.WriteLine("2: Display recipe");
                            Console.WriteLine("3: Scale recipe");
                            Console.WriteLine("4: Clear recipe");
                            Console.WriteLine("5: Exit application");
                            Console.ForegroundColor = ConsoleColor.Magenta;

                            input = Console.ReadLine();
                            reloop = false;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\r\nPlease choose one of the folling by re-entering the number:");
                        Console.WriteLine("1: Enter a recipe");
                        Console.WriteLine("2: Display recipe");
                        Console.WriteLine("3: Scale recipe");
                        Console.WriteLine("4: Clear recipe");
                        Console.WriteLine("5: Exit application");
                        Console.ForegroundColor = ConsoleColor.Magenta;

                        input = Console.ReadLine();
                        reloop = false;
                    }

                }
                catch (Exception ex)
                {
                    if(reloop != false)
                    {
                       Console.WriteLine(ex.Message); 
                    }
               
                }

            } while (reloop == false);

            switch (option) //Depending on what the users enter different methods will be called 
            {
                case 1:
                    StoreDataInArray();
                    AddRecipe();
                    break;

                case 2:
                    Display();
                    MainMenu();
                    break;

                case 3:
                    Scaling();
                    MainMenu();
                    break;

                case 4:

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Would you like to clear your recipe? (YES/NO): ");
                    input = (Console.ReadLine()).ToUpper();

                    //this do while loop will run until the user enters YES or NO in caps or lowercase

                    do
                    {

                        if ((input.Equals("YES")) || (input.Equals("NO")))
                        {
                            if (input == "YES")
                            {
                                //This clears the array
                                ingredientsList.Clear();
                                ingredientsList = null;
                                stepsList = null;

                                if (ingredientsList == null && stepsList == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Successfully cleared");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Not successfully cleared");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Clearing request canceled");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            reloop = true;
                            MainMenu();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Please enter YES or NO: ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            input = (Console.ReadLine()).ToUpper();

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            reloop = false;
                        }
                    } while (reloop == false);
                   
                    break;
                    
                default:
                    
                    //If user input is 5 the user would be asked to enter yes or no to leave the application

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Are you sure you want to exit the application? (Yes or No): ");
                    input = (Console.ReadLine()).ToUpper();

                    //if the user enters Yes the application will close, but if the user enters no the MainMenu metod will be called
                    //if the user enters anything than yes or no the user will be re-asked to enter yes or no

                    do
                    {

                        if ((input.Equals("YES")) || (input.Equals("NO"))) 
                                                                             
                        { 
                            if(input == "YES")
                            {
                                PrintThankYouMessage();
                                Environment.Exit(0);
                            }
                            else
                            {
                                MainMenu();
                            }
                            reloop = true;
                        }
                        else
                        { 
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Please enter YES or NO: ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            input = (Console.ReadLine()).ToUpper();

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            reloop = false;
                        }

                    } while (reloop == false);

                 break;
            }
        }

        public void AddRecipe()
        {
            bool anotherRecipe = true;
            bool reloop = true;
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Would you like to add a recipe? (YES/NO): ");
            string answer = (Console.ReadLine()).ToUpper();

            do
            {
                if (answer == "YES" || answer == "NO")
                {
                    reloop = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter YES or NO: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    answer = (Console.ReadLine()).ToUpper();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reloop = false;
                }
            } while (reloop == false);


            do
            {

                if (answer.Equals("YES"))
                {
                    StoreDataInArray();
                    anotherRecipe = true;
                    AddRecipe();
                }
                else
                {
                    anotherRecipe = false;
                }

            } while (anotherRecipe == true);

            MainMenu();
        }
        /// <summary>
        /// method will display user input
        /// </summary>
        public void Display()
        {
            int index = -1;

            if (ingredientsList != null && stepsList != null)
            {
                foreach (var recipe in recipeList)
                {
                    index++;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Recipe: " + recipeList[index].RecipeName);   //code for name display 
                    Console.WriteLine("Ingredients:\r\n");

                    for (int i = 0; i < ingredientsList.Count; i++) //loops through and display each element in the array in the format of
                                                                    //quantity space unit space of space name
                    {

                        Console.WriteLine((i + 1) + ". " + ingredientsList[i].quantityOfIngredient + " " + ingredientsList[i].unitOfIngredient +
                            " of " + ingredientsList[i].ingredientName + " " + "(" + ingredientsList[i].numberOfCalories + " " + "calories)");

                        Console.WriteLine("(Food group: " + ingredientsList[i].FoodGroup + ") ");

                        Console.WriteLine();

                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Steps:\r\n");
                    for (int j = 0; j < stepsList.Count; j++) //loops through and display each element in the array in the format of
                                                              //1. discription of the step
                    {
                        Console.WriteLine((j + 1) + ". " + stepsList[j].ingredientSteps);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("No recipes to display.");
            }

        }
    }
}
