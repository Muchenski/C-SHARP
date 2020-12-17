using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _194___Solução_sem_interface.Entities {
    class Invoice {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double rental, double tax) {
            BasicPayment = rental;
            Tax = tax;
        }

        public double TotalPayment {
            get { return BasicPayment + Tax; }
        }

        public override string ToString() {
            return $"Basic Payment: {BasicPayment.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                $"Tax: {Tax}\n" +
                $"Total Payment: {TotalPayment.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
