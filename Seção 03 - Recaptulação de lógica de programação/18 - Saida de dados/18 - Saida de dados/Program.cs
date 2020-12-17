using System;
using System.Globalization;

namespace _18___Saida_de_dados {
    class Program {
        static void Main(string[] args) {

            string nome = "Maria";
            int idade = 20;
            double saldo = 10.121122;
            char genero = 'F';

            // Coloca quebra de linha
            Console.WriteLine("Quebra linha");

            // Não coloca quebra de linha
            Console.Write("Sem quebra de linha");
            Console.Write("Sem quebra de linha");

            Console.WriteLine(nome);
            Console.WriteLine(idade);
            Console.WriteLine(genero);

            // Sem formatação
            Console.WriteLine(saldo);

            // Formatando com 2 casas decimais
            Console.WriteLine(saldo.ToString("F2"));

            // Definindo que o separador das casas decimais será um ponto, e não vírgula.
            Console.WriteLine(saldo.ToString("F2", CultureInfo.InvariantCulture));

            // Printando com placeholders
            Console.WriteLine("{0} tem {1} anos e tem saldo igual a {2:F2} reais.", nome, idade, saldo);

            // Com formatação
            Console.WriteLine($"{nome} tem {idade} anos e tem saldo igual a {saldo:F2} reais.");
        }
    }
}

// CTRL + K + D = indentação
