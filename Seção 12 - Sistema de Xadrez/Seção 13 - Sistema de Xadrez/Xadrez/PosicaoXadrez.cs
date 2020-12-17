using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ConverterMatrizParaPosicaoXadrez()
        {
            /* 
             * O código da letra 'a' é 97 conforme tabela, e o código da letra 'e', por exemplo, é 101. 
             * Então, se você fizer a subtração 'e' - 'a' na verdade o resultado será 101 - 97 = 4, 
             * que é exatamente a quinta coluna da matriz, ou seja, a coluna 'e'.
             *
             */
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
