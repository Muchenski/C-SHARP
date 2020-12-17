using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _232___Ex_01 {
    class Program {
        static void Main(string[] args) {

            string path = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 17 - Expressões Lambda, delegates, LINQ\232 - Ex 01\232 - Ex 01\in.txt";
            List<Product> products = new List<Product>();

            try {
                using(StreamReader sr = File.OpenText(path)) {

                    while(!sr.EndOfStream) {
                        string[] dados = sr.ReadLine().Split(",");
                        products.Add(new Product { Name = dados[0], Price = double.Parse(dados[1], CultureInfo.InvariantCulture) });
                    }
                }
            }
            catch(IOException e) {
                Console.WriteLine(e.Message);
            }

            if(products.Count > 0) {
                double media = products.Select(x => x.Price).DefaultIfEmpty(0.0).Average();
                Console.WriteLine(media.ToString("F2", CultureInfo.InvariantCulture));
                products.Where(x => x.Price < media).OrderByDescending(x => x.Name).ToList().ForEach(x => Console.WriteLine(x.Name, x.Price));
            }
        }
    }

    class Product {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
