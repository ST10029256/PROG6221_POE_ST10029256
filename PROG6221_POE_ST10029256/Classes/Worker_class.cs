using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10029256
{
    public class Worker_class
    {
        /// <summary>
        /// Instantiate ingredient class
        /// </summary>
        public Ingredient_class ingredients = new Ingredient_class();

        /// <summary>
        /// Instantiate step class
        /// </summary>

        public Steps_class steps = new Steps_class();

        /// <summary>
        /// Array holds ingredient data
        /// </summary>

        public Ingredient_class[] ingredientsArray;

        /// <summary>
        /// Array holds steps data
        /// </summary>

        public Steps_class[] stepsArray;

        /// <summary>
        /// Array Holds the reset ingredient quantity data
        /// </summary>

        public float[] resetIngredientQuantity;

        /// <summary>
        /// Array Holds the ingredient mesurement data
        /// </summary>

        public string[] resetIngredientUnits;

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
            int numberOfIngredients = ingredients.GetNumberOfIngredients();
            ingredientsArray = new Ingredient_class[numberOfIngredients];
            resetIngredientQuantity = new float[numberOfIngredients];
            resetIngredientUnits = new string[numberOfIngredients];

            for (int i = 0; i < ingredientsArray.Length; i++) //This will loop through the total numberOfIngredients and get the users input for all the ingredient
                                                              //data and stores the data into the arrays 
            {
                ingredientsArray[i] = new Ingredient_class();
                ingredientsArray[i].quantityOfIngredient = ingredients.GetQuantityOfIngredient();
                resetIngredientQuantity[i] = ingredientsArray[i].quantityOfIngredient;
                ingredientsArray[i].unitOfIngredient = ingredients.GetUnitOfIngredient();
                resetIngredientUnits[i] = ingredientsArray[i].unitOfIngredient;
                ingredientsArray[i].ingredientName = ingredients.GetingredientName();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");

            }

            stepsArray = new Steps_class[steps.GetNumberOfSteps()];

            for (int j = 0; j < stepsArray.Length; j++) //This will loop through the total numberOfSteps and get the users input for all the steps
                                                        //data and stores the data into the arrays
            {

                stepsArray[j] = new Steps_class();
                stepsArray[j].ingredientSteps = steps.GetIngredientSteps(j + 1);

            }
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
                final = half * ingredientsArray[i].quantityOfIngredient;
            }
            else
            {
                if (num == 2)
                {
                    final = double1 * ingredientsArray[i].quantityOfIngredient;
                }
                else
                {
                    if (num == 3)
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


                for (int i = 0; i < ingredientsArray.Length; i++) //Calls the ScalingCalc method and the ChangeUnits method
                {
                    switch (num) //runs if the users input is 1,2,3 or 4 
                    {
                        case 1:
                            ingredientsArray[i].quantityOfIngredient = ScalingCalc(i, num);
                            ChangeUnits(i, num);
                            break;

                        case 2:
                            ingredientsArray[i].quantityOfIngredient = ScalingCalc(i, num);
                            ChangeUnits(i, num);
                            break;

                        case 3:
                            ingredientsArray[i].quantityOfIngredient = ScalingCalc(i, num);
                            ChangeUnits(i, num);
                            break;

                        default:
                            ingredientsArray[i].quantityOfIngredient = resetIngredientQuantity[i];
                            ingredientsArray[i].unitOfIngredient = resetIngredientUnits[i];
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

            if (ingredientsArray[i].unitOfIngredient == "l")
            {
                ingredientsArray[i].quantityOfIngredient = ingredientsArray[i].quantityOfIngredient * 1000;
                ingredientsArray[i].unitOfIngredient = "ml";
            }
            if (ingredientsArray[i].unitOfIngredient == "ml")
            {
                if (ingredientsArray[i].quantityOfIngredient >= 3785)
                {
                    ingredientsArray[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsArray[i].quantityOfIngredient / 3785), 1);
                    ingredientsArray[i].unitOfIngredient = "gallon";
                }
                else
                {
                    if (ingredientsArray[i].quantityOfIngredient >= 240)
                    {
                        ingredientsArray[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsArray[i].quantityOfIngredient / 240),1);
                        ingredientsArray[i].unitOfIngredient = "cups";
                    }
                    else
                    {
                        if (ingredientsArray[i].quantityOfIngredient >= 15)
                        {
                            ingredientsArray[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsArray[i].quantityOfIngredient / 15), 1);
                            ingredientsArray[i].unitOfIngredient = "tablespoons";
                        }
                        else
                        {
                            if (ingredientsArray[i].quantityOfIngredient >= 5)
                            {
                                ingredientsArray[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsArray[i].quantityOfIngredient / 5),1);
                                ingredientsArray[i].unitOfIngredient = "teaspoons";
                            }
                            else
                            {
                                ingredientsArray[i].unitOfIngredient = "ml";
                            }
                        }
                    }
                }
            }

            if ((ingredientsArray[i].unitOfIngredient == "teaspoon") || ingredientsArray[i].unitOfIngredient == "teaspoons")
            {
                if (ingredientsArray[i].quantityOfIngredient >= 3)
                {
                    ingredientsArray[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsArray[i].quantityOfIngredient / 3),1);
                    ingredientsArray[i].unitOfIngredient = "tablespoons";
                }
                else
                {
                    if (ingredientsArray[i].quantityOfIngredient == 1)
                    {
                        ingredientsArray[i].unitOfIngredient = "teaspoon";
                    }
                }
            }
            else
            {
                if ((ingredientsArray[i].unitOfIngredient == "tablespoon") || ingredientsArray[i].unitOfIngredient == "tablespoons")
                {
                    if (ingredientsArray[i].quantityOfIngredient >= 16)
                    {
                        ingredientsArray[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsArray[i].quantityOfIngredient / 16),1);
                        ingredientsArray[i].unitOfIngredient = "cups";
                    }
                    else
                    {
                        if (ingredientsArray[i].quantityOfIngredient == 1)
                        {
                            ingredientsArray[i].unitOfIngredient = "tablespoon";
                        }
                    }

                }

                if ((ingredientsArray[i].unitOfIngredient == "cup") || ingredientsArray[i].unitOfIngredient == "cups")
                {
                    if (ingredientsArray[i].quantityOfIngredient >= 16)
                    {
                        ingredientsArray[i].quantityOfIngredient = (float)Math.Round((double)(ingredientsArray[i].quantityOfIngredient / 16),1);
                        ingredientsArray[i].unitOfIngredient = "gallons";
                    }
                    else
                    {
                        if (ingredientsArray[i].quantityOfIngredient == 1)
                        {
                            ingredientsArray[i].unitOfIngredient = "cup";
                        }
                        else
                        {
                            if (ingredientsArray[i].quantityOfIngredient < 16)
                            {
                                ingredientsArray[i].unitOfIngredient = "cups";
                            }
                        }
                    }
                }

            }

            if ((ingredientsArray[i].unitOfIngredient == "gallon") || ingredientsArray[i].unitOfIngredient == "gallons")
            {
                if (ingredientsArray[i].quantityOfIngredient == 1)
                {
                    ingredientsArray[i].unitOfIngredient = "gallon";
                }
                else
                {
                    ingredientsArray[i].unitOfIngredient = "gallons";
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
                            Console.WriteLine("4: Enter a new recipe");
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
                        Console.WriteLine("4: Enter a new recipe");
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
                    MainMenu();
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
                                Array.Clear(ingredientsArray, 0, ingredientsArray.Length);
                                Array.Clear(stepsArray, 0, stepsArray.Length);
                                Array.Clear(resetIngredientQuantity, 0, resetIngredientQuantity.Length);
                                Array.Clear(resetIngredientUnits, 0, resetIngredientUnits.Length);
                                ingredientsArray = null;
                                stepsArray = null;
                                resetIngredientQuantity = null;
                                resetIngredientUnits = null;

                                if (ingredientsArray == null && stepsArray == null & resetIngredientQuantity == null
                                    && resetIngredientUnits == null)
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

        /// <summary>
        /// method will display user input
        /// </summary>
        public void Display()
        {
            if (ingredientsArray != null && stepsArray != null && resetIngredientQuantity != null
                && resetIngredientUnits!= null)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingredients:\r\n");

                for (int i = 0; i < ingredientsArray.Length; i++) //loops through and display each element in the array in the format of
                                                                  //quantity space unit space of space name
                {

                    Console.WriteLine((i + 1) + ". " + ingredientsArray[i].quantityOfIngredient + " " + ingredientsArray[i].unitOfIngredient +
                        " of " + ingredientsArray[i].ingredientName);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Steps:\r\n");
                for (int j = 0; j < stepsArray.Length; j++) //loops through and display each element in the array in the format of
                                                            //1. discription of the step
                {
                    Console.WriteLine((j + 1) + ". " + stepsArray[j].ingredientSteps);
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
