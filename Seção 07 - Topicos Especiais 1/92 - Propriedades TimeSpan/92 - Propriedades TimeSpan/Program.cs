using System;

namespace _92___Propriedades_TimeSpan {
    class Program {
        static void Main(string[] args) {

            TimeSpan t1 = TimeSpan.MaxValue;
            TimeSpan t2 = TimeSpan.MinValue;
            TimeSpan t3 = TimeSpan.Zero;

            Console.WriteLine($"{t1}\n{t2}\n{t3}");

            TimeSpan t = new TimeSpan(2, 24, 5, 7, 11);

            // Imprime o número inteiro do que pedimos.
            Console.WriteLine($"Days: {t.Days}");
            Console.WriteLine($"Hours: {t.Hours}");

            // Imprime o número fracionado do que pedimos.
            Console.WriteLine($"TotalDays: {t.TotalDays}");
            Console.Write($"TotalHours: {t.TotalHours}");


            // Operações:
            TimeSpan o1 = new TimeSpan(1,30,10);
            TimeSpan o2 = new TimeSpan(0, 10, 5);

            Console.WriteLine($"Soma: {o1.Add(o2)}");
            Console.WriteLine($"Subtrair: {o1.Subtract(o2)}");
            Console.WriteLine($"Miltiplicar: {o1.Multiply(2)}");
            Console.WriteLine($"Dividir: {o1.Divide(2)}");
        }
    }
}
