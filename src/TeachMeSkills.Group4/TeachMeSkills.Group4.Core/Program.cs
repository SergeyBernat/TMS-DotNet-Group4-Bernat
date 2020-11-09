using System;
using System.Collections.Generic;
using TeachMeSkills.Group4.Core;

namespace TeachMeSkills.Group4.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Purchaser> purchasers = Purchaser.GetPurchaserRND();
            Cassa cassa = new Cassa { };
            Cassa.GetPurchaserByGegericList(purchasers, cassa);
        }
    }
}
