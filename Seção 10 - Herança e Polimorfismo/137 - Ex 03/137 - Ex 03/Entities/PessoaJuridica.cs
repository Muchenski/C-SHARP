using System;
using System.Collections.Generic;
using System.Text;

namespace _137___Ex_03.Entities {
    sealed class PessoaJuridica:PessoaGenerica {

        public int NumeroFuncionario { get; set; }

        public PessoaJuridica() {
        }

        public PessoaJuridica(string nome, double rendaAnual, int numeroFuncionario) : base(nome, rendaAnual) {
            NumeroFuncionario = numeroFuncionario;
        }

        public override double CalculaImposto() {

            double imposto = RendaAnual * 0.16;

            if(NumeroFuncionario > 10) {
                imposto = RendaAnual * 0.14;
            }

            return imposto;
        }
    }
}
