using System;

namespace _93___DateTimeKind {
    class Program {
        static void Main(string[] args) {

            // Local = fuso horario do sistema
            // UTC(Universal) = Meridiano

            DateTime d1 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Local);
            DateTime d2 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Utc);
            DateTime d3 = new DateTime(2000, 8, 15, 13, 5, 58);

            Console.WriteLine($"D1: {d1}");
            Console.WriteLine($"D1 kind: {d1.Kind}");
            // Como d1 é local, a conversão para o ToLocalTime não alterará nenhum valor.
            Console.WriteLine($"D1 to local: {d1.ToLocalTime()}");
            // Porém, quando convertemos para o UTC, acrescentará 3 horas, pois
            // o horário Local brasileiro é UTC-3
            Console.WriteLine($"D1 to UTC: {d1.ToUniversalTime()}");

            Console.WriteLine();

            Console.WriteLine($"D2: {d2}");
            Console.WriteLine($"D2 kind: {d2.Kind}");
            // Quando convertemos para o local, decrementará 3 horas, pois
            // o horário Local brasileiro é UTC-3.
            Console.WriteLine($"D2 to local: {d2.ToLocalTime()}");
            // Como d2 é global, a conversão para o ToUniversalTime não alterará nenhum valor.
            Console.WriteLine($"D2 to UTC: {d2.ToUniversalTime()}");

            Console.WriteLine();

            // Padrão ISO 8601:
            // yyyy-MM-ddTHH:mm:ssZ
            // Z representa que a data e hora estão em UTC

            DateTime d = DateTime.Parse("2000-08-15T13:05:58Z");
            Console.WriteLine(d); 
            Console.WriteLine(d.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));

        }
    }
}
