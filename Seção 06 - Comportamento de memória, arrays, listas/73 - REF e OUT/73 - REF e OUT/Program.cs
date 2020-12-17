using System;

namespace _73___REF_e_OUT {
    class Program {
        static void Main(string[] args) {

            // ref exige que a variável seja iniciada.
            // out não exige.

            int a = 10;
            int b;

            TriplicarREF(ref a);
            Console.WriteLine(a);

            TriplicarOUT(a, out b);
            Console.WriteLine(b);
        }

        public static void TriplicarREF(ref int a) {
            a = a * 3;
        }

        public static void TriplicarOUT(int origin, out int result) {
            result = origin * 3;
        }
    }
}
