using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace TeachMeSkills.Group4.Core
{
    public class CashBox
    {
        List<Purchaser> list = new List<Purchaser>();
        static Guid guid = Guid.NewGuid();
        static object locker = new object();
        public static SemaphoreSlim Semaphore { get; set; } = new SemaphoreSlim(6, 6);
        public string cashboxNumber { get; set; }
        public List<Purchaser> cashboxPurchasers { get; set; }

        public static List<Purchaser> GetPurchaserRND(List<Purchaser> purchasers, int userInputbuyer)
        {
            for (int i = 1; i < (int)userInputbuyer + 1; i++)
            {
                var purch = new Purchaser()
                {
                    purchaserThread = new Thread(Queue),
                };
                purchasers.Add(purch);
            }
            return purchasers;
        }
        public static List<Purchaser> GetPurchasersForCashbox(object purchasers)
        {
            List<Purchaser> list = new List<Purchaser>();
            list = (List<Purchaser>)purchasers;
            var sdf = new List<Purchaser>();
            while (list.Count > 0)
            {

                if (list.Count != 0)
                {
                    try
                    {
                        lock (locker)
                        {
                            sdf.Add(list.First());
                            list.Remove(list.First());
                            Thread.Sleep(10);
                            
                        }
                    }
                    catch (System.InvalidOperationException)
                    {

                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return sdf;
        }
        public static void Run(object purchasers)
        {
            CashBox cashBox = new CashBox
            {
                cashboxNumber = Thread.CurrentThread.Name,
                cashboxPurchasers = GetPurchasersForCashbox(purchasers)
            };
            string path = @$"C:\TMS-DotNet-Group4-Bernat\checks_{ DateTime.Now.ToShortDateString()}";
            string subpath = @$"Test№{guid}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            string writePath = @$"C:\TMS-DotNet-Group4-Bernat\checks_{ DateTime.Now.ToShortDateString()}\Test№{guid}\Cashbox_{cashBox.cashboxNumber}.txt";
            string text = $"C̲h̲e̲c̲k̲ C̲a̲s̲h̲b̲o̲x̲ {cashBox.cashboxNumber} || Total number of buyers: {cashBox.cashboxPurchasers.Count}\n\nRemaining customer checks:\n";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default)) { sw.WriteLine(text); }
            PurchasersThreadStart(cashBox);
        }
        public static void PurchasersThreadStart(CashBox cashBox)
        {
            while (cashBox.cashboxPurchasers.Count != 0)
            {
                var purchaser = cashBox.cashboxPurchasers.First();
                purchaser.purchaserThread.Name = "Thread";
                purchaser.purchaserThread.Start(purchaser);
                purchaser.CurrentCashbox = Thread.CurrentThread.Name;
                cashBox.cashboxPurchasers.Remove(purchaser);
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
                        //Console.WriteLine("зашел");
                        OutputToTxt(purchaserBacketByThread);
                    }
                    Semaphore.Release();
                    Thread.CurrentThread.Interrupt();
                }
                else
                {
                    //Console.WriteLine("уходит");
                    Semaphore.Release();
                }
            }
        }
        public static void OutputToTxt(object purchaserBacketByThread)
        {
            List<Purchaser> currentBacketBPurchaser = new List<Purchaser>();
            var current = (Purchaser)purchaserBacketByThread;
            currentBacketBPurchaser.Add(current);
            foreach (var item in currentBacketBPurchaser)
            {
                string writePath = @$"C:\TMS-DotNet-Group4-Bernat\checks_{ DateTime.Now.ToShortDateString()}\Test№{guid}\Cashbox_{item.CurrentCashbox}.txt";
                string buyerName;
                buyerName = item.Name;
                var a = item.basket;
                List<decimal> Sum = new List<decimal>();
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"Check [{buyerName}]");
                    foreach (var value in a)
                    {
                        string textName;
                        string textPrice;
                        textName = value.Name;
                        textPrice = value.Price.ToString();
                        Sum.Add(value.Price);
                        sw.WriteLine($"{textName} - {textPrice}$");
                    }
                    sw.WriteLine($"G̲e̲n̲e̲r̲a̲l̲ s̲u̲m̲: {Sum.Sum()}$");
                    sw.WriteLine("");
                }
            }
        }
    }
}
