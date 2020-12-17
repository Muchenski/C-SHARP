using System;
using System.IO;

namespace _191___Path {
    class Program {
        static void Main(string[] args) {

            // Path serve para conseguirmos dados detalhados dos caminhos do sistema.

            string path = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\191 - Path\191 - Path\teste1.txt";

            Console.WriteLine(Path.GetDirectoryName(path) + "\n\n" +
                Path.DirectorySeparatorChar + "\n\n" +
                Path.PathSeparator + "\n\n" +
                Path.GetFileName(path) + "\n\n" +
                Path.GetFileNameWithoutExtension(path)
                );
            
        }
    }
}
