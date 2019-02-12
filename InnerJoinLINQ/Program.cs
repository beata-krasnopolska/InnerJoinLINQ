using System;
using System.Collections.Generic;
using System.Linq;

namespace InnerJoinLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program allows to join two lists of data sets");
            List<Products> productsList = new List<Products>()
            {
                new Products { ItemId = 1, ItemDes = "Biscuit  " },
                new Products { ItemId = 2, ItemDes = "Chocolate" },
                new Products { ItemId = 3, ItemDes = "Butter   " },
                new Products { ItemId = 4, ItemDes = "Brade    " },
                new Products { ItemId = 5, ItemDes = "Honey    " }
            };
            List<Purchase> purchList = new List<Purchase>
            {
                new Purchase { InvNo=100, ItemId = 3,  PurQty = 800 },
                new Purchase { InvNo=101, ItemId = 2,  PurQty = 650 },
                new Purchase { InvNo=102, ItemId = 3,  PurQty = 900 },
                new Purchase { InvNo=103, ItemId = 4,  PurQty = 700 },
                new Purchase { InvNo=104, ItemId = 3,  PurQty = 900 },
                new Purchase { InvNo=105, ItemId = 4,  PurQty = 650 },
                new Purchase { InvNo=106, ItemId = 1,  PurQty = 458 }
            };

            var innerJoin = from prod in productsList
                            join b in purchList on prod.ItemId equals b.ItemId
                            select new
                            {
                                itemId = prod.ItemId,
                                itemDescription = prod.ItemDes,
                                pQuality = b.PurQty
                            };
            foreach (var data in innerJoin)
            {
                Console.WriteLine("Item ID: {0}, Item Name: {1}, Purchase Quality: {2}", data.itemId, data.itemDescription, data.pQuality);
            }
            Console.ReadKey();
        }
    }
}
