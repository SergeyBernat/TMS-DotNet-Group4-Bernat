using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TeachMeSkills.Group4.Core
{
    public class Purchaser
    {
        //Thread purchaserThread;
        public string Name { get; set; }
        public decimal Cash { get; set; }
        public List<Product> basket { get; set; } = Product.GetRNDProduct();
        public Purchaser(int i)
        {
            //purchaserThread = new Thread(Cassa.RUN);
           //purchaserThread.Name = $"Thread {i}";
            basket = basket;
            Name = GetPurchaserName();
            Cash = GetPurchaserCash();
           // purchaserThread.Start();
        }
        public static string GetPurchaserName()
        {
            Random rnd = new Random();
            string[] Names = {"Liam", "Olivia", "Noah", "Emma", 
                "Oliver", "Ava", "William", "Sophia", "Elijah", 
                "Isabella" , "James", "Charlotte", "Benjamin", 
                "Amelia", "Lucas", "Mia"};
            int Index = rnd.Next(Names.Length);
            string name = Names[Index];
            return name;
        }
        public static decimal GetPurchaserCash()
        {
            Random rnd = new Random();
            return rnd.Next(1, 100);
        }
        public static List<Purchaser> GetPurchaserRND()
        {
            List<Purchaser> purchaserList = new List<Purchaser>();
            //var ticks = new List<int>();
            //Queue<Purchaser> queue = new Queue<Purchaser>();
            for (int i = 1; i < 15; i++)
            {
                var purch = new Purchaser(i) { };
                purchaserList.Add(purch);
               // queue.Enqueue(purch);
                
               /* foreach (var item in purch.basket)
                {
                    int result = item.TicksStop;
                    ticks.Add(result);
                }*/
            }
            return purchaserList;
            /* Console.WriteLine(ticks.Sum());
                    return ticks.Sum();*/
        }
    }
}
