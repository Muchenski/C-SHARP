using System;
using System.Collections.Generic;
using _199___Exercício.entities;
using System.Text;

namespace _199___Exercício.services {
    class ContractService {

        private IPaymentService _paymentService;

        public ContractService(IPaymentService paymentService) {
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months) {
            double parcelaNormal = contract.ValorTotal / months;
            for(int i = 1; i <= months; i++) {
                DateTime date = contract.DataContrato.AddMonths(i);
                double parcelaAtualizada = parcelaNormal + _paymentService.Interest(i, parcelaNormal);
                double parcelaTotal = parcelaAtualizada + _paymentService.PaymentFee(parcelaAtualizada);
                contract.installments.Add(new Installment(date, parcelaTotal));
            }
        }
    }
}
