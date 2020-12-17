using System;
using System.Collections.Generic;
using System.Text;

namespace _199___Exercício.entities {
    class Contract {

        public int Id { get; set; }
        public DateTime DataContrato { get; set; }
        public double ValorTotal { get; set; }

        public List<Installment> installments { get; set; }

        public Contract() {
            installments = new List<Installment>();
        }

        public Contract(int id, DateTime dataContrato, double valorTotal) {
            Id = id;
            DataContrato = dataContrato;
            ValorTotal = valorTotal;
        }

        public override string ToString() {
            return $"\nId: {Id} - Data do contrato: {DataContrato} - Valor total: {ValorTotal:C2}\n";
        }
    }
}
