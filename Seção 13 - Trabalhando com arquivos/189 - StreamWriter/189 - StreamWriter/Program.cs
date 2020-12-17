using System;
using System.IO;

namespace _189___StreamWriter {
    class Program {
        static void Main(string[] args) {

            string sourcePath = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\189 - StreamWriter\189 - StreamWriter\teste1.txt";
            string targetPath = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\189 - StreamWriter\189 - StreamWriter\teste2.txt";

            try {

                string[] lines = File.ReadAllLines(sourcePath); 

                using(StreamWriter sw = new StreamWriter(new FileStream(targetPath, FileMode.Append))) {
                    foreach(string line in lines) {
                        sw.WriteLine(line.Substring(0, 1).ToUpper() + line.Substring(1));
                    }
                }

                using(StreamReader sr = File.OpenText(targetPath)) {
                    while(!sr.EndOfStream) {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }

            } catch(IOException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
