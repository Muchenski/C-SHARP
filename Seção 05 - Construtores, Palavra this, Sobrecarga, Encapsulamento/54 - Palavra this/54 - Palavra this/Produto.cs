using System;
using System.Collections.Generic;
using System.Text;

namespace _54___Palavra_this {
    class Produto {

        public string Nome;
        public double Preco;
        public int Quantidade;

        public Produto() {
            Quantidade = 0;
        }

        // Referenciando/Reaproveitando um construtor
        public Produto(string nome, double preco) : this() {
            Nome = nome;
            Preco = preco;
            // Quantidade = 0;
        }

        // Outro exemplo:
        public Produto(string nome, double preco, int quantidade) : this(nome, preco) {

            // Sobrepondo a quantidade.
            Quantidade = quantidade;

            // Nome = nome;
            // Preco = preco;
        }

    }
}
