using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface Item
    {
        string name();
        Packing packing();
        float price();
    }

    public interface Packing
    {
        string pack();
    }

    public abstract class Burger : Item
    {
        public Packing packing()
        {
            return new Wrapper();
        }

        public abstract float price();

        public string name()
        {
            return "Deluxe Tasty Burger";
        }
    }

    public abstract class ColdDrink : Item
    {
        public string name()
        {
            return "Ice Cold Beverage";
        }

        public Packing packing()
        {
            return new Bottle();
        }

        public abstract float price();
    }


    public class Wrapper : Packing
    {
        public string pack()
        {
            return "Wrapper";
        }
    }

    public class Bottle : Packing
    {
        public string pack()
        {
            return "Bottle";
        }
    }

    public class VeggieBurger : Burger
    {
        public override float price()
        {
            return 17.00f;
        }

        public string name()
        {
            return "Veg Burger";
        }
    }

    public class ChickenBurger : Burger
    {
        public override float price()
        {
            return 20.00f;
        }
    }

    public class Pepsi : ColdDrink
    {
        public override float price()
        {
            return 5.99f;
        }

        public string name()
        {
            return "Pepsi";
        }
    }

    public class DrPepper : ColdDrink
    {
        public override float price()
        {
            return 5.99f;
        }
        public string name()
        {
            return "DrPepper";
        }
    }

    public class Meal
    {
        private List<Item> items = new List<Item>();

        public void addItem(Item item)
        {
            items.Add(item);
        }

        public float getCost()
        {
            float cost = 0.0f;
            foreach (Item item in items)
            {
                cost += item.price();
            }
            return cost;
        }

        public void showItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine("Item : {0}", item.name());
                Console.WriteLine("Packing : {0}", item.packing().pack());
                Console.WriteLine("Price : ${0}\n", item.price());
            }
        }
    }

    public class MealBuilder
    {
        public Meal prepVeggieMeal()
        {
            Meal meal = new Meal();
            meal.addItem(new VeggieBurger());
            meal.addItem(new Pepsi());
            return meal;
        }

        public Meal prepMeatMeal()
        {
            Meal meal = new Meal();
            meal.addItem(new ChickenBurger());
            meal.addItem(new DrPepper());
            return meal;
        }
    }

    class BuilderProgram
    {
        /// <summary>
        /// The Builder Demo 
        /// Separates the construction of a complex object from its representation 
        /// so that the same construction process can create different representations
        /// Great for Parsing data, building from a template and Making a burger!
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.prepVeggieMeal();
            Console.WriteLine("Vegetarian Meal");
            vegMeal.showItems();
            Console.WriteLine("Total Cost: ${0}", vegMeal.getCost());

            Meal meatMeal = mealBuilder.prepMeatMeal();
            Console.WriteLine("Meaty Meal");
            meatMeal.showItems();
            Console.WriteLine("Total Cost: ${0}", meatMeal.getCost());

            Console.Read();

        }
    }
}
