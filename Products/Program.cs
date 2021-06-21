using System;
using System.Collections.Generic;
using System.Linq;

namespace Products
{
    class Program
    {
        // global variable to keep track of the number of pieces to add to the truck
        static int count;

        static void Main(string[] args)
        {
             // Empty List of Dairy Products
            List<DairyProduct> DairyProducts = new List<DairyProduct>();
           
              // Fill the List with the appropriate data from the DairyProductList() method 
            DairyProducts = DairyProductList();


            Console.WriteLine("Welcome to the Dairy Department!");

            // Show Main Menu
            MainMenu(DairyProducts);
          
             }

        static void QueryAllMilkProducts(List<DairyProduct> DairyProducts)
        {
            // Query all the milk products
            var query = from m in DairyProducts
                        where m.ProductName.Contains("Milk")
                        orderby m.Price ascending
                        select new
                        {
                            m.BrandName,
                            m.ProductName,
                            m.Size,
                            m.Price
                        };
            Console.WriteLine();


            Console.WriteLine("All our Store Brand Milk Products are Listed Below:");

            // Output Milk Query
            foreach (var milk in query)
            {
                Console.WriteLine(milk);
            }



        }

        static void QueryAllCheeseProducts(List<DairyProduct> DairyProducts)
        {
            // Query all Cheese
            var query = from m in DairyProducts                   // Making sure no yogurt product comes up if it has "Cheese" in its name
                        where m.ProductName.Contains("Cheese") && !m.ProductName.Contains("Yogurt")
                        orderby m.Price ascending
                        select new
                        {
                            m.BrandName,
                            m.ProductName,
                            m.Size,
                            m.Price
                        };
            Console.WriteLine();
            Console.WriteLine("All our Cheese Products are Listed Below:");

            // output Cheese Query
            foreach (var cheese in query)
            {
                Console.WriteLine(cheese);
            }

        }

        static void QueryAllJuiceProducts(List<DairyProduct> DairyProducts)
        {

            // Query all Juice
            var query = from m in DairyProducts
                        where m.ProductName.Contains("Juice")
                        orderby m.Price ascending
                        select new
                        {
                            m.BrandName,
                            m.ProductName,
                            m.Size,
                            m.Price
                        };
            Console.WriteLine();
            Console.WriteLine("All our Milk Products are Listed Below:");

            // Output Juice Query
            foreach (var juice in query)
            {
                Console.WriteLine(juice);
            }

        }

        static void QueryAllCreamerProducts(List<DairyProduct> DairyProducts)
        {
            // Query all Creamers 
            var query = from m in DairyProducts
                        where m.ProductName.Contains("Creamer")
                        orderby m.Price ascending
                        select new
                        {
                            m.BrandName,
                            m.ProductName,
                            m.Size,
                            m.Price
                        };
            Console.WriteLine();
            Console.WriteLine("All our Creamer Products are Listed Below:");

            // Output Creamer Query
            foreach (var creamer in query)
            {
                Console.WriteLine(creamer);
            }

        }


        static void QueryAllYogurtProducts(List<DairyProduct> DairyProducts)
        {
            // Query all Yogurt 
            var query = from m in DairyProducts
                        where m.ProductName.Contains("Yogurt")
                        orderby m.Price ascending
                        select new
                        {
                            m.BrandName,
                            m.ProductName,
                            m.Size,
                            m.Price
                        };
            Console.WriteLine();
            Console.WriteLine("All our Yogurt Products are Listed Below:");

            // Output Yogurt Query
            foreach (var yogurt in query)
            {
                Console.WriteLine(yogurt);
            }

        }

