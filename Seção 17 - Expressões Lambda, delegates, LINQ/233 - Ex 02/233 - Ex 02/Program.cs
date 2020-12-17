using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _233___Ex_02 {
    class Program {
        static void Main(string[] args) {

            List<Employee> employees = new List<Employee>();
            string path = @"C:\Users\Henrique Muchenski\Desktop\anotacoes\C#\Seção 17 - Expressões Lambda, delegates, LINQ\233 - Ex 02\233 - Ex 02\in.txt";

            try {
                using(StreamReader sr = File.OpenText(path)) {
                    while(!sr.EndOfStream) {
                        string[] dados = sr.ReadLine().Split(",");
                        employees.Add(new Employee() { Name = dados[0], Email = dados[1], Salary = double.Parse(dados[2], CultureInfo.InvariantCulture) });
                    }
                }
            }
            catch(IOException e) {
                Console.WriteLine(e.Message);
            }

            if(employees.Count > 0) {
                Console.WriteLine("Digite o valor de filtragem do salário dos trabalhadores: ");
                double valor = double.Parse(Console.ReadLine());
                employees.Where(x => x.Salary > valor).OrderBy(x => x.Email).Select(x => x.Email).ToList().ForEach(x => Console.WriteLine(x));
                Console.WriteLine("Soma dos salários dos funcionários que iniciam o nome com a letra 'M': ");
                Console.WriteLine(employees.Where(x => x.Name[0] == 'M').Select(x => x.Salary).Sum());
            }
        }
    }

    class Employee {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public override string ToString() {
            return $"{Name} | {Email} | {Salary}";
        }
    }
}
