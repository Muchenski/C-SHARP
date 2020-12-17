using System;
using System.Collections.Generic;

namespace _212___Exercicio_conjuntos {
    class Program {

        static void Main(string[] args) {

            List<HashSet<int>> sets = Cad();
            HashSet<int> total = new HashSet<int>();

            Console.WriteLine("Alunos cadastrados:");
            foreach(HashSet<int> set in sets) {
                foreach(int item in set) {
                    Console.Write(item + " ");
                    total.Add(item);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Total de alunos:");
            foreach(int item in total) {
                Console.Write(item + " ");
            }
            Console.WriteLine($"O total de estudantes é {total.Count} alunos.");

        }

        static List<HashSet<int>> Cad() {
            int n, registration;
            string[] courses = new string[] { "A", "B", "C" };
            HashSet<int> hSet;
            List<HashSet<int>> sets = new List<HashSet<int>>();

            for(int i = 0; i < 3; i++) {
                hSet = new HashSet<int>();
                Console.WriteLine($"Quantos estudantes para a turma {courses[i]}: ");
                n = Convert.ToInt32(Console.ReadLine());
                for(int j = 0; j < n; j++) {
                    Console.WriteLine($"Número da matrícula {j + 1} para o curso {courses[i]}: ");
                    registration = Convert.ToInt32(Console.ReadLine());
                    hSet.Add(registration);
                }
                Console.Clear();
                sets.Add(hSet);
            }
            Console.WriteLine("Digite qualquer tecla...");
            Console.ReadKey();
            return sets;
        }
    }
}
