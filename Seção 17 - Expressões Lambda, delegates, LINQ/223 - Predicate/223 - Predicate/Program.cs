using _223___Predicate.entities;
using System;
using System.Collections.Generic;

namespace _223___Predicate {
    class Program {
        static void Main(string[] args) {
            List<Product> products = new List<Product>();

            products.Add(new Product("TV", 900.00));
            products.Add(new Product("Mouse", 50.00));
            products.Add(new Product("Tablet", 350.50));
            products.Add(new Product("HD case", 80.90));

            products.RemoveAll(x => x.Price > 80.90);

            foreach(var item in products) {
                Console.WriteLine(item);
            }
        }
    }
}
