using System;
using System.Globalization;

namespace _42___Exercicio_02 {
    class Program {
        static void Main(string[] args) {

            Produto p = new Produto();

            Console.WriteLine("Entre com os dados do produto:");
            Console.Write("Nome:");
            p.Nome = Console.ReadLine();

            Console.Write("Preço:");
            p.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantidade:");
            p.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados do produto: " + p);

            Console.Write("Digite o número de produtos a ser adicionado: ");
            int q = int.Parse(Console.ReadLine());

            p.adicionarProduto(q);

            Console.WriteLine("Dados do produto: " + p);

            Console.Write("Digite o número de produtos a serem removidos: ");
            q = int.Parse(Console.ReadLine());

            p.removerProduto(q);

            Console.WriteLine("Dados do produto: " + p);

        }

    }
}
