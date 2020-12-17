using System;
using System.Collections.Generic;

namespace _224___Action {
    class Program {
        static void Main(string[] args) {

            List<Product> products = new List<Product>();
            products.Add(new Product { Name = "TV", Price = 900.00 });
            products.Add(new Product { Name = "MOUSE", Price = 50.00 });
            products.Add(new Product { Name = "TABLET", Price = 350.50 });
            products.Add(new Product { Name = "HD CASE", Price = 80.90 });

            //products.ForEach(x => x.Price = x.Price * 1.1);

            // Ou

            Action<Product> action = x => { x.Price = x.Price * 1.1; };
            products.ForEach(action);

            foreach(var item in products) {
                Console.WriteLine(item);
            }
        }
    }
}

class Product {
    public string Name { get; set; }
    public double Price { get; set; }

    public override string ToString() {
        return $"{Name}, {Price:c2}";
    }
}