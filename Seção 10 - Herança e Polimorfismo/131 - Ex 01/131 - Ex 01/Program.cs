using _131___Ex_01.Entities;
using System;
using System.Collections.Generic;

namespace _131___Ex_01 {
    class Program {
        static void Main(string[] args) {

            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the numer of employees: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++) {
                Console.WriteLine($"\nEmploye {n}º data: ");

                Console.Write("\nOutsourced? [Y/N]: ");
                char yesOrNot = char.Parse(Console.ReadLine().Substring(0, 1).ToUpper());

                Console.Write("\nName: ");
                string name = Console.ReadLine();

                Console.Write("\nHours: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("\nValue per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                if(yesOrNot.Equals('Y')) {
                    Console.Write("\nAdditional charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine());

                    Employee oe = new OutsourceEmployee {
                        Name = name,
                        Hours = hours,
                        ValuePerHour = valuePerHour,
                        AdditionalCharge = additionalCharge
                    };
                    employees.Add(oe);

                }
                else if(yesOrNot == 'N') {
                    Employee e = new Employee {
                        Name = name,
                        Hours = hours,
                        ValuePerHour = valuePerHour
                    };

                    employees.Add(e);
                }

                Console.WriteLine("-------------------------------");
            }

            Console.WriteLine("\n\n-------------------------------");

            foreach(Employee employee in employees) {
                Console.WriteLine(employee + "\n-------------------------------");
            }
        }
    }
}
