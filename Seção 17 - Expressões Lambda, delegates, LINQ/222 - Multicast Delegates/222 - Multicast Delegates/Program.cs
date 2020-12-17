using _222___Multicast_Delegates.services;
using System;

namespace _222___Multicast_Delegates {
    class Program {

        delegate void BinaryNumericOperation(double n1, double n2);

        static void Main(string[] args) {

            // Referenciando mais de uma função com um delegate.
            BinaryNumericOperation b = CalculationService.ShowMax;
            b += CalculationService.ShowSum;

            b(10, 12);
        }
    }
}
