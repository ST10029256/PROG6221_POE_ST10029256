using PROG6221_POE_ST10029256.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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

        
        /// <summary>
        /// Instantiate step class
        /// </summary>

        public Steps_class steps_class = new Steps_class();




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
        private List<Recipe_class> recipeList = new List<Recipe_class>();

        private List<string> recipeNames { get; set; }
        public List<Steps_class> StepsListWorker { get; set; }
        public List<List<string>> RecipesStepsList { get; set; }

        public List<List<Ingredient_class>> RecipesIngredientsList { get; set; }
        public List<Ingredient_class> IngredientsListWorker { get; set; }
        public List<Recipe_class> RecipeListWorker { get; set; }
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

        public void AddRecipeToList()
        {
            Recipe_class rc = new Recipe_class();

            string newRecipeName = rc.GetRecipeName();

            StoreIngredientsInList();

            StoreStepsInList();

            recipeNames.Add(newRecipeName);
            RecipesStepsList.Add(StepsListWorker.Select(step => step.ingredientSteps).ToList());
            RecipesIngredientsList.Add(IngredientsListWorker.Select(ingredient => ingredient).ToList());

            //Call total calories

            //Delegate

            StoreRecipe(RecipesStepsList, RecipesIngredientsList);
        }

        public void StoreIngredientsInList()
        {
            int numberOfIngredients = ingredient_class.GetNumberOfIngredients();

            IngredientsListWorker = new List<Ingredient_class>();

            for (int i = 0; i < numberOfIngredients; i++) //This will loop through the total numberOfIngredients and get the users input for all the ingredient
                                                          //data and stores the data into the arrays 
            {
                
                var newIngredient = new Ingredient_class
                {
                    quantityOfIngredient = ingredient_class.GetQuantityOfIngredient(),
                    unitOfIngredient = ingredient_class.GetUnitOfIngredient(),
                    ingredientName = ingredient_class.GetingredientName(),
                    numberOfCalories = ingredient_class.GetNumberOfCalories(),
                    FoodGroup = ingredient_class.GetFoodGroup()
                };

                IngredientsListWorker.Add(newIngredient);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");
            }
        }

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
        public void StoreRecipe(List<List<string>> RecipesStepsList, List<List<Ingredient_class>> RecipesIngredientsList)
        {

            //ingredientsArray = new Ingredient_class[numberOfIngredients];
            //resetIngredientQuantity = new float[numberOfIngredients];
            //resetIngredientUnits = new string[numberOfIngredients];

            recipeNames = GetRecipeNames();
          
            for (int i = 0; i < recipeNames.Count; i++)
            {
                var recipe = new Recipe_class
                {
                    RecipeName = recipeNames[i]
                };

                if (i < RecipesStepsList.Count && i < RecipesIngredientsList.Count)
                {
                    List<string> S = RecipesStepsList[i];
                    List<Ingredient_class> I = RecipesIngredientsList[i];
                    foreach (var step in S)
                    {
                        Steps_class steps = new Steps_class { ingredientSteps = step };

                        recipe.stepsList.Add(steps);
                    }


                    foreach (var ingredient in I)
                    {
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
                recipeList.Add(recipe);
            }
        }

        public List<string> GetRecipeNames()
        {
            return recipeNames;
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

        public float ScalingCalc(int i, int num, int position)
        {

            var half = 0.5f;
            int double1 = 2;
            int tripple = 3;
            float final = 0.0f;


            if (num == 1)
            {
                final = half * recipeList[position].ingredientsList[i].quantityOfIngredient;
            }
            else
            {
                if (num == 2)
                {
                    final = double1 * recipeList[position].ingredientsList[i].quantityOfIngredient;
                }
                else
                {
                    if (num == 3)
                    {
                        final = tripple * recipeList[position].ingredientsList[i].quantityOfIngredient;
                    }
                    else
                    {
                        //reset of the ingredient bust still be done here 
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
            int index = 0;
            bool reloop = false;
            int position = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please choose which recipe to Scale: ");


            //this do while loop will run until the user enters YES or NO in caps or lowercase
            List<string> copyOfNameList = new List<string>();

            for (int k = 0; k < recipeList.Count; k++)
            {
                copyOfNameList.Add(recipeList[k].RecipeName);
            }

            List<string> sortedNameList = copyOfNameList.OrderBy(name => name).ToList();

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

                        position = recipeList.IndexOf(recipeList.Find(recipe => recipe.RecipeName == recipeName));
                        reloop = true;
                    }
                    else
                    {
                        if (choice == sortedNameList.Count + 1)
                        {
                            reloop = true;
                            MainMenu();
                        }
                        else
                        {
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
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please re-choose which recipe to Scale: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    reloop = false;
                }
            } while (reloop == false);
            string confirm;bool reAsk = false;
            do
            {
                //var choice = string.Empty;
                
                //IngredientsListWorker = recipe_Class.ingredientsList;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Would you like to scale the recipe? (YES/NO): ");
                confirm = (Console.ReadLine()).ToUpper();

                if ((confirm.Equals("YES")) || (confirm.Equals("NO"))) //if the user enters Yes the user will be asked to half, double or tripple the quantity
                                                                     //of the ingredient
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
                    try //This will try to convert the string to a integer and if not able to it will re-ask the user to enter a intager between 0 and 5
                    {

                        if (Int32.TryParse(input, out option))
                        {
                            option = Convert.ToInt32(input);

                            if ((option > 0) && (option < 5))
                            {

                                valid = true;
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
                                valid = false;
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


                for (int i = 0; i < recipeList[position].ingredientsList.Count; i++) //Calls the ScalingCalc method and the ChangeUnits method
                {
                    switch (num) //runs if the users input is 1,2,3 or 4 
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
                            recipeList[position].ingredientsList[i].quantityOfIngredient = ScalingCalc(i, num, position);
                            ChangeUnits(i, position);
                            break;

                        default:
                            recipeList[position].ingredientsList[i].quantityOfIngredient = resetIngredientQuantity[i];
                            recipeList[position].ingredientsList[i].unitOfIngredient = resetIngredientUnits[i];
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
        public void ChangeUnits(int i,int position)
        {


            if (recipeList[position].ingredientsList[i].unitOfIngredient == "l")
            {
                recipeList[position].ingredientsList[i].quantityOfIngredient = recipeList[position].ingredientsList[i].quantityOfIngredient * 1000;
                recipeList[position].ingredientsList[i].unitOfIngredient = "ml";
            }
            if (recipeList[position].ingredientsList[i].unitOfIngredient == "ml")
            {
                if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 3785)
                {
                    recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 3785), 1);
                    recipeList[position].ingredientsList[i].unitOfIngredient = "gallon";
                }
                else
                {
                    if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 240)
                    {
                        recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 240), 1);
                        recipeList[position].ingredientsList[i].unitOfIngredient = "cups";
                    }
                    else
                    {
                        if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 15)
                        {
                            recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 15), 1);
                            recipeList[position].ingredientsList[i].unitOfIngredient = "tablespoons";
                        }
                        else
                        {
                            if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 5)
                            {
                                recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 5), 1);
                                recipeList[position].ingredientsList[i].unitOfIngredient = "teaspoons";
                            }
                            else
                            {
                                recipeList[position].ingredientsList[i].unitOfIngredient = "ml";
                            }
                        }
                    }
                }
            }

            if ((recipeList[position].ingredientsList[i].unitOfIngredient == "teaspoon") || recipeList[position].ingredientsList[i].unitOfIngredient == "teaspoons")
            {
                if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 3)
                {
                    recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 3), 1);
                    recipeList[position].ingredientsList[i].unitOfIngredient = "tablespoons";
                }
                else
                {
                    if (recipeList[position].ingredientsList[i].quantityOfIngredient == 1)
                    {
                        recipeList[position].ingredientsList[i].unitOfIngredient = "teaspoon";
                    }
                }
            }
            else
            {
                if ((recipeList[position].ingredientsList[i].unitOfIngredient == "tablespoon") || recipeList[position].ingredientsList[i].unitOfIngredient == "tablespoons")
                {
                    if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 16)
                    {
                        recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 16), 1);
                        recipeList[position].ingredientsList[i].unitOfIngredient = "cups";
                    }
                    else
                    {
                        if (recipeList[position].ingredientsList[i].quantityOfIngredient == 1)
                        {
                            recipeList[position].ingredientsList[i].unitOfIngredient = "tablespoon";
                        }
                    }

                }

                if ((recipeList[position].ingredientsList[i].unitOfIngredient == "cup") || recipeList[position].ingredientsList[i].unitOfIngredient == "cups")
                {
                    if (recipeList[position].ingredientsList[i].quantityOfIngredient >= 16)
                    {
                        recipeList[position].ingredientsList[i].quantityOfIngredient = (float)Math.Round((double)(recipeList[position].ingredientsList[i].quantityOfIngredient / 16), 1);
                        recipeList[position].ingredientsList[i].unitOfIngredient = "gallons";
                    }
                    else
                    {
                        if (recipeList[position].ingredientsList[i].quantityOfIngredient == 1)
                        {
                            recipeList[position].ingredientsList[i].unitOfIngredient = "cup";
                        }
                        else
                        {
                            if (recipeList[position].ingredientsList[i].quantityOfIngredient < 16)
                            {
                                recipeList[position].ingredientsList[i].unitOfIngredient = "cups";
                            }
                        }
                    }
                }

            }

            if ((recipeList[position].ingredientsList[i].unitOfIngredient == "gallon") || recipeList[position].ingredientsList[i].unitOfIngredient == "gallons")
            {
                if (recipeList[position].ingredientsList[i].quantityOfIngredient == 1)
                {
                    recipeList[position].ingredientsList[i].unitOfIngredient = "gallon";
                }
                else
                {
                    recipeList[position].ingredientsList[i].unitOfIngredient = "gallons";
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

                        if ((option > 0) && (option < 6))
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
                    if (reloop != false)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

            } while (reloop == false);

            switch (option) //Depending on what the users enter different methods will be called 
            {
                case 1:
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
                                IngredientsListWorker.Clear();
                                IngredientsListWorker = null;
                                StepsListWorker = null;

                                if (IngredientsListWorker == null && StepsListWorker == null)
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
                            if (input == "YES")
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
                    recipeNames = new List<string>();
                    RecipesStepsList = new List<List<string>>();
                    RecipesIngredientsList = new List<List<Ingredient_class>>();
                    AddRecipeToList();
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

        private void DisplayRecipes(List<string> sortedNameList)
        {
            for (int i = 0; i < sortedNameList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedNameList[i]}");
            }

            Console.WriteLine($"{sortedNameList.Count + 1}. Back");
            Console.Write(">");
        }

        /// <summary>
        /// method will display user input
        /// </summary>
        public void Display()
        {
            int recipeIndex = -1;
            bool reloop = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please choose which recipe to display: ");


            do
            {
                List<string> copyOfNameList = new List<string>();

                for(int k = 0; k < recipeList.Count; k++)
                {
                    copyOfNameList.Add(recipeList[k].RecipeName);
                }

                List<string> sortedNameList = copyOfNameList.OrderBy(name => name).ToList();

                DisplayRecipes(sortedNameList);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= sortedNameList.Count)
                    {
                        recipeIndex = choice - 1;
                        string recipeName = sortedNameList[recipeIndex];

                        int position = recipeList.IndexOf(recipeList.Find(recipe => recipe.RecipeName == recipeName));

                        if (position >= 0 && position < recipeList.Count)
                        {
                            if (IngredientsListWorker != null && StepsListWorker != null)
                            {

                                Recipe_class selected = recipeList.Find(recipe => recipe.RecipeName == recipeName);
                                List<Steps_class> S = recipeList[position].stepsList;
                                List<Ingredient_class> I = recipeList[position].ingredientsList;

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("---------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Recipe: " + recipeName);   //code for name display 
                                Console.WriteLine("Ingredients:\r\n");

                                

                                for (int i = 0; i < I.Count; i++) //loops through and display each element in the array in the format of
                                                                                //quantity space unit space of space name
                                {

                                    Console.WriteLine((i + 1) + ". " + I[i].quantityOfIngredient + " " + I[i].unitOfIngredient +
                                        " of " + I[i].ingredientName + " " + "(" + I[i].numberOfCalories + " " + "calories)");

                                    Console.WriteLine("(Food group: " + I[i].FoodGroup + ") ");

                                    Console.WriteLine();

                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("---------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Steps:\r\n");
                                for (int j = 0; j < S.Count; j++) //loops through and display each element in the array in the format of
                                                                          //1. discription of the step
                                {
                                    Console.WriteLine((j + 1) + ". " + S[j].ingredientSteps);
                                }

                                reloop = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("---------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("No recipes to display.");
                            }
                            reloop = true;
                        }


                    }
                    else
                    {
                        if (choice == (sortedNameList.Count + 1))
                        {
                            MainMenu();
                            reloop = true;
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
}
