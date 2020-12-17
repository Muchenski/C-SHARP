using System;

namespace _79___Matrizes {
    class Program {
        static void Main(string[] args) {

            // Declarando matriz
            int[,] matriz = new int[2,3];

            // Quantidade de elementos totais da matriz
            Console.WriteLine(matriz.Length);

            // Quantidade de linhas da matriz:
            Console.WriteLine(matriz.Rank);

            // Quantidade de linha:
            Console.WriteLine(matriz.GetLength(0));

            // Quantidade de colunas:
            Console.WriteLine(matriz.GetLength(1));
        }
    }
}
