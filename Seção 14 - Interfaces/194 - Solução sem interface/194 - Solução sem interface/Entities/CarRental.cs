using System;
using System.Collections.Generic;
using System.Text;

namespace _194___Solução_sem_interface.Entities {
    class CarRental {
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        // Como a tarifa só será gerada quando for finalizado o aluguel do carro,
        // ela não estará no construtor.
        public CarRental(DateTime dateStart, DateTime dateFinish, Vehicle vehicle) {
            DateStart = dateStart;
            DateFinish = dateFinish;
            Vehicle = vehicle;
        }
    }
}
