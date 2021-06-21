using System;
using System.Collections.Generic;
using System.Text;

namespace Products
{
   public abstract class Product
    {
        public int ProductID { get; set; }
       public string BrandName { get; set; }
       public string ProductName { get; set; }
        public string Department { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }

        public void Print()
        {
            Console.WriteLine($" Product Id: {ProductID} BrandName: {BrandName}, ProductName: {ProductName}, Department: {Department}, Size: {Size} Price: {Price} ");

        }

        



    }
}
