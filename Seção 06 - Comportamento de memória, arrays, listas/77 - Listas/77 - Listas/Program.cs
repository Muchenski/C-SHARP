using System;
using System.Collections.Generic;

namespace _77___Listas {
    class Program {
        static void Main(string[] args) {

            List<string> list = new List<string>();

            list.Add("Henrique");
            list.Add("Matheus");
            list.Insert(1, "Lucas");
            list.Add("Luan");
            list.Add("João");
            list.Add("Pedro");

            foreach(string nome in list) {
                Console.WriteLine(nome);
            }

            Console.WriteLine();

            // Encontrando a primeira palavra com letra inicial "L":
            string firstL = list.Find(x => x[0] == 'L'); // Ou botar o nome "Test" da função.
            Console.WriteLine($"Primeiro nome encontrado com a inicial 'L': {firstL}");

            Console.WriteLine();

            // Encontrando a última palavra com letra inicial "L":
            string lastL = list.FindLast(x => x[0] == 'L');
            Console.WriteLine($"Último nome encontrado com a inicial 'L': {lastL}");

            Console.WriteLine();

            // Descobrindo o número da posição da primeira palavra que se inicia com letra "L".
            int firstIndex = list.FindIndex(x => x[0] == 'L');
            Console.WriteLine($"A posição da primeira palavra que se inicia com 'L': {firstIndex}");

            Console.WriteLine();

            // Descobrindo o número da posição da última palavra que se inicia com letra "L".
            int lastIndex = list.FindLastIndex(x => x[0] == 'L');
            Console.WriteLine($"A posição da última palavra que se inicia com 'L': {lastIndex}");

            Console.WriteLine();

            // Criando uma lista, filtrando nomes com mais de 5 caracteres:
            List<string> nomes = list.FindAll(x => x.Length > 5);

            Console.WriteLine("Lista de nomes com mais de 5 caracteres: ");
            foreach(string nome in nomes) {
                Console.WriteLine(nome);
            }

            Console.WriteLine();

            list.Remove("Luan");
            foreach(string nome in list) {
                Console.WriteLine(nome);
            }

            Console.WriteLine();

            // Removendo nomes com mais de 5 caracteres:
            list.RemoveAll(x => x.Length > 5);

            Console.WriteLine("Lista atualizada: ");
            foreach(string nome in list) {
                Console.WriteLine(nome);
            }

            Console.WriteLine();

            // Outras funções:
            // RemoveAt(posição);
            // RemoveRange(posição de partida, número de remoções);

        }

        static bool Test(string s) {
            return s[0] == 'L';
        }
    }
}
