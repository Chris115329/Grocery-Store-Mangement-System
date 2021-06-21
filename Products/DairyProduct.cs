using System;
using System.Collections.Generic;
using System.Text;


namespace Products
{
   public class DairyProduct : Product
    {
      
        // Static Property to keep track of the number of pieces on truck 
        public static int DairyTruckCount { get; set; }

        static DairyProduct()
        {
            // The initial Dairy Truck is 300 Pieces
            DairyTruckCount = 300;

        }

        public DairyProduct(string bname, string pname, string size, double price)
        {
            // All Dairy Products get an ID between 900 and 1000
            Random r = new Random();
            int genRand = r.Next(900, 1000);
            ProductID = genRand;

            BrandName = bname;
            ProductName = pname;
            Department = "Dairy";
            Size = size;
            Price = price;

        }

       



    }
}