        // Finding Dairy Product that matches search and adding it to the truck
        static void OrderProduct(List<DairyProduct> DairyProducts, string brandName, string ProductName, string size)
        {
          
            // Query the exact product the User Passed in 
            var query = from m in DairyProducts
                        where m.ProductName.Contains(ProductName) && m.BrandName.Contains(brandName) && m.Size.Contains(size)
                        orderby m.Price ascending
                        select new
                        {
                            m.BrandName,
                            m.ProductName,
                            m.Size,
                            m.Price
                        };


           
            //  if product was not found
            if (!query.Any())
            {
              Console.WriteLine("No product found. Type T to Try Again or any other key to Return");
                char quit;
                quit = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (quit == 'T')
                {
                    DairyProduct tryAgain;
                    tryAgain = OrderChoice();

                } else
                {
                    MainMenu(DairyProducts);
                }
              
               
            }

            // Add the number of pieces ordered to the truck once product is found
            DairyProduct.DairyTruckCount += count;
            Console.WriteLine("Order Completed!");
           
            // Output Product 
            foreach (var order in query)
            {
                Console.WriteLine(order);
            }
            
            // Output Truck Number
            Console.WriteLine("Total Pieces of Truck is now: " + DairyProduct.DairyTruckCount);
            
            // Call the Main Menu again 
            MainMenu(DairyProducts);



        }

        static void DairyMenu(List<DairyProduct> DairyProducts)
        {


            char choiceDairy = 'Z';

           
            Console.WriteLine("Please make a selection to see our Products");
            Console.WriteLine("A) Milk B) Cheese) C) Juice D) Creamer E) Yogurt R) Return");
            choiceDairy = Console.ReadKey().KeyChar;

            while (choiceDairy != 'R')
            {


                if (choiceDairy == 'A')
                {
                   
                    QueryAllMilkProducts(DairyProducts);
                      
                    // After the User sees the products they selected call the same method again until they decide to return to the Main Menu
                    DairyMenu(DairyProducts);

                }
                else if (choiceDairy == 'B')
                {
                    
                    QueryAllCheeseProducts(DairyProducts);

                    // After the User sees the products they selected call the same method again until they decide to return to the Main Menu
                    DairyMenu(DairyProducts);

                }

                else if (choiceDairy == 'C')
                {
                  
                    QueryAllJuiceProducts(DairyProducts);

                    // After the User sees the products they selected call the same method again until they decide to return to the Main Menu
                    DairyMenu(DairyProducts);

                }
                else if (choiceDairy == 'D')
                {
                    
                    QueryAllCreamerProducts(DairyProducts);
                    // After the User sees the products they selected call the same method again until they decide to return to the Main Menu
                    DairyMenu(DairyProducts);

                }
                else if (choiceDairy == 'E')
                {
                   
                    QueryAllYogurtProducts(DairyProducts);
                    // After the User sees the products they selected call the same method again until they decide to return to the Main Menu
                    DairyMenu(DairyProducts);

                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Wrong Choice Try Again");
                    choiceDairy = Console.ReadKey().KeyChar;

                }

            }

            // If this code is Reached then the user Pressed 'R' which will take them back to the Main Menu
            Console.WriteLine();
            MainMenu(DairyProducts);
        }

        // Returning Dairy Product to test for search 
        static DairyProduct OrderChoice()
        {
            
            Console.WriteLine("Make sure to type the product correctly. Case sensitive!");

            string brandName, productName, size;

           
            
            Console.WriteLine("Enter the brand name:");
            brandName = Console.ReadLine();

            Console.WriteLine("Enter the product Name:");
            productName = Console.ReadLine();

            Console.WriteLine("Enter the Size:");
            size = Console.ReadLine();

            // Asking for number of pieces to the store in the global variable 
            Console.WriteLine("Enter how many pieces");
            count = Convert.ToInt32(Console.ReadLine());
           
                                 // Putting 0 in for the Price of this object because we are just trying to return the product information from the user
            DairyProduct d1 = new DairyProduct(brandName, productName, size,0);
             return d1;

        }

        static void MainMenu(List<DairyProduct> DairyProducts)
        {

            char choice = 'Z';
           

            Console.WriteLine("A) View Dairy Inventory B) Add to the truck Q) Quit");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            while (choice != 'Q')
            {
                if (choice == 'A')
                {
                    DairyMenu(DairyProducts);

                }
                else if (choice == 'B')
                {
                    DairyProduct order;

                    order = OrderChoice();
                    // Pass the OrderChoice() object to the OrderProducts() Method
                    OrderProduct(DairyProducts, order.BrandName, order.ProductName, order.Size);
                   }

                else if (choice == 'Q') {
                    Environment.Exit(0);
                }
                else
                {
                   
                    Console.WriteLine("Wrong choice try again");
                    choice = Console.ReadKey().KeyChar;
                }

                 }

            Environment.Exit(0);

        }

