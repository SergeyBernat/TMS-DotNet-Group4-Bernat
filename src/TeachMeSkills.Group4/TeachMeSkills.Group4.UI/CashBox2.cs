using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace TeachMeSkills.Group4.Core
{
    public class CashBox2
    {
        static object locker = new object();
        public static SemaphoreSlim Semaphore { get; set; } = new SemaphoreSlim(5, 5);
        public int cashboxNumber { get; set; } = 1;
        public List<Purchaser> purchasers { get; set; } = GetPurchaserRND();
        public static List<Purchaser> GetPurchaserRND()
        {
            var purchaserList = new List<Purchaser>();
            for (int i = 1; i < 160; i++)
            {
                var purch = new Purchaser()
                {
                    purchaserThread = new Thread(Queue),
                };
                purchaserList.Add(purch);
            }
            return purchaserList;
        }
        public static void Run()
        {
            string writePath = @"C:\Users\vinex\source\repos\TMS-DotNet-Group4-Bernat\Cashbox_2.txt";
            string text = "C̲h̲e̲c̲k̲ C̲a̲s̲h̲b̲o̲x̲ 2:\n";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
            CashBox2 cashBox = new CashBox2 { };
            PurchasersThreadStart(cashBox);
        }
        public static void PurchasersThreadStart(CashBox2 cashBox)
        {
            while (cashBox.purchasers.Count != 0)
            {
                var purchaser = cashBox.purchasers.First();
                purchaser.purchaserThread.Name = "Thread";
                purchaser.purchaserThread.Start(purchaser);
                cashBox.purchasers.Remove(purchaser);
            }
        }
        public static void Queue(object purchaserBacketByThread)
        {
            if (Thread.CurrentThread.Name == "Thread")
            {
                Semaphore.Wait();
                if (Semaphore.CurrentCount != 0)
                {
                    lock (locker)
                    {
                        Console.WriteLine("зашел");
                        OutputToTxt(purchaserBacketByThread);
                    }
                    Semaphore.Release();
                    Thread.CurrentThread.Interrupt();
                }
                else
                {
                    Console.WriteLine("уходит");
                    Semaphore.Release();
                }
            }
        }
        public static void OutputToTxt(object purchaserBacketByThread)
        {
            string writePath = @"C:\Users\vinex\source\repos\TMS-DotNet-Group4-Bernat\Cashbox_2.txt";
            List<Purchaser> currentBacketBPurchaser = new List<Purchaser>();
            var current = (Purchaser)purchaserBacketByThread;
            currentBacketBPurchaser.Add(current);
            foreach (var item in currentBacketBPurchaser)
            {
                string buyerName;
                buyerName = item.Name;
                var a = item.basket;
                List<decimal> Sum = new List<decimal>();
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"Check _{buyerName}_");
                }
                foreach (var value in a)
                {
                    string textName;
                    string textPrice;
                    textName = value.Name;
                    textPrice = value.Price.ToString();
                    Sum.Add(value.Price);
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine($"{textName} - {textPrice}$");
                    }
                }
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"G̲e̲n̲e̲r̲a̲l̲ s̲u̲m̲: {Sum.Sum()}$");
                }
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("");
                }
            }
        }
    }
}
