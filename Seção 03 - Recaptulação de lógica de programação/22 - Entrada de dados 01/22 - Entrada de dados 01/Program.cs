using System;
using System.Linq;

namespace _22___Entrada_de_dados_01 {
    class Program {
        static void Main(string[] args) {

            // Lê os dados até que encontre a quebra de linha(Enter).
            // Retorna dados do tipo string.
            Console.WriteLine("Digite uma frase: ");
            string frase = Console.ReadLine();

            Console.WriteLine("Digite uma cor x: ");
            string cor1 = Console.ReadLine();

            Console.WriteLine("Digite uma cor y: ");
            string cor2 = Console.ReadLine();

            Console.WriteLine("Digite uma cor z: ");
            string cor3 = Console.ReadLine();

            Console.WriteLine($"Digite o nome de 3 times separados por espaço: ");
            string[] times = Console.ReadLine().Split(" ");

            Console.WriteLine("-------------------------");

            Console.WriteLine(frase);
            Console.WriteLine(cor1);
            Console.WriteLine(cor2);
            Console.WriteLine(cor3);

            Console.WriteLine();

            foreach(string item in times) {
                Console.WriteLine(item);
            }

            Console.WriteLine();

        }
    }
}
