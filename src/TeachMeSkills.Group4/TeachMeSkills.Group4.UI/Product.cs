using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                "sausage","tenderloin","turkey"
                    ,"veal","venison"};
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
            for (int i = 1; i <= rnd.Next(1, 11); i++)
            {
                var class1 = new Product{ };
                class1List.Add(class1);
            }
            return class1List;
        }


    }
}
