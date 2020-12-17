using System;
using System.Collections.Generic;
using System.IO;

namespace _214___Exercicio_Dictionary {
    class Program {
        static void Main(string[] args) {

            try {
                string path = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 15 - Generics, Set, Dictionary\214 - Exercicio Dictionary\214 - Exercicio Dictionary\in.txt";
                using(StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open))) {

                    Dictionary<string, int> nomeVoto = new Dictionary<string, int>();

                    while(!sr.EndOfStream) {

                        string[] dados = sr.ReadLine().Split(",");

                        if(nomeVoto.ContainsKey(dados[0])) {
                            nomeVoto[dados[0]] += int.Parse(dados[1]);
                        }
                        else {
                            nomeVoto.Add(dados[0], int.Parse(dados[1]));
                        }
                    }
                    foreach(var item in nomeVoto) {
                        Console.WriteLine(item);
                    }
                }
            }
            catch(IOException e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}
