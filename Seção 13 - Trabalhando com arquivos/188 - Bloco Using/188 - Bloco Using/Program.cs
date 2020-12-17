using System;
using System.IO;

namespace _188___Bloco_Using {
    class Program {
        static void Main(string[] args) {
            /*
             * Como falado anteriormente, objetos como Font, FileStream, StreamReader
             * StreamWriter, não são gerenciados pelo CLR do .NET, e sim pelo S.O
             * eles precisam ser manualmente fechados.
             * 
             * Por isso, eles recebem o nome de Objetos IDisposable.
             * Mas para que o código não fique tão extenso e verboso como
             * da aula anterior, existe o bloco USING, que funciona como um with
             * em python, ele irá fechar automaticamente os IDisposable instanciados como parâmetros nele.
             * 
             * Porém o bloco USING NÃO TRATA EXCEÇÕES.
             * Ele deve ser inserido dentro de um try/catch.
             */

            string path = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\188 - Bloco Using\188 - Bloco Using\teste.txt";

            try {

                // ou using(StreamReader sr = File.OpenText(path))
                using(StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open))) {
                    while(!sr.EndOfStream) {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch(IOException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
