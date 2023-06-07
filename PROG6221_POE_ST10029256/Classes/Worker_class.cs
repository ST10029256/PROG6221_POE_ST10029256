using PROG6221_POE_ST10029256.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10029256
{
    /// <summary>
    /// declare delegate
    /// </summary>
    /// <param name="totalCalories"></param>
    public delegate void CalorieAllertDelegate(double totalCalories);

    public class Worker_class
    {
        public event CalorieAllertDelegate CalorieAllertEvent;

        /// <summary>
        /// Instantiate ingredient class
        /// </summary>
        public Ingredient_class ingredient_class = new Ingredient_class();

        
        /// <summary>
        /// Instantiate step class
        /// </summary>

        public Steps_class steps_class = new Steps_class();

        public Recipe_class recipe_Class = new Recipe_class();

        private List<Recipe_class> recipeList = new List<Recipe_class>();
        private List<string> recipeNames { get; set; }
        public List<Steps_class> StepsListWorker { get; set; }
        public List<List<string>> RecipesStepsList { get; set; }
        public List<List<Ingredient_class>> RecipesIngredientsList { get; set; }
        public List<Ingredient_class> IngredientsListWorker { get; set; }

        private List<double> TotalNumberOfCaloriesList = new List<double>();

        private List<double> CopyOfTotalNumberOfCaloriesList = new List<double>();
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public Worker_class()
        {

        }
        /// <summary>
        /// allerts the user when limit of total calories exceed
        /// </summary>
        /// <param name="totalCalories"></param>
        protected virtual void AllertUser(double totalCalories)
        {
            if (totalCalories > 300)
            {
                CalorieAllertEvent?.Invoke(totalCalories);
            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// handels event when limit of calories exceeds
        /// </summary>
        /// <param name="totalCalories"></param>
        private void HandleCalorieAllertEvent(double totalCalories)
        {
            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tAllert!\r\n\tThe total calories exceed 300.\r\n\tThe total calories are "+ totalCalories + ".");
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Displayes a welcome message to the user
        /// </summary>
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
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Displayes a thank you message to the user
        /// </summary>
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
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method stores data into all arrays
        /// </summary>
        public void AddRecipeToList()
        {
            // Create a new instance of the Recipe_class
            Recipe_class rc = new Recipe_class();

            // Get the name of the new recipe from the user
            string newRecipeName = rc.GetRecipeName();

            // Store the ingredients in a list
            StoreIngredientsInList();

            // Store the steps in a list
            StoreStepsInList();

            // Add the new recipe name to the recipeNames list
            recipeNames.Add(newRecipeName);

            // Add the ingredient steps to the RecipesStepsList
            RecipesStepsList.Add(StepsListWorker.Select(step => step.ingredientSteps).ToList());

            // Add the ingredients to the RecipesIngredientsList
            RecipesIngredientsList.Add(IngredientsListWorker.Select(ingredient => ingredient).ToList());

            // Calculate the total number of calories for the recipe
            double totalCalories = CalcTotalCalories(RecipesIngredientsList);

            // Add the total number of calories to the TotalNumberOfCaloriesList
            TotalNumberOfCaloriesList.Add(totalCalories);

            // Make a copy of the total number of calories list
            CopyOfTotalNumberOfCaloriesList.Add(totalCalories);

            // Store the recipe in a suitable format
            StoreRecipe(RecipesStepsList, RecipesIngredientsList);
        }
//-------------------------------------------------------------------------------------------------------------------------//
        public double CalcTotalCalories(List<List<Ingredient_class>> RecipesIngredientsList)
        {
            double totalCalories = 0;
            foreach (var list in RecipesIngredientsList)
            {
                foreach (var ingredient in list)
                {
                    double calories = Math.Max(ingredient.numberOfCalories, 0);//make sure that there can be no negative value calories 
                    totalCalories += calories;
                }
            }

            //make use of the delegate 
            CalorieAllertEvent += HandleCalorieAllertEvent;

            AllertUser(totalCalories);//allerts the user

            CalorieAllertEvent -= HandleCalorieAllertEvent;

            return totalCalories;
        }
//-------------------------------------------------------------------------------------------------------------------------//
        public void StoreIngredientsInList()
        {
            int numberOfIngredients = ingredient_class.GetNumberOfIngredients();

            IngredientsListWorker = new List<Ingredient_class>();

            for (int i = 0; i < numberOfIngredients; i++) //This will loop through the total numberOfIngredients and get the users input for all the ingredient
                                                          //data and stores the data into the arrays 
            {

                var newIngredient = new Ingredient_class
                {
                    // Create a new instance of Ingredient_class and assign the property values
                    quantityOfIngredient = ingredient_class.GetQuantityOfIngredient(),
                    unitOfIngredient = ingredient_class.GetUnitOfIngredient(),
                    ingredientName = ingredient_class.GetingredientName(),
                    numberOfCalories = ingredient_class.GetNumberOfCalories(),
                    FoodGroup = ingredient_class.GetFoodGroup(),
                    CopyOfNnumberOfCalories = ingredient_class.numberOfCalories,
                    CopyOfQuantityOfIngredient = ingredient_class.quantityOfIngredient,
                    CopyOfUnitOfIngredient = ingredient_class.unitOfIngredient
                };
                // Add the new ingredient to IngredientsListWorker
                IngredientsListWorker.Add(newIngredient);

                // Display separator line
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");
            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        public void StoreStepsInList()
        {
            int numberOfSteps = steps_class.GetNumberOfSteps();
            //var step = new Steps_class();
            StepsListWorker = new List<Steps_class>();         

            for (int j = 0; j < numberOfSteps; j++) //This will loop through the total numberOfSteps and get the users input for all the steps
                                                    //data and stores the data into the arrays
            {
                string input = steps_class.GetIngredientSteps(j + 1);

                StepsListWorker.Add(new Steps_class { ingredientSteps = input} );

            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        public void StoreRecipe(List<List<string>> RecipesStepsList, List<List<Ingredient_class>> RecipesIngredientsList)
        {

            //ingredientsArray = new Ingredient_class[numberOfIngredients];
            //resetIngredientQuantity = new float[numberOfIngredients];
            //resetIngredientUnits = new string[numberOfIngredients];

            // Get the list of recipe names
            recipeNames = GetRecipeNames();

            // Iterate over each recipe name
            for (int i = 0; i < recipeNames.Count; i++)
            {
                // Create a new Recipe_class instance for the current recipe
                var recipe = new Recipe_class
                {
                    RecipeName = recipeNames[i]
                };

                // Check if there are corresponding steps and ingredients for the current recipe
                if (i < RecipesStepsList.Count && i < RecipesIngredientsList.Count)
                {
                    // Get the list of steps for the current recipe
                    List<string> S = RecipesStepsList[i];

                    // Get the list of ingredients for the current recipe
                    List<Ingredient_class> I = RecipesIngredientsList[i];

                    // Iterate over each step in the list of steps
                    foreach (var step in S)
                    {
                        // Create a Steps_class instance and add it to the recipe's stepsList
                        Steps_class steps = new Steps_class { ingredientSteps = step };
                        recipe.stepsList.Add(steps);
                    }

                    // Iterate over each ingredient in the list of ingredients
                    foreach (var ingredient in I)
                    {
                        // Create an Ingredient_class instance and add it to the recipe's ingredientsList
                        Ingredient_class ingredients = new Ingredient_class
                        {
                            ingredientName = ingredient.ingredientName,
                            quantityOfIngredient = ingredient.quantityOfIngredient,
                            numberOfCalories = ingredient.numberOfCalories,
                            unitOfIngredient = ingredient.unitOfIngredient,
                            FoodGroup = ingredient.FoodGroup
                        };

                        recipe.ingredientsList.Add(ingredient);
                    }
                }
                else
                {
                    //Error handeling
                }
                // Add the completed recipe to the recipeList
                recipeList.Add(recipe);
            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        public List<string> GetRecipeNames()
        {
            return recipeNames;
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method scales the ingredient quantity according to the users input
        /// </summary>
        public float ScalingCalc(int i, int num, int position)
        {
            var half = 0.5f;
            int double1 = 2;
            int tripple = 3;
            float final = 0.0f;

            switch (num)
            {
                case 1:// Scaling factor of 1 (half)
                    final = half * recipeList[position].ingredientsList[i].quantityOfIngredient;
                    recipeList[position].ingredientsList[i].numberOfCalories = half * recipeList[position].ingredientsList[i].numberOfCalories;
                    break;

                case 2:// Scaling factor of 2 (double)
                    final = double1 * recipeList[position].ingredientsList[i].quantityOfIngredient;
                    recipeList[position].ingredientsList[i].numberOfCalories = double1 * recipeList[position].ingredientsList[i].numberOfCalories;
                    break;

                case 3:// Scaling factor of 3 (triple)
                    final = tripple * recipeList[position].ingredientsList[i].quantityOfIngredient;
                    recipeList[position].ingredientsList[i].numberOfCalories = tripple * recipeList[position].ingredientsList[i].numberOfCalories;
                    break;
            }

            // Return the final scaled value
            return final;
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Scaling half, double or tripple
        /// </summary>
        public void Scaling()
        {
            int num = 0;
            int index = 0;
            bool reloop = false;
            int position = 0;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please choose which recipe to Scale: ");

            // Copy recipe names to a new list and sort them alphabetically
            List<string> copyOfNameList = new List<string>();

            for (int k = 0; k < recipeList.Count; k++)
            {
                copyOfNameList.Add(recipeList[k].RecipeName);
            }

            List<string> sortedNameList = copyOfNameList.OrderBy(name => name).ToList();

            // Loop until a valid recipe choice is made

            do
            {
                DisplayRecipes(sortedNameList);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= sortedNameList.Count)
                    {
                        index = choice - 1;
                        string recipeName = sortedNameList[index];

                        // Find the position of the chosen recipe in the original recipe list
                        position = recipeList.IndexOf(recipeList.Find(recipe => recipe.RecipeName == recipeName));
                        reloop = true;
                    }
                    else
                    {
                        if (choice == sortedNameList.Count + 1)
                        {
                            // Go back to the main menu if the user chooses to
                            reloop = true;
                            MainMenu();
                        }
                        else
                        {
                            // Invalid choice, prompt user to reselect
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("---------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please re-choose which recipe to Scale: ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            reloop = false;
                        }
                    }
                }
                else
                {
                    // Invalid input, prompt user to reselect
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please re-choose which recipe to Scale: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reloop = false;
                }
            } while (reloop == false);

            string confirm; bool reAsk = false;

            //var choice = string.Empty;
            //IngredientsListWorker = recipe_Class.ingredientsList;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Would you like to scale the recipe? (YES/NO): ");
            confirm = (Console.ReadLine()).ToUpper();

            do
            {
                //if the user enters Yes the user will be asked to half, double or tripple the quantity of the ingredient
                if ((confirm.Equals("YES")) || (confirm.Equals("NO")))
                {
                    reAsk = true;
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter YES or NO: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    confirm = (Console.ReadLine()).ToUpper();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reAsk = false;
                }

            } while (reAsk == false);

            if (confirm == "YES")
            {
                Console.WriteLine("Please choose one of the following by entering the number: ");
                Console.WriteLine("1: (Half) ");
                Console.WriteLine("2: (Double) ");
                Console.WriteLine("3: (Tripple) ");
                Console.WriteLine("4: (Reset) ");
                string input = Console.ReadLine();

                int option = 0;
                bool valid = false;

                //this do while loop will run until the user enters a integer number between 0 and 5
                do
                {
                    try // Try parsing the input as an integer
                    {

                        if (Int32.TryParse(input, out option))
                        {
                            option = Convert.ToInt32(input);

                            if ((option > 0) && (option < 5)) // Check if the input is between 1 and 4
                            {

                                valid = true;
                                num = option;

                            }
                            else
                            {
                                // Prompt user to re-enter a valid number
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\r\nPlease choose one of the following by re-entering the number: ");
                                Console.WriteLine("1: (Half) ");
                                Console.WriteLine("2: (Double) ");
                                Console.WriteLine("3: (Tripple) ");
                                Console.WriteLine("4: (Reset) ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                input = Console.ReadLine();
                                valid = false;
                            }

                        }
                        else
                        {
                            // Prompt user to re - enter a valid number
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\r\nPlease choose one of the following by re-entering the number: ");
                            Console.WriteLine("1: (Half) ");
                            Console.WriteLine("2: (Double) ");
                            Console.WriteLine("3: (Tripple) ");
                            Console.WriteLine("4: (Reset) ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            input = Console.ReadLine();
                            valid = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        if (valid != false)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                } while (valid == false);

                switch (num)
                {
                    case 1:
                        TotalNumberOfCaloriesList[position] = 0.5 * TotalNumberOfCaloriesList[position];
                        ///make use of the delegate 
                        CalorieAllertEvent += HandleCalorieAllertEvent;

                        AllertUser(TotalNumberOfCaloriesList[position]);//allerts the user

                        CalorieAllertEvent -= HandleCalorieAllertEvent;
                        break;
                    case 2:
                        TotalNumberOfCaloriesList[position] = 2 * TotalNumberOfCaloriesList[position];
                        ///make use of the delegate 
                        CalorieAllertEvent += HandleCalorieAllertEvent;

                        AllertUser(TotalNumberOfCaloriesList[position]);//allerts the user

                        CalorieAllertEvent -= HandleCalorieAllertEvent;
                        break;
                    case 3:
                        TotalNumberOfCaloriesList[position] = 3 * TotalNumberOfCaloriesList[position];
                        ///make use of the delegate 
                        CalorieAllertEvent += HandleCalorieAllertEvent;

                        AllertUser(TotalNumberOfCaloriesList[position]);//allerts the user

                        CalorieAllertEvent -= HandleCalorieAllertEvent;
                        break;
                }

                // Iterate over the ingredients of the selected recipe
                for (int i = 0; i < recipeList[position].ingredientsList.Count; i++)
                {
                    switch (num)
                    {
                        case 1:
                            recipeList[position].ingredientsList[i].quantityOfIngredient = ScalingCalc(i, num, position);
                            ChangeUnits(i, position);
                            break;

                        case 2:
                            recipeList[position].ingredientsList[i].quantityOfIngredient = ScalingCalc(i, num, position);
                            ChangeUnits(i, position);
                            break;

                        case 3:
                            // Perform scaling and unit conversion based on the chosen option
                            recipeList[position].ingredientsList[i].quantityOfIngredient = ScalingCalc(i, num, position);
                            ChangeUnits(i, position);
                            break;

                        case 4:
                            // Reset the ingredient values to their original values
                            recipeList[position].ingredientsList[i].quantityOfIngredient = recipeList[position].ingredientsList[i].CopyOfQuantityOfIngredient;
                            recipeList[position].ingredientsList[i].unitOfIngredient = recipeList[position].ingredientsList[i].CopyOfUnitOfIngredient;
                            recipeList[position].ingredientsList[i].numberOfCalories = recipeList[position].ingredientsList[i].CopyOfNnumberOfCalories;
                            TotalNumberOfCaloriesList[position] = CopyOfTotalNumberOfCaloriesList[position];
                            break;
                    }
                }
            }
            else
            {
                MainMenu();
            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method will convert the quantity within the array to the correct unit of which the users would like to scale the recipe to.
        /// The data will then be rounded to the nearest 1 decimal place. If the quantity of the ingredient is 1 the word will be displayed 
        /// in a singular form and if more than one it will be dispalyed in a plural form.
        /// </summary>
        public void ChangeUnits(int i,int position)
        {
            // Check if the unit is "l" (liters)
            if (recipeList[position].ingredientsList[i].unitOfIngredient == "l")
            {
                // Convert liters to milliliters
                recipeList[position].ingredientsList[i].quantityOfIngredient = recipeList[position].ingredientsList[i].quantityOfIngredient * 1000;
                recipeList[position].ingredientsList[i].unitOfIngredient = "ml";
            }
            // Check if the unit is "ml" (milliliters)
            if (recipeList[position].ingredientsList[i].unitOfIngredient == "ml")
            {
                if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 3785)
                {
                    // Convert milliliters to gallons
                    recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 3785), 1);
                    recipeList[position].ingredientsList[i].unitOfIngredient = "gallon";
                }
                else
                {
                    if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 240)
                    {
                        // Convert milliliters to cups
                        recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 240), 1);
                        recipeList[position].ingredientsList[i].unitOfIngredient = "cups";
                    }
                    else
                    {
                        if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 15)
                        {
                            // Convert milliliters to tablespoons
                            recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 15), 1);
                            recipeList[position].ingredientsList[i].unitOfIngredient = "tablespoons";
                        }
                        else
                        {
                            if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 5)
                            {
                                // Convert milliliters to teaspoons
                                recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 5), 1);
                                recipeList[position].ingredientsList[i].unitOfIngredient = "teaspoons";
                            }
                            else
                            {
                                // Default unit is milliliters
                                recipeList[position].ingredientsList[i].unitOfIngredient = "ml";
                            }
                        }
                    }
                }
            }
            // Check if the unit is "teaspoon" or "teaspoons"
            if ((recipeList[position].ingredientsList[i].unitOfIngredient == "teaspoon") || recipeList[position].ingredientsList[i].unitOfIngredient == "teaspoons")
            {
                if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 3)
                {
                    // Convert teaspoons to tablespoons
                    recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 3), 1);
                    recipeList[position].ingredientsList[i].unitOfIngredient = "tablespoons";
                }
                else
                {
                    if (recipeList[position].ingredientsList[i].quantityOfIngredient == 1)
                    {
                        // Keep the unit as "teaspoon"
                        recipeList[position].ingredientsList[i].unitOfIngredient = "teaspoon";
                    }
                }
            }
            else
            {
                // Check if the unit is "tablespoon" or "tablespoons"
                if ((recipeList[position].ingredientsList[i].unitOfIngredient == "tablespoon") || recipeList[position].ingredientsList[i].unitOfIngredient == "tablespoons")
                {
                    if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 16)
                    {
                        // Convert tablespoons to cups
                        recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 16), 1);
                        recipeList[position].ingredientsList[i].unitOfIngredient = "cups";
                    }
                    else
                    {
                        if (recipeList[position].ingredientsList[i].quantityOfIngredient == 1)
                        {
                            // Keep the unit as "tablespoon"
                            recipeList[position].ingredientsList[i].unitOfIngredient = "tablespoon";
                        }
                    }

                }

                // Check if the unit is "cup" or "cups"
                if ((recipeList[position].ingredientsList[i].unitOfIngredient == "cup") || recipeList[position].ingredientsList[i].unitOfIngredient == "cups")
                {
                    if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 16)
                    {
                        // Convert cups to gallons
                        recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 16), 1);
                        recipeList[position].ingredientsList[i].unitOfIngredient = "gallons";
                    }
                    else
                    {
                        if (recipeList[position].ingredientsList[i].quantityOfIngredient == 1)
                        {
                            // Keep the unit as "cup"
                            recipeList[position].ingredientsList[i].unitOfIngredient = "cup";
                        }
                        else
                        {
                            if (recipeList[position].ingredientsList[i].quantityOfIngredient < 16)
                            {
                                // Keep the unit as "cups"
                                recipeList[position].ingredientsList[i].unitOfIngredient = "cups";
                            }
                        }
                    }
                }
            }

            // Check if the unit is "gallon" or "gallons"
            if ((recipeList[position].ingredientsList[i].unitOfIngredient == "gallon") || recipeList[position].ingredientsList[i].unitOfIngredient == "gallons")
            {
                if (recipeList[position].ingredientsList[i].quantityOfIngredient == 1)
                {
                    // Keep the unit as "gallon"
                    recipeList[position].ingredientsList[i].unitOfIngredient = "gallon";
                }
                else
                {
                    // Keep the unit as "gallons"
                    recipeList[position].ingredientsList[i].unitOfIngredient = "gallons";
                }
            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method is where the application starts and will be called in the main.
        /// </summary>
        public void MainMenu()
        {
            // Displaying menu options to the user
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

            // This do-while loop will run until the user enters an integer number between 1 and 5
            do
            {
                try
                {
                    if (Int32.TryParse(input, out option))
                    {
                        option = Convert.ToInt32(input);

                        if ((option > 0) && (option < 6))
                        {

                            reloop = true;

                        }
                        else
                        {
                            // Invalid input, prompting the user to re-enter a valid option
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
                        // Invalid input, prompting the user to re-enter a valid option
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
                    if (reloop != false)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            } while (reloop == false);

            // Performing actions based on the user's choice using a switch statement
            switch (option)
            {
                case 1:
                    // User chose to enter a recipe, calling the AddRecipe method
                    AddRecipe();
                    break;

                case 2:
                    // User chose to display a recipe, calling the Display method and then recursively calling MainMenu
                    Display();
                    MainMenu();
                    break;

                case 3:
                    // User chose to scale a recipe, calling the Scaling method and then recursively calling MainMenu
                    Scaling();
                    MainMenu();
                    break;

                case 4:
                    // User chose to clear a recipe, calling the ClearSelectedRecipe method and then recursively calling MainMenu
                    ClearSelectedRecipe();
                    MainMenu();
                    break;

                default:
                    // User chose to exit the application, calling the ExitTheApplication method
                    ExitTheApplication();
                    break;
            }
        }
//-------------------------------------------------------------------------------------------------------------------------//
        public void ExitTheApplication()
        {
            string input;
            bool reloop;

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
                // Checking if the user input is either "YES" or "NO"
                if ((input.Equals("YES")) || (input.Equals("NO")))

                {
                    if (input == "YES")
                    {
                        // User entered "YES", printing a thank you message and exiting the application
                        PrintThankYouMessage();
                        Environment.Exit(0);
                    }
                    else
                    {
                        // User entered "NO", calling the MainMenu method to return to the main menu
                        MainMenu();
                    }
                    reloop = true;
                }
                else
                {
                    // Invalid input, prompting the user to re-enter "YES" or "NO"
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter YES or NO: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    input = (Console.ReadLine()).ToUpper();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reloop = false;
                }

            } while (reloop == false);
        }
//-------------------------------------------------------------------------------------------------------------------------//
        public void ClearSelectedRecipe()
        {
            bool reloop = false;
            int recipeIndex = -1;
            string input2;
            string input;

            // Display prompt for choosing a recipe to clear
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please choose which recipe to clear: ");

            List<string> copyOfNameList = new List<string>();

            for (int k = 0; k < recipeList.Count; k++)
            {
                copyOfNameList.Add(recipeList[k].RecipeName);
            }

            List<string> sortedNameList = copyOfNameList.OrderBy(name => name).ToList();
            do
            {
                DisplayRecipes(sortedNameList); // Display the available recipes

                input2 = Console.ReadLine();


                if (int.TryParse(input2, out int choice))
                {
                    if (choice >= 1 && choice <= sortedNameList.Count)
                    {
                        recipeIndex = choice - 1;
                        string recipeName = sortedNameList[recipeIndex];

                        int position = recipeList.IndexOf(recipeList.Find(recipe => recipe.RecipeName == recipeName));

                        // Ask the user if they want to clear the selected recipe
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("---------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Would you like to clear the "+ recipeName +" recipe? (YES/NO): ");
                        input = (Console.ReadLine()).ToUpper();

                        //this do while loop will run until the user enters YES or NO in caps or lowercase
                        do
                        {

                            if ((input.Equals("YES")) || (input.Equals("NO")))
                            {
                                // Clear the recipe from the array
                                if (input == "YES")
                                {
                                    // Clearing request successfull
                                    recipeList.RemoveAt(position);
                                    TotalNumberOfCaloriesList.RemoveAt(position);
                                    CopyOfTotalNumberOfCaloriesList.RemoveAt(position);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Successfully cleared");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                }
                                else
                                { 
                                    // Clearing request canceled
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Clearing request canceled");
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                }
                                reloop = true;
                            }
                            else
                            {
                                // Invalid input, prompt user to re-enter
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Please enter YES or NO: ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                input = (Console.ReadLine()).ToUpper();

                                Console.ForegroundColor = ConsoleColor.Magenta;
                                reloop = false;
                            }
                        } while (reloop == false);
                    }
                    else
                    {
                        // Check if the user wants to clear another recipe or exit
                        if (choice == (sortedNameList.Count + 1))
                        {
                            // User chose to exit
                            reloop = true;
                        }
                        else
                        {
                            // User needs to re-choose which recipe to clear
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("---------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please re-choose which recipe to clear: ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            reloop = false;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please re-choose which recipe to clear: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reloop = false;
                }
                // Continue the loop until a valid recipe is chosen or user chooses to exit
            } while (reloop == false);
        }
//-------------------------------------------------------------------------------------------------------------------------//
        public void AddRecipe()
        {
            bool anotherRecipe = true; // Flag to determine if the user wants to add another recipe
            bool reloop = true; // Flag for input validation loop

            // Prompt the user to add a recipe
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Would you like to enter a recipe? (YES/NO): ");
            string answer = (Console.ReadLine()).ToUpper();

            // Validate the user input
            do
            {
                if (answer == "YES" || answer == "NO")
                {
                    reloop = true; // Valid input, exit the loop
                }
                else
                {
                    // Invalid input, prompt the user to re-enter
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter YES or NO: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    answer = (Console.ReadLine()).ToUpper();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reloop = false; // Set the flag to continue the loop
                }
            } while (reloop == false);

            // Loop to add recipes
            do
            {

                if (answer.Equals("YES"))
                {
                    recipeNames = new List<string>();
                    RecipesStepsList = new List<List<string>>();
                    RecipesIngredientsList = new List<List<Ingredient_class>>();
                    AddRecipeToList(); // Call the method to add a recipe to the lists
                    anotherRecipe = true; // User wants to add another recipe
                    AddRecipe(); // Recursively call the AddRecipe method for the next recipe
                }
                else
                {
                    anotherRecipe = false; // User does not want to add another recipe
                }

            } while (anotherRecipe == true);

            MainMenu(); // Return to the main menu
        }
//-------------------------------------------------------------------------------------------------------------------------//
        private void DisplayRecipes(List<string> sortedNameList)
        {
            for (int i = 0; i < sortedNameList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedNameList[i]}");
            }

            Console.WriteLine($"{sortedNameList.Count + 1}. Back");
            Console.Write(">");
        }
//-------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// method will display user input
        /// </summary>
        public void Display()
        {
            int recipeIndex = -1; // Index of the selected recipe
            bool reloop = false; // Flag for input validation loop

            // Prompt the user to choose a recipe to display
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please choose which recipe to display: ");

            ///Loop to handle user input and display the recipe
            do
            {
                List<string> copyOfNameList = new List<string>();

                // Create a copy of the recipe names list
                for (int k = 0; k < recipeList.Count; k++)
                {
                    copyOfNameList.Add(recipeList[k].RecipeName);
                }

                // Sort the recipe names list alphabetically
                List<string> sortedNameList = copyOfNameList.OrderBy(name => name).ToList();

                DisplayRecipes(sortedNameList); // Display the sorted recipe names
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= sortedNameList.Count)
                    {
                        recipeIndex = choice - 1; // Adjust the index based on user choice
                        string recipeName = sortedNameList[recipeIndex];

                        // Find the position of the selected recipe in the recipeList
                        int position = recipeList.IndexOf(recipeList.Find(recipe => recipe.RecipeName == recipeName));

                        if (position >= 0 && position < recipeList.Count)
                        {
                            if (IngredientsListWorker != null && StepsListWorker != null)
                            {

                                Recipe_class selected = recipeList.Find(recipe => recipe.RecipeName == recipeName);
                                List<Steps_class> S = recipeList[position].stepsList;
                                List<Ingredient_class> I = recipeList[position].ingredientsList;

                                // Display recipe name and ingredients
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("---------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Recipe: " + recipeName); //code for name display 
                                Console.WriteLine("Ingredients:\r\n");                                

                                for (int i = 0; i < I.Count; i++) 
                                {

                                    // Display each ingredient with quantity, unit, name, calories, and food group
                                    Console.WriteLine((i + 1) + ". " + I[i].quantityOfIngredient + " " + I[i].unitOfIngredient +
                                        " of " + I[i].ingredientName + " " + "(" + I[i].numberOfCalories + " " + "calories)");

                                    Console.WriteLine("(Food group: " + I[i].FoodGroup + ") ");

                                    Console.WriteLine();

                                }
                                // Display recipe steps
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("---------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Steps:\r\n");
                                for (int j = 0; j < S.Count; j++) //loops through and display each element in the array in the format of
                                                                          //1. discription of the step
                                {
                                    // Display each step with a step number and description
                                    Console.WriteLine((j + 1) + ". " + S[j].ingredientSteps);
                                }
                                // Display total calories of the recipe
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("---------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Total calories:\t "+ TotalNumberOfCaloriesList[position]);//display the total number of calories
                                Console.WriteLine(); 
                                switch (TotalNumberOfCaloriesList[position])
                                {
                                    case double n when (n >= 0 && n <= 150):
                                        Console.WriteLine("Range: 0 - 150 calories");
                                        Console.WriteLine("This range of calories is perfect for snacks, as this is \r\n" +
                                                          "low in calories and are often comprised of light, nutrient \r\n" +
                                                          "dense foods such as fruits, vegetables and low-fat dairy \r\n" +
                                                          "products. This is suitable for those who are closely \r\n" +
                                                          "monitoring their calorie intake or looking for minimal \r\n" +
                                                          "calorie options.");
                                        break;
                                    case double n when (n > 150 && n <= 450):
                                        Console.WriteLine("Range: 150 - 450 calories");
                                        Console.WriteLine("This range of calories is perfect for breakfast options, \r\n" +
                                                          "as this is lower in calories and are suitable for those \r\n" +
                                                          "who prefer a lighter start to their day. This can include \r\n" +
                                                          "choices like a small serving of fruit, a cup of yogurt, \r\n" +
                                                          "a slice of toast with a light spread (e.g., jam, peanut \r\n" +
                                                          "butter), a boiled egg, or a small bowl of oatmeal with \r\n" +
                                                          "toppings.");
                                        break;
                                    case double n when (n > 450 && n <= 750):
                                        Console.WriteLine("Range: 450 - 750 calories");
                                        Console.WriteLine("This range of calories is perfect for lunch options, as \r\n" +
                                                          "this is on the lower end of the calorie spectrum and are \r\n" +
                                                          "suitable for those who prefer a lighter midday meal. This \r\n" +
                                                          "can include choices like a small salad with lean protein, \r\n" +
                                                          "a cup of soup with whole-grain crackers, a small sandwich \r\n" +
                                                          "with turkey or chicken, a small wrap with vegetarian \r\n" +
                                                          "fillings, or a small sushi roll.");
                                        break;
                                    case double n when (n > 750 && n <= 1000):
                                        Console.WriteLine("Range: 750 - 1000 calories");
                                        Console.WriteLine("This range of calories is perfect for dinner options, as \r\n" +
                                                          "this is on the lower end of the calorie spectrum and are \r\n" +
                                                          "suitable for those who prefer a lighter evening meal. This \r\n" +
                                                          "can include choices like a vegetable stir-fry with tofu, a \r\n" +
                                                          "small serving of fish or chicken with steamed vegetables, a \r\n" +
                                                          "small portion of vegetarian curry with whole-grain rice, a \r\n" +
                                                          "small bowl of soup with added protein and vegetables, or a \r\n" +
                                                          "vegetable-based pasta dish with a light sauce.");
                                        break;
                                    default:
                                        Console.WriteLine("Range: exceeding 1000 calories");
                                        Console.WriteLine("This can include a generous serving of protein such as steak, \r\n" +
                                                          "salmon, or chicken, cooked with flavorful seasonings. \r\n" +
                                                          "Accompany it with a larger portion of whole grains like \r\n" +
                                                          "quinoa or brown rice, and a variety of roasted or steamed \r\n" +
                                                          "vegetables. This combination provides a balanced mix of \r\n" +
                                                          "macronutrients and micronutrients to support muscle recovery \r\n" +
                                                          "and overall health.");
                                        break;


                                };

                                reloop = true; // Valid input, exit the loop
                            }
                            else
                            {
                                // No recipes to display
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("---------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("No recipes to display.");
                            }
                            reloop = true; // Valid input, exit
                        }
                    }
                    else
                    {
                        if (choice == (sortedNameList.Count + 1))
                        {
                            MainMenu(); // Go back to the main menu
                            reloop = true;
                        }
                        else
                        {
                            // Invalid input, ask the user to re-choose a recipe to display
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("---------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please re-choose which recipe to display: ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            reloop = false;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please re-choose which recipe to display: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reloop = false;
                }
            } while (reloop == false);

        } 
    }
}//----------------------------------------------------END OF FILE------------------------------------------------------------------//
