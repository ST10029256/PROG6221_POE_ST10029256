﻿using System;
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

        public int GetNumberOfIngredients()//1
        {

            Console.Write("Please enter the number of ingredients: ");
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
                        this.numberOfIngredients = num;
                        reloop = true;
                    }
                    else
                    {
                        Console.Write("Please re-enter the number of ingredients: ");
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

        public string GetingredientName() 
        {

            Console.Write("Enter name of Ingredient: ");
            string name = Console.ReadLine();

            bool reloop = false;

            do
            {
                try
                {

                    if ((!name.Equals(null)) && (!name.Equals(string.Empty))) 
                    {
                        this.ingredientName = name;
                        reloop = true;
                    }
                    else
                    {
                        Console.Write("Re-enter name of Ingredient: ");
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

        public float GetQuantityOfIngredient() 
        {

            Console.Write("Enter the quantity of the ingredient: ");
            string quantity = Console.ReadLine();

            float num = 0;
            bool reloop = false;

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
                        Console.Write("Re-enter the quantity of the ingredient: ");
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

        public string GetUnitOfIngredient()
        {
            string[] units = {"cups", "cup", "tablespoons", "tablespoon", "teaspoons" , "teaspoon", "ml", "l", "g", "kg", "gallon", "gallons"};


            Console.Write("Enter the unit of mesurement: ");
            string unit = Console.ReadLine();

            bool reloop = false;

            do
            {
                try
                {

                    if ((!unit.Equals(null)) && (!unit.Equals(string.Empty)))
                    {
                        this.unitOfIngredient = unit;

                        if (units.Contains(unit))
                        {
                            reloop = true;
                        }
                        else
                        {
                            Console.Write("Re-enter the unit of mesurement: ");
                            unit = Console.ReadLine();
                            reloop = false;
                        }
                        
                    }
                    else
                    {
                        Console.Write("Re-enter the unit of mesurement: ");
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
