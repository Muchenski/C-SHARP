using _146___Ex_01.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _146___Ex_01.Entities {
    class Account {

        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithDrawLimit { get; set; }

        public Account() {
        }

        public Account(int number, string holder, double balance, double withDrawLimit) {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        public void Deposit(double amount) {

        }

        public void Withdraw(double amount) {
            if(Balance < amount || amount > WithDrawLimit) {
                throw new DomainException("Your balance is not enough or your attempt at cashing out exceeds the limit!");
            }

            Balance -= amount;
        }
    }
}
