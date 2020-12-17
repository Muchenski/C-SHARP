using System;
using System.IO;

namespace _187___FileStream_e_StreamReader {
    class Program {
        static void Main(string[] args) {

            string path = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\187 - FileStream e StreamReader\187 - FileStream e StreamReader\teste.txt";

            FileStream fs = null;
            StreamReader sr = null;

            try {

                // Instanciando FileStream associado a um arquivo, iremos criar, caso não existam ou abrir, caso exista(como de finido no FileMode.).
                fs = new FileStream(path, FileMode.OpenOrCreate);

                /*
                 * Ao invés de instanciar um FileStream e depois associar a um StreamReader
                 * poderiamos utilizar a classe File, deste modo:
                 * 
                 * sr = File.OpenText(path);
                 * 
                 * Com este método, é retornado uma instância de StreamReader, com o argumento
                 * de instância de um FileStream.
                */
                sr = new StreamReader(fs);

                // Lendo as linhas do arquivo:
                while(!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }

            }
            catch(IOException e) {
                Console.WriteLine(e.Message);

            }
            finally {
                // Como o FileStream e o StreamReader não são gerenciados pelo CRLF do .NET
                // mas sim são gerenciados pelos S.O, devemos fechar estes recursos manualmente.
                // Assim evitamos o uso de memória desnecessário.

                if(sr != null) {
                    sr.Close();
                }

                if(fs != null) {
                    fs.Close();
                }
            }
        }
    }
}
