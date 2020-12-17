using System;
using System.Collections.Generic;
using System.Text;

namespace _137___Ex_03.Entities {
    sealed class PessoaFisica:PessoaGenerica {

        public double GastoSaude { get; set; }

        public PessoaFisica() {
        }

        public PessoaFisica(string nome, double rendaAnual, double gastoSaude) : base(nome, rendaAnual) {
            GastoSaude = gastoSaude;
        }

        public override double CalculaImposto() {

            double imposto = 0.0;

            if(RendaAnual < 20000.00) {
                imposto = RendaAnual * 0.15;

            }
            else {
                imposto = RendaAnual * 0.25;
            }

            if(GastoSaude > 0) {
                imposto -= GastoSaude / 2;
            }

            return imposto;
        }
    }
}
