using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TeachMeSkills.Group4.Core;

namespace TeachMeSkills.Group4.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateCashBox();
        }
        public static void CreateCashBox()
        {
            var t = new Thread(CashBox1.Run);
            t.Start();
            var t2 = new Thread(CashBox2.Run);
            t2.Start();
            var t3 = new Thread(CashBox3.Run);
            t3.Start();
            var t4 = new Thread(CashBox4.Run);
            t4.Start();
        }
    }

}