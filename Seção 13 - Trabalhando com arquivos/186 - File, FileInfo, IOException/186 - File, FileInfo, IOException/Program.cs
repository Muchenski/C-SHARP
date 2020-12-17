using System;
using System.IO;

namespace _186___File__FileInfo__IOException {
    class Program {
        static void Main(string[] args) {

            // FileInfo = métodos instância, melhor performance, menos segurança.
            // File = métodos de estáticos, performance mais lenta, mais segura.

            //@ serve para não precisarmos de duas barras.
            string sourcePath = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\186 - File, FileInfo, IOException\186 - File, FileInfo, IOException\file1.txt";
            string targetPath = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\186 - File, FileInfo, IOException\186 - File, FileInfo, IOException\file2.txt";

            try {
                FileInfo fi = new FileInfo(sourcePath);

                // Copiando o arquivo file1 para o arquivo file2(que não existe e será criado):
                //fi.CopyTo(targetPath);

                // Copiando linha a linha do arquivo, e guardando cada linha em um índice de um vetor:
                string[] lines = File.ReadAllLines(sourcePath);

                foreach(string line in lines) {
                    Console.WriteLine(line);
                }

            }
            catch(IOException e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}
