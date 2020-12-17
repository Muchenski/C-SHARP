using _206___Restrições_de_generics.entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace _206___Restrições_de_generics {
    class Program {
        static void Main(string[] args) {
            List<Product> listP = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++) {
                string[] vect = Console.ReadLine().Split(',');
                double price = double.Parse(vect[1], CultureInfo.InvariantCulture);
                listP.Add(new Product(vect[0], price));
            }

            CalculationService calculationService = new CalculationService();

            Product p = calculationService.Max(listP); // <Product> is optional
            Console.WriteLine("Most expensive:");
            Console.WriteLine(p);

            List<int> list = new List<int>();

            Console.Write("Enter the number of ints: ");
            n = int.Parse(Console.ReadLine());

            for(int j = 0; j < n; j++) {
                int a = Convert.ToInt32(Console.ReadLine());
                list.Add(a);
            }

            int x = calculationService.Max(list);

            Console.WriteLine("Most expensive:");
            Console.WriteLine(x);
        }
    }
}
