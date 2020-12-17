using System;
using System.Collections.Generic;
using System.Text;

namespace _199___Exercício.entities {
    class Installment {
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public Installment() {
        }

        public Installment(DateTime date, double amount) {
            Date = date;
            Amount = amount;
        }

        public override string ToString() {
            return $"Date: {Date} - Amount: {Amount}";
        }
    }
}
