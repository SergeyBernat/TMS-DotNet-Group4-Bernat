using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TeachMeSkills.Group4.Core;

namespace TeachMeSkills.Group4.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Purchaser> purchasers = new List<Purchaser>();
            Console.WriteLine("Enter total number of buyer:");
            var userInputbuyer = int.Parse(Console.ReadLine());
            purchasers = CashBox.GetPurchaserRND(purchasers,userInputbuyer);
            string path = @"C:\TMS-DotNet-Group4-Bernat";
            string subpath = @$"checks_{DateTime.Now.ToShortDateString()}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            Console.WriteLine("Enter total number of cashboxes:");
            var userInputcashbox = int.Parse(Console.ReadLine());
            for (int i = 1; i < userInputcashbox + 1; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(CashBox.Run));
                t.Name = i.ToString();
                t.Start(purchasers);
                Thread.Sleep(2);
            }
        }
    }
}