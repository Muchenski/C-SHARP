using Ex_01.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Ex_01.Entities {
    class Worker {

        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public WorkerLevel Level { get; set; }

        public Department Department { get; set; }
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

        public Worker() {

        }

        public Worker(string name, double baseSalary, WorkerLevel level, Department department, List<HourContract> contracts) {
            Name = name;
            BaseSalary = baseSalary;
            Level = level;
            Department = department;
            Contracts = new List<HourContract>();
        }

        public void AddContract(HourContract contract) {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) {
            Contracts.Remove(contract);
        }

        public double Income(int month, int year) {
            double sum = BaseSalary;
            foreach(HourContract hc in Contracts) {
                if(hc.Date.Year == year && hc.Date.Month == month) {
                    sum += hc.TotalValue();
                }
            }
            return sum;
        }

        public override string ToString() {

            StringBuilder sb = new StringBuilder();

            foreach(HourContract hc in Contracts) {
                sb.Append(hc);
            }

            return "\nNome: " + Name
                + "\nSalario: " + BaseSalary
                + "\nLevel: " + Level
                + "\nDepartamento: " + Department
                + "\nContrato(s): \n" + sb.ToString();
        }
    }
}
