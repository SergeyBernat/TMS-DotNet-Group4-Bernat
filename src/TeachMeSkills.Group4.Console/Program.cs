using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TeachMeSkills.Group4.Core;

namespace TeachMeSkills.Group4.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Purchaser> purchasers = new List<Purchaser>();
            System.Console.WriteLine("Enter total number of buyer:");
            var userInputbuyer = int.Parse(System.Console.ReadLine());
            purchasers = CashBox.GetPurchaserRND(purchasers, userInputbuyer);
            System.Console.WriteLine("Path to reports: C:/TMS-DotNet-Group4-Bernat");
            string path = @"C:\TMS-DotNet-Group4-Bernat";
            string subpath = @$"checks_{DateTime.Now.ToShortDateString()}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            System.Console.WriteLine("Enter total number of cashboxes:");
            var userInputcashbox = int.Parse(System.Console.ReadLine());
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
