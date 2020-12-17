using _221___Delegates.services;
using System;

namespace _221___Delegates {

    delegate double BinaryNumericOperation(double n1, double n2);

    class Program {
        static void Main(string[] args) {

            double a = 10;
            double b = 12;

            // Referência para função que recebe dois parâmetros double e retorna um double.
            BinaryNumericOperation op = CalculationService.Sum;
            Console.WriteLine(op(a, b));
            op = CalculationService.Max;
            Console.WriteLine(op(a, b));
        }
    }
}
