using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace TeachMeSkills.Group4.Core
{
    public class Cassa
    {
        public int Number { get; set; }

        public Queue<Purchaser> Queue { get; set; } = new Queue<Purchaser>();
        public int MaxQueueLenght { get; set; } = 5;


        public static void GetPurchaserByGegericList(List<Purchaser> purchasers, Cassa cassa)
        {
            foreach (var item in purchasers)
            {
                cassa.Queue.Enqueue(item);
            }
            Last(cassa);
        }
    public static void Last(Cassa cassa)
    {
        cassa.Queue.Dequeue();
        Console.WriteLine(cassa.Queue.Count);
        Console.ReadLine();
    }
    }

}

