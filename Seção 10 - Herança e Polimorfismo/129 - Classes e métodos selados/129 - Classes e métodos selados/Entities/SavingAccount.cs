using System;
using System.Collections.Generic;
using System.Text;

namespace _129___Classes_e_métodos_selados.Entities {

    // sealed -> faz com que não possam haver herdeiros desta classe.
    sealed class SavingAccount:Account {
        public double InterestRate { get; set; }

        public SavingAccount() {
        }

        public SavingAccount(int number, string holder, double balance, double interestRate)
            : base(number, holder, balance) {
            InterestRate = interestRate;
        }

        public void UpdateBalance() {
            Balance += Balance + InterestRate;
        }

        // Sobrepondo método da superclasse.
        // Queremos que este tipo de conta não tenha taxas no saque.

        // sealed faz com que um método que já foi sobrescrito não possa ser
        // sobrescrito novamente por uma subclasse
        
        // sealed só funciona com métodos que já foram sobrescritos.
        public sealed override void WithDraw(double amount) {
            Balance -= amount;
        }
    }
}
