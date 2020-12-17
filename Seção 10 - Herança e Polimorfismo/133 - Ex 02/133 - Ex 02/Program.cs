using _133___Ex_02.Entities;
using System;
using System.Collections.Generic;

namespace _133___Ex_02 {
    class Program {
        static void Main(string[] args) {

            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int numberOfProducts = int.Parse(Console.ReadLine());

            for(int i = 0; numberOfProducts > i; i++) {

                Console.Write("\nCommon product[C] - Used product[U] - Imported product[I]: ");
                char commonOrUsedOrImported = char.Parse(Console.ReadLine().Substring(0, 1).ToUpper());

                Console.Write("\nName: ");
                string name = Console.ReadLine();

                Console.Write("\nPrice: ");
                double price = double.Parse(Console.ReadLine());

                if(commonOrUsedOrImported.Equals('C')) {
                    Product common = new Product(name, price);
                    products.Add(common);

                }
                else if(commonOrUsedOrImported.Equals('I')) {
                    Console.Write("\nCustoms fee: ");
                    double customsFee = double.Parse(Console.ReadLine());
                    Product imported = new ImportedProduct(name, price, customsFee);
                    products.Add(imported);

                }
                else if(commonOrUsedOrImported.Equals('U')) {
                    Console.Write("\nManufacture date(DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    Product used = new UsedProduct(name, price, manufactureDate);
                    products.Add(used);
                }

                Console.WriteLine("\n=================================");
            }

            Console.WriteLine("\n=================================\n");

            foreach(Product product in products) {
                Console.WriteLine($"Category: {(product.GetType().Name).Insert(product.GetType().Name.IndexOf("Product"), " ")}\n{product.PriceTag()}");
                Console.WriteLine("\n=================================\n");
            }
        }
    }
}
