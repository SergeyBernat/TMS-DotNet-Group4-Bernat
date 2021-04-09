using System;
using System.Collections.Generic;
using System.Threading;

namespace TeachMeSkills.Group4.Core
{
    public class Purchaser
    {
        public Thread purchaserThread;
        public string CurrentCashbox { get; set; }
        public string Name { get; set; }
        public decimal Cash { get; set; }
        public List<Product> basket { get; set; } = Product.GetRNDProduct();

        public Purchaser()
        {
            basket = basket;
            Name = GetPurchaserName();
            Cash = GetPurchaserCash();
        }

        private static string GetPurchaserName()
        {
            Random rnd = new Random();
            string[] Names = {"Liam", "Olivia", "Noah", "Emma",
                "Oliver", "Ava", "William", "Sophia", "Elijah",
                "Isabella" , "James", "Charlotte", "Benjamin",
                "Amelia", "Lucas", "Mia", "Abigail", "Ada",
                "Adelina", "Agatha", "Alexa", "Bailey",
                "Barbara", "Beatrice", "Cameron", "Carl", "Carlos",
                "Charles","Christopher", "Daniel", "David", "Dennis",
                "Devin", "Diego","Harold", "Harry", "Hayden", "Henry",
                "Jack", "Jackson", "Jacob","Jaden", "Jake", "Katelyn",
                "Katherine", "Kathryn", "Kayla","Laura", "Lauren", "Leah",
                "Leonora", "Leslie", "Nancy", "Natalie","Nicole", "Nora",
                "Patricia", "Pauline", "Penelope", "Priscilla","Ralph",
                "Raymond", "Reginald", "Rita", "Rosaline", "Rose", "Simon",
                "Stanley", "Steven", "Vanessa", "Victoria", "Wallace", "Walter"};
            int Index = rnd.Next(Names.Length);
            string name = Names[Index];
            return name;
        }

        private static decimal GetPurchaserCash()
        {
            Random rnd = new Random();
            return rnd.Next(1, 20);
        }
    }
}