        static List<DairyProduct> DairyProductList()
        {
           
            List<DairyProduct> DairyProducts = new List<DairyProduct>();


            DairyProducts.Add(new DairyProduct("StonyField", "Whole Milk", "Half Gallon", 4.99));
            DairyProducts.Add(new DairyProduct("StonyField", "2% Milk", "Half Gallon", 4.99));
            DairyProducts.Add(new DairyProduct("StonyField", "1% Milk", "Half Gallon", 4.99));
            DairyProducts.Add(new DairyProduct("StonyField", "Fat-Free Milk", "Half Gallon", 4.99));
            DairyProducts.Add(new DairyProduct("StonyField", "Whole Milk", "Full Gallon", 6.99));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Whole Milk", "Half Gallon", 2.99));
            DairyProducts.Add(new DairyProduct("StoreBrand", "2% Milk", "Half Gallon", 2.99));
            DairyProducts.Add(new DairyProduct("StoreBrand", "1% Milk", "Half Gallon", 2.99));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Fat-Free Milk", "Half Gallon", 2.99));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Whole Milk", "Full Gallon", 4.49));
            DairyProducts.Add(new DairyProduct("StoreBrand", "2% Milk", "Full Gallon", 4.49));
            DairyProducts.Add(new DairyProduct("StoreBrand", "1% Milk", "Full Gallon", 4.49));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Fat-Free Milk", "Full Gallon", 4.49));


            DairyProducts.Add(new DairyProduct("StoreBrand", "Shredded Mozzarella Cheese", " 8oz", 2.69));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Shredded Mexican Cheese", " 8oz", 2.69));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Shredded Cheddar Jack Cheese", " 8oz", 2.69));
            DairyProducts.Add(new DairyProduct("Kraft", "Shredded Mozzarella Cheese", " 8oz", 2.19));
            DairyProducts.Add(new DairyProduct("Kraft", "Shredded Fat-Free Mozzarella Cheese", " 8oz", 2.19));
            DairyProducts.Add(new DairyProduct("Breakstones", "Cottage Chesse", "16oz", 2.76));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Cottage Cheese", "16oz", 2.29));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Orange Juice No Pulp", "59oz", 3.33));
            DairyProducts.Add(new DairyProduct("StoreBrand", "Orange Juice Some Pulp", "59oz", 3.33));
            DairyProducts.Add(new DairyProduct("Tropicana", "Orange Juice No Pulp", "59oz", 3.99));
            DairyProducts.Add(new DairyProduct("Tropicana", "Orange Juice Some Pulp", "59oz", 3.99));
            DairyProducts.Add(new DairyProduct("Tropicana", "Orange Juice Lots Of Pulp", "59oz", 3.99));
            DairyProducts.Add(new DairyProduct("Internationl Delight", "French Vanilla Creamer", "16oz", 2.79));
            DairyProducts.Add(new DairyProduct("Internationl Delight", "Hazlenut Creamer ", "16oz", 2.79));
            DairyProducts.Add(new DairyProduct("Internationl Delight", "Cold Stone", "16oz", 2.79));
            DairyProducts.Add(new DairyProduct("Coffee Mate", "Hazelnut Creamer", "16oz", 2.23));
            DairyProducts.Add(new DairyProduct("Coffee Mate", "Italian Sweet Creamer", "16oz", 2.23));
            DairyProducts.Add(new DairyProduct("Coffee Mate", "French Vanilla Creamer", "16oz", 2.23));
            DairyProducts.Add(new DairyProduct("Coffee Mate", "Sugar Free French Vanilla Creamer", "16oz", 2.23));
            DairyProducts.Add(new DairyProduct("Dannon", " Strawberry Yogurt", "5.3oz", 0.99));
            DairyProducts.Add(new DairyProduct("Dannon", " Strawberry CheeseCake Yogurt", "5.3oz", 0.99));
            DairyProducts.Add(new DairyProduct("Yoplait", " Strawberry Yogurt", "6oz", 0.87));
            DairyProducts.Add(new DairyProduct("Yoplait", " French Vanilla Yogurt", "6oz", 0.87));

            return DairyProducts;


        }

    }  // ends class
        } // ends namespace
