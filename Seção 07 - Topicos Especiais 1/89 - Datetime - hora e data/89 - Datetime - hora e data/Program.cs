using System;
using System.Globalization;

namespace _89___Datetime___hora_e_data {
    class Program {
        static void Main(string[] args) {

            // Data e horário atual do sistema.
            DateTime d1 = DateTime.Now;
            Console.WriteLine(d1);

            // Quantidade de ticks(100 nanosegundos) que passaram desde a 
            // meia noite do dia 1 de janeiro do ano 1 da era comum
            Console.WriteLine(d1.Ticks);

            // Datetime(ano, mes, dia, hora, minuto, segundo, milisegundo)

            // Se não especificarmos o horário, o padrão será meia noite.
            DateTime d2 = new DateTime(2020, 11, 25);

            DateTime d3 = new DateTime(2020, 11, 25, 12, 45, 3, 500);

            // Horário de acordo com o GMT
            DateTime d4 = DateTime.UtcNow;

            // DatetimeKind = para especificar se a data é local ou global

            // O c# consegue entender vários formatos de data para conversão.
            DateTime d5 = DateTime.Parse("2000-08-15 20:02:06");
            DateTime d6 = DateTime.Parse("15/08/2000 20:02:06");


            // Determinando formatos de datas
            DateTime d7 = DateTime.ParseExact("200-08-15 20:02:06", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}
