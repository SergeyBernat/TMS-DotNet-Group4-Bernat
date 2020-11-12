using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachMeSkills.Group4.Core
{
    public class ReceiptOfPayment
    {
        public List<Purchaser> Purchasers { get; set; } = Purchaser.GetPurchaserRND();
        public static void BasketProd(List<Purchaser> purchasers)
        {
            foreach (var item in purchasers)
            {
                Console.WriteLine($"----\n {item.Name}");

                foreach (var item1 in item.basket)
                {
                    Console.WriteLine($"Product name: {item1.Name} \nProduct price: {item1.Price}");
                }

                var basketProdName = item.basket.Select(basket => basket.Name.ToString());
                var basketProdPrice = item.basket.Select(basket => basket.Price);
                Console.WriteLine($"\nsum total: {basketProdPrice.Sum()}");

            }
        }

    }
    }
