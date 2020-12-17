using Ex_01.Entities;
using Ex_01.Entities.Enums;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Globalization;

namespace Ex_01 {
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter department's name: ");
            Department department = new Department { Name = Console.ReadLine() };

            Console.WriteLine("\nEnter worker date: ");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("\nBase salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("\nLevel [Junior-MidLevel-Senior]: ");
            string level = Console.ReadLine();

            Worker worker = new Worker {
                Name = name,
                BaseSalary = baseSalary,
                Level = Enum.Parse<WorkerLevel>(level),
                Department = department
            };

            Console.Write("\nHow many contracts to this worker?: ");
            int numberOfContracts = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfContracts; i++) {

                Console.Write("\nDate [DD/MM/YYYY]: ");
                string date = Console.ReadLine();

                Console.Write("\nValue per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                Console.Write("\nDuration(hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract hc = new HourContract {
                    Date = DateTime.Parse(date),
                    Hours = hours,
                    ValuePerHour = valuePerHour
                };

                worker.AddContract(hc);
            }

            Console.WriteLine(worker.ToString());

            Console.WriteLine();

            Console.Write("Enter the month to calculate income [DD/MM/YYYY]: ");
            string yearMonth = Console.ReadLine();
            Console.WriteLine($"Name: {worker.Name}\nDepartment: {worker.Department}\n" +
                $"Income for {yearMonth}: {worker.Income(int.Parse(yearMonth.Substring(0, 2)), int.Parse(yearMonth.Substring(3)))}");

        }
    }
}
