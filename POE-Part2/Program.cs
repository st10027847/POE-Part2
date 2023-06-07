using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Part2
{
        class Recipe
        {
            public string Name { get; set; }
            public List<Ingredient> Ingredients { get; set; }
            public List<string> Steps { get; set; }

            public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
            {
                Name = name;
                Ingredients = ingredients;
                Steps = steps;
            }
        }

        class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            public int Calories { get; set; }
            public string FoodGroup { get; set; }

            public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
                Calories = calories;
                FoodGroup = foodGroup;
            }
        }

        class Program
        {

            static List<Recipe> recipes = new List<Recipe>();
            delegate void NotifyUserDelegate(string message);

            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Add a recipe");
                    Console.WriteLine("2. Display a recipe");
                    Console.WriteLine("3. List all recipes");
                    Console.WriteLine("4. Clear all recipes");
                    Console.WriteLine("5. Exit");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddRecipe();
                            break;
                        case "2":
                            DisplayRecipe();
                            break;
                        case "3":
                            ListRecipes();
                            break;
                        case "4":
                            ClearRecipes();
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }

            static void AddRecipe()
            {
                Console.WriteLine("Enter the name of the recipe:");
                string name = Console.ReadLine();

                List<Ingredient> ingredients = new List<Ingredient>();
                Console.WriteLine("Enter the number of ingredients:");
                int numIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter the name of ingredient #{i + 1}: ");
                    string ingredientName = Console.ReadLine();

                    Console.WriteLine($"Enter the quantity of {ingredientName} ({i + 1}{ingredientName}):");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter the unit of measurement for {ingredientName} ({i + 1} {ingredientName}):");
                    string unit = Console.ReadLine();

                    Console.WriteLine($"Enter the number of calories per unit for {ingredientName} ({i + 1} {ingredientName}):");
                    int calories = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter the food group for {ingredientName} ({i + 1} {ingredientName})");
                    string foodGroup = Console.ReadLine();

                    Ingredient ingredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroup);
                    ingredients.Add(ingredient);
                }
                Console.WriteLine("Enter the preparation steps (enter 'done' to finish):");
                List<string> steps = new List<string>();

                while (true)
                {
                    string step = Console.ReadLine();
                    if (step.ToLower() == "done")
                    {
                        break;
                    }
                    steps.Add(step);
                }

                Recipe recipe = new Recipe(name, ingredients, steps);
                recipes.Add(recipe);

                int totalCalories = recipe.Ingredients.Sum(i => i.Calories);
                if (totalCalories > 300)
                {
                    NotifyUser("Warning: This recipe exceeds 300 calories.");
                }
            }

            static void DisplayRecipe()
            {
                Console.WriteLine("Enter the name of the recipe:");
                string name = Console.ReadLine();

                Recipe recipe = recipes.Find(r => r.Name.ToLower() == name.ToLower());
                if (recipe == null)
                {
                    Console.WriteLine("Recipe not found.");
                    return;
                }

                Console.WriteLine($"Ingredients for {recipe.Name}:");
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} {ingredient.Calories} calories, {ingredient.FoodGroup} food group");
                }

                Console.WriteLine($"Preparation steps for {recipe.Name}:");
                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
                }

                int totalCalories = recipe.Ingredients.Sum(i => i.Calories);
                Console.WriteLine($"Total calories: {totalCalories}");
            }

            static void ListRecipes()
            {
                recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));


                Console.WriteLine("List of recipes:");
                foreach (Recipe recipe in recipes)
                {
                    Console.WriteLine($"- {recipe.Name}");
                }
            }

            static void ClearRecipes()
            {
                recipes.Clear();
                Console.WriteLine("All recipes cleared.");
            }

            static void NotifyUser(string message)
            {
                Console.WriteLine(message);
            }
        }
    }

    /*
    Main Changes made to the code from Part 1:

    Changed arrays to Lists
    Added Delegate to code
    Added Get/Set methods to code
    Adjusted respective code according to the change of arrays to Lists.
    Modified code according to prior changes (Arrays to Lists).
     */
