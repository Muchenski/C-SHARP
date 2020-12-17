using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _42___Exercicio_02 {
    class Produto {

        public string Nome;
        public double Preco;
        public int Quantidade;

        public double valorTotalEstoque() {
            return Quantidade * Preco;
        }

        public void adicionarProduto(int q) {
            Quantidade += q;
        }

        public void removerProduto(int q) {
            Quantidade -= q;
        }

        public override string ToString() {
            return Nome 
                + ", $" + Preco.ToString("F2", CultureInfo.InvariantCulture) 
                + ", " + Quantidade + " unidades, " 
                + "Total: $" + valorTotalEstoque();
        }
    }
}
