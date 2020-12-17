using System;
using System.Collections.Generic;
using System.Text;

namespace _222___Multicast_Delegates.services {
    class CalculationService {
        public static void ShowMax(double x, double y) {
            double max = (x > y) ? x : y;
            Console.WriteLine(max);
        }
        public static void ShowSum(double x, double y) {
            double sum = x + y;
            Console.WriteLine(sum);
        }
    }
}
