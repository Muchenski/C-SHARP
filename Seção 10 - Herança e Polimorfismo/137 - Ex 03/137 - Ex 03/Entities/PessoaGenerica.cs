using System;
using System.Collections.Generic;
using System.Text;

namespace _137___Ex_03.Entities {
    abstract class PessoaGenerica {
        public string Nome { get; set; }
        public double RendaAnual { get; set; }

        protected PessoaGenerica() {
        }

        protected PessoaGenerica(string nome, double rendaAnual) {
            Nome = nome;
            RendaAnual = rendaAnual;
        }

        public abstract double CalculaImposto();
    }
}
