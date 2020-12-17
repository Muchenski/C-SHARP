﻿using _126___Herança.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _127___Upcasting_e_Downcasting.Entities {
    class SavingAccount:Account {
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
    }
}
