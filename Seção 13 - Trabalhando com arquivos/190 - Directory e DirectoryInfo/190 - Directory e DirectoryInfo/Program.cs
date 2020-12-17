using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _190___Directory_e_DirectoryInfo {
    class Program {
        static void Main(string[] args) {

            // Directory -> static members(mais lenta e mais segura)
            // DirectoryInfo -> instance members(mais rápida e menos segura)

            string path = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\190 - Directory e DirectoryInfo\190 - Directory e DirectoryInfo\myfolder";

            try {

                if(Directory.Exists(path + @"\newFolder")) {
                    Directory.Delete(path + @"\newFolder");
                }

                // listando as subpastas do path:

                // "*." = todos nomes e todas extensões.

                // Tipo IEnumerable é o tipo mais genérico de coleção.
                // Poderíamos utilizar o tipo "var".
                //Directory.EnumerateDirectories(path, "nome.extensão", SearchOption) retorna um iterador(IEnumerable);
                IEnumerable<string> folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);

                //folders = folders.Where(x => !x.Contains("newFolder"));

                Console.WriteLine("Folders: ");
                foreach(String s in folders) {
                    Console.WriteLine(s);
                }

                Console.WriteLine();

                // Listando os arquivos da pasta e subpastas:
                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);

                Console.WriteLine("Files: ");
                foreach(String f in files) {
                    Console.WriteLine(f);
                }

                Console.WriteLine();

                // Criando subpasta:
                Directory.CreateDirectory(path + @"\newFolder");

                folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);

                Console.WriteLine("Folders update: ");
                foreach(String s in folders) {
                    Console.WriteLine(s);
                }
            }
            catch(IOException e) {
                Console.WriteLine(e.Message);
            }


        }
    }
}

//https://pt.stackoverflow.com/questions/191582/o-que-%C3%A9-e-pra-que-serve-ienumerable-e-ienumerator
