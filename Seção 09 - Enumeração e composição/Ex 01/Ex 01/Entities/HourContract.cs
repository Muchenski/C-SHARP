using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_01.Entities {
    class HourContract {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract() {

        }

        public HourContract(DateTime date, double valuePerHour, int hours) {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue() {
            return Hours * ValuePerHour;
        }

        public override string ToString() {
            return "\nData: " + Date + "\nValor por hora: " + ValuePerHour + "\nHoras: " + Hours + "\n";
        }
    }
}
