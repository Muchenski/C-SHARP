using System;
using System.Collections.Generic;
using System.Text;

namespace _199___Exercício.services {
    interface IPaymentService {
        public double Interest(int months, double amount);
        public double PaymentFee(double amount);
    }
}
