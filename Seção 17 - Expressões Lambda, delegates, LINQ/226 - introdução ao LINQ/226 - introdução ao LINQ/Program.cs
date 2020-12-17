using System;
using System.Linq;

namespace _226___introdução_ao_LINQ {
    class Program {
        static void Main(string[] args) {

            // Especificando o data source.
            int[] numbers = new int[] { 2, 3, 4, 5 };

            // Definindo nossa consulta.
            // Filtrando os números pares, selecionando os filtrados e multiplicando por 10.
            int[] result = numbers.Where(x => x % 2 == 0).Select(x => x * 10).ToArray();

            // Forçando a execução da consulta.
            foreach(var item in result) {
                Console.WriteLine(item);
            }
        }
    }
}
