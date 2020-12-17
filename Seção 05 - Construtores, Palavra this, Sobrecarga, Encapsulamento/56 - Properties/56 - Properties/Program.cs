using System;

namespace _56___Properties {
    class Program {
        static void Main(string[] args) {

            Produto p = new Produto();

            Console.Write("Escreva seu nome: ");
            p.Nome = Console.ReadLine();

            Console.WriteLine(p.Nome);
        }
    }
}
