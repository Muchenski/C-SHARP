using System;
using System.Collections.Generic;
using System.Text;

namespace _199___Exercício.services {
    class PaypalService:IPaymentService {

        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;

        public double Interest(int months, double amount) {
            return amount * months * MonthlyInterest;
        }

        public double PaymentFee(double amount) {
            return amount * FeePercentage;
        }
    }
}
