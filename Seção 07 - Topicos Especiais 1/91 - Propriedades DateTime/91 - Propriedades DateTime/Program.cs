using System;

namespace _91___Propriedades_DateTime {
    class Program {
        static void Main(string[] args) {

            // Seleção de informações
            DateTime d = new DateTime(2001, 8, 15, 13, 45, 58, 500);
            Console.WriteLine($"Data:{d.Date}");
            Console.WriteLine($"Dia:{d.Day}");
            Console.WriteLine($"Dia da semana:{d.DayOfWeek}");
            Console.WriteLine($"Dia do ano:{d.DayOfYear}");
            Console.WriteLine($"Hora:{d.Hour}");
            Console.WriteLine($"Tipo:{d.Kind}");
            Console.WriteLine($"Milissegundo:{d.Millisecond}");
            Console.WriteLine($"Minuto:{d.Minute}");
            Console.WriteLine($"Mes:{d.Month}");
            Console.WriteLine($"Segundo:{d.Second}");
            Console.WriteLine($"Ticks:{d.Ticks}");
            Console.WriteLine($"Horario do dia:{d.TimeOfDay}");
            Console.WriteLine($"Ano:{d.Year}");

            // Formatação:
            Console.WriteLine(d.ToLongDateString());
            Console.WriteLine(d.ToLongTimeString());
            Console.WriteLine(d.ToShortDateString());
            Console.WriteLine(d.ToShortTimeString());

            // Operações:
            DateTime d2 = new DateTime(2000, 8, 25, 20, 40, 02);
            d2.AddDays(2);
            d2.AddMonths(2);
            d2.AddYears(3);
            // Entre outros.

            // Diferença entre duas datas(gera um TimeSpan)
            TimeSpan t = d2.Subtract(new DateTime(2001, 8, 15, 13, 45, 58));
            Console.WriteLine(t);
        }
    }
}
