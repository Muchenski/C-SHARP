using System;

namespace _90___Timespan {
    class Program {
        static void Main(string[] args) {

            // Timespan representa durações, também utilizam os ticks para realizar conversões.

            // hora, min, seg.
            TimeSpan t = new TimeSpan(2, 30, 0);
            Console.WriteLine(t);

            // dia, hora, min, seg.
            TimeSpan t2 = new TimeSpan(1, 2, 30, 0);
            Console.WriteLine(t2);

            // dia, hora, min, seg, miliseg:
            TimeSpan t3 = new TimeSpan(1, 2, 30, 0, 20);
            Console.WriteLine(t3);

            // Em milisegundos.
            TimeSpan t1 = new TimeSpan(90000000000L);
            Console.WriteLine(t1);

            // A partir de dias.
            TimeSpan d = TimeSpan.FromDays(1.5);
            Console.WriteLine(d);

            // A partid de horas.
            TimeSpan h = TimeSpan.FromHours(1.5);

            // A partir de minutos.
            TimeSpan m = TimeSpan.FromMinutes(1.5);

            // A partir de segundos.
            TimeSpan s = TimeSpan.FromSeconds(1.5);

            // A partir de milissegundos.
            TimeSpan ms = TimeSpan.FromMilliseconds(1.5);

            // A partir de ticks(cada tick vale 100 nanosegundos).
            TimeSpan tk = TimeSpan.FromTicks(900000000L);
            Console.WriteLine(tk);


        }
    }
}
