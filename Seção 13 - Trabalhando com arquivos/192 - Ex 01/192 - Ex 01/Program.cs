using _192___Ex_01.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace _192___Ex_01 {
    class Program {
        static void Main(string[] args) {

            List<Product> products = new List<Product>();

            try {

                string sourcePath = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 13 - Trabalhando com arquivos\192 - Ex 01\192 - Ex 01";

                string csvPath01 = sourcePath + @"\Produtos.csv";

                // Lendo o arquivo, instanciando e guardando numa lista as instâncias:
                string[] lines = File.ReadAllLines(csvPath01);

                foreach(string line in lines) {
                    string[] attributes = line.Split(",");

                    Product p = new Product();
                    p.Name = attributes[0];
                    p.Price = double.Parse(attributes[1], CultureInfo.InvariantCulture);
                    p.Quantity = int.Parse(attributes[2]);

                    products.Add(p);
                }

                // Criando subpasta:
                string targetPath = sourcePath + @"\out";
                Directory.CreateDirectory(targetPath);

                // Definindo o caminho do novo arquivo:
                string csvPath02 = targetPath + @"\Summary.csv";


                // Escrevendo no arquivo utilizando os dados das instâncias:
                using(StreamWriter sw = new StreamWriter(new FileStream(csvPath02, FileMode.OpenOrCreate))) {

                    foreach(Product p in products) {
                        sw.WriteLine($"{p.Name}, {(p.Price * p.Quantity).ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                }
            }
            catch(IOException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
