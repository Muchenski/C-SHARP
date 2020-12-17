using System;

namespace _141___Estrutura_try_catch {
    class Program {
        static void Main(string[] args) {

            try {
                int n1 = 2;
                int n2 = 0;

                int result = n1 / n2;

            }
            catch(DivideByZeroException d) {
                Console.WriteLine(d.Message);
                Console.WriteLine();
                Console.WriteLine(d.StackTrace);
            
            } finally {
                Console.WriteLine("\n\n\nSou executado mesmo que com exceções!");
            }
        }
    }
}
