using _194___Solução_sem_interface.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _194___Solução_sem_interface.Services {
    class RentalService {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxService _taxService { get; set; }

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService) {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental) {

            // Obetendo o tempo total do aluguel em TimeSpan.
            TimeSpan duration = carRental.DateFinish.Subtract(carRental.DateStart);
            double basicPayment = 0;

            if(duration.TotalHours <= 12) {
                //Math.Ceiling arredonda os valores.
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);

            }
            else {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
