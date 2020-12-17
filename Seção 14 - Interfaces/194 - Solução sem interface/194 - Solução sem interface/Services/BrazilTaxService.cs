using System;
using System.Collections.Generic;
using System.Text;

namespace _194___Solução_sem_interface.Services {
    class BrazilTaxService : ITaxService {

        public double Tax(double amount) {
            if(amount <= 100) return 0.2 * amount;
            else return amount * 0.15;
        }
    }
}
