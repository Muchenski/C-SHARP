using System;
using System.Collections.Generic;
using System.Linq;

namespace _225___Func {
    class Program {
        static void Main(string[] args) {
            // A única diferença entre um Action e um Func
            // é que o Action é void e o Func retorna algo.

            List<Product> p = new List<Product>();

            p.Add(new Product { Name = "TV", Price = 900.0 });
            p.Add(new Product { Name = "Mouse", Price = 50.0 });
            p.Add(new Product { Name = "Tablet", Price = 350.50 });
            p.Add(new Product { Name = "HD case", Price = 80.90 });

            // A função select transforma uma coleção em uma coleção diferente.
            // Obtendo os nomes dos produtos.
            //List<String> productNameUpper = p.Select(x => x.Name = x.Name.ToUpper()).ToList();

            // Ou

            Func<Product, string> func = x => x.Name = x.Name.ToUpper();
            List<string> productNameUpper = p.Select(func).ToList();

            foreach(var item in productNameUpper) {
                Console.WriteLine(item);
            }

        }
    }

    class Product {
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString() {
            return $"{Name}, {Price}";
        }
    }
}
