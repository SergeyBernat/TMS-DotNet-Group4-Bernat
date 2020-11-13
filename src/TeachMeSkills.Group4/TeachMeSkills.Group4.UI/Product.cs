using System;
using System.Collections.Generic;

namespace TeachMeSkills.Group4.Core
{
    public class Product
    {
        public string Name { get; set; } = GetProductName();
        public decimal Price { get; set; } = GetProductPrice();
        public int TicksStop { get; set; } = GetClass1Ticks();
        public static string GetProductName()
        {
            Random rnd = new Random();
            string[] ProductName = { "bacon","beef","chicken",
                "duck","ham","lamb","liver","meat","mutton",
                "ox tongue","patridge","pork","poultry",
                "sausage","tenderloin","turkey","veal",
                "venison", "beer", "milk", "bread", "chips",
                "chocolate", "soda", "sugar", "cucumber",
                "watermelon", "sushi", "pizza", "nuts",
                "orange", "potato", "onion", "cheese",
                "mineral water", "toilet paper", "sourcream",
                "washing powder", "soap", "bun", "pasta",
                "rice", "bananas", "oatmeel", "tea", "coffee",
                "carrot", "cinnamon", "shampoo", "ketchup",
                "raisins", "sunflower seeds", "olives",
                "mushrooms", "wheat flour", "peas", "beans",
                "toothpaste", "butter", "canned food", "cabbage",
            };
            int Index = rnd.Next(ProductName.Length);
            string name = ProductName[Index];
            return name;
        }
        public static decimal GetProductPrice()
        {
            Random rnd = new Random();
            return rnd.Next(1, 100);
        }
        public static int GetClass1Ticks()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 5000);
        }

        public static List<Product> GetRNDProduct()
        {
            Random rnd = new Random();

            List<Product> class1List = new List<Product>();
            int productsCount = rnd.Next(1, 11);
            for (int i = 0; i < productsCount; i++)
            {
                var class1 = new Product { };
                class1List.Add(class1);
            }
            return class1List;
        }
    }
}