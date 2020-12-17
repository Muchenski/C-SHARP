using System;
using System.Globalization;

namespace _23___Entrada_de_dados_02 {
    class Program {
        static void Main(string[] args) {

            int n1 = int.Parse(Console.ReadLine());
            char ch = char.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine(n1);
            Console.WriteLine(ch);
            Console.WriteLine(n2);

        }
    }
}
