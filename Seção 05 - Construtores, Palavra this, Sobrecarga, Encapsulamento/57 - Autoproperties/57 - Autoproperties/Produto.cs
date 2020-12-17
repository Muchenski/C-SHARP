using System;
using System.Collections.Generic;
using System.Text;

namespace _57___Autoproperties {
    class Produto {

        public string Nome { get; private set; }
        public double Preco { get; private set; }
        public int quantidade { get; private set; }

        public Produto() {

        }

        public string SetNome {
            set { Nome = value; }
            }
    }
}
