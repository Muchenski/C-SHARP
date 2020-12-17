using _219___Uma_experiência_com_Comparsion.entities;
using System;
using System.Collections.Generic;

namespace _219___Uma_experiência_com_Comparsion {
    class Program {
        static void Main(string[] args) {

            List<Product> products = new List<Product>();

            products.Add(new Product("TV", 900.00));
            products.Add(new Product("NoteBook", 1200.00));
            products.Add(new Product("Tablet", 450.00));

            // products.Sort(CompareProducts);

            // ou

            // Variável que consegue guardar a referência a uma função.
            // Comparison<Product> com = CompareProducts;
            // products.Sort(com);

            // ou
            // Comparison<Product> com = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
            // products.Sort(com);

            // ou
            products.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));

            foreach(Product p in products) {
                Console.WriteLine(p);
            }
        }

        static int CompareProducts(Product p1, Product p2) {
            return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
        }
    }
}
