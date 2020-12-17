using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace _56___Properties {
    class Produto {

        private string _nome;
        private double _preco;
        private int _quantidade;

        public Produto() {

        }

        // Properties são um modo mais prático de GET/SET
        // value representará o parâmetro do SET.

        // <nomeObjeto>.Nome = "Henrique" -> Set
        // <nomeObjeto>.Nome -> GET

        public string Nome {
            get { return _nome; }
            set { _nome = value; }
        }

        public double Preco {
            get { return _preco; }
            set { _preco = value; }
        }

        public int Quant {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
    }
}
