using System;
using System.Collections.Generic;
using System.Text;

namespace _129___Classes_e_métodos_selados.Entities {
    class BusinessAccount:Account {
        public double LoanLimit { get; set; }


        public BusinessAccount() {

        }

        public BusinessAccount(int number, string holder, double balance, double loanLimit)
            : base(number, holder, balance) {
            LoanLimit = loanLimit;
        }

        public void Loan(double amount) {
            if(amount <= LoanLimit) {
                Balance += amount;
            }
        }

        // Sobrepondo o método da superclasse.
        // Queremos que o saque na BusinessAccount tenha um acréscimo de 2
        // na taxa.

        public override void WithDraw(double amount) {
            base.WithDraw(amount);
            Balance -= 2;
        }
    }
}
