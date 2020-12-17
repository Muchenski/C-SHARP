using System;
using System.Collections.Generic;
using System.Linq;

namespace _228___Demo_Linq_com_lambda_01 {
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
            products.Where(x => x.Price < 900 && x.Category.Tier == 1).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Procutc TOOLS names: ");
            products.Where(x => x.Category.Name.Equals("Tools")).Select(x => x.Name).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Products first letter == 'C':");
            // Criando objeto anônimo:
            products.Where(x => x.Name[0] == 'C').Select(x => new { Nome = x.Name, Preço = x.Price, CategoryName = x.Category.Name }).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Order by Price then by Name: ");
            products.Where(x => x.Category.Tier == 1).OrderBy(x => x.Price).ThenBy(x => x.Name).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Pulando os dois primeiros elementos e pegando os próximos 4:");
            products.Skip(2).Take(4).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            Console.WriteLine("Primeiro produto:");
            Console.WriteLine(products.FirstOrDefault());
            Console.WriteLine();

            Console.WriteLine("Primeiro ultimo:");
            Console.WriteLine(products.LastOrDefault());
            Console.WriteLine();

            Console.WriteLine("Primeiro elemento com o Id 3, senão retorna o default:");
            // Só usar quando ter a certeza que existe apenas zero ou um elemento na coleção, que reflita na condição proposta.
            Console.WriteLine(products.SingleOrDefault(x => x.Id == 3));
            Console.WriteLine();

            Console.WriteLine("Primeiro elemento com o Id 1, senão retorna null:");
            Console.WriteLine(products.Find(x => x.Id == 1));
            Console.WriteLine();

            Console.WriteLine("Produto mais caro vale:");
            Console.WriteLine(products.Max(x => x.Price));
            Console.WriteLine();

            Console.WriteLine("Produto mais barato vale:");
            Console.WriteLine(products.Min(x => x.Price));
            Console.WriteLine();

            Console.WriteLine("Soma dos valores dos produtos de uma determinada categoria: ");
            Console.WriteLine(products.Where(x => x.Category.Id == 1).Sum(x => x.Price));
            Console.WriteLine();

            Console.WriteLine("Média dos valores dos produtos de uma determinada categoria: ");
            // DefaultIfEmpty para que não ocorra exceção caso a lista esteja vazia
            Console.WriteLine(products.Where(x => x.Category.Id == 1).Select(x => x.Price).DefaultIfEmpty(0.0).Average());
            Console.WriteLine();

            Console.WriteLine("Soma por agregação de valores: ");
            Console.WriteLine(products.Where(x => x.Category.Id == 1).Select(x => x.Price).Aggregate(0.0, (curNumber, nextNumber) => curNumber + nextNumber));
            Console.WriteLine();

            Console.WriteLine("Agrupando os produtos por categorias: ");
            // Agrupando os produtos por categorias:
            foreach(IGrouping<Category, Product> iGroupint in products.GroupBy(x => x.Category)) {
                Console.WriteLine("Category " + iGroupint.Key.Name);
                foreach(Product product in iGroupint) {
                    Console.WriteLine(product);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Ou

            Console.WriteLine("Agrupando os produtos por categorias: ");
            products.GroupBy(x => x.Category).ToList().ForEach(x => {
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
