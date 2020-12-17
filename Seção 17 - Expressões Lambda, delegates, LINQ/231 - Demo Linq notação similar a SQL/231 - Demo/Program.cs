using System;
using System.Collections.Generic;
using System.Linq;

namespace _231___Demo {
    class Program {
        static void Main(string[] args) {

            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>() {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };

            Console.WriteLine("TIER 1 and PRICE < 900:");
            (from p in products where p.Category.Tier == 1 && p.Price < 900 select p).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Procutc TOOLS names: ");
            (from p in products where p.Category.Name == "Tools" select p).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Products first letter == 'C':");
            // Criando objeto anônimo:
            (from p in products where p.Name[0] == 'C' select new { Name = p.Name, Price = p.Price, CategoryName = p.Category.Name }).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Order by Price then by Name: ");
            // a ordenação tem que ser em ordem inversa
            (from p in products where p.Category.Tier == 1 orderby p.Name orderby p.Price select p).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Pulando os dois primeiros elementos e pegando os próximos 4:");
            (from p in products select p).Skip(2).Take(4).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Agrupando os produtos por categorias: ");
            (from p in products group p by p.Category).ToList().ForEach(x => {
                Console.WriteLine("Category " + x.Key.Name);
                x.ToList().ForEach(x => Console.WriteLine(x));
                Console.WriteLine();
            });
        }
    }

    class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString() {
            return $"{Id}, {Name}, {Price}, {Category.Name}, {Category.Tier}";
        }
    }

    class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }

        public override string ToString() {
            return $"{Id}, {Name}, {Tier}";
        }
    }
}