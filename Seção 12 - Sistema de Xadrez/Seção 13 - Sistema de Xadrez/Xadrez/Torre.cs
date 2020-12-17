using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Torre:Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(cor, tabuleiro)
        {

        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Columas];

            Posicao posicao = new Posicao(0, 0);

            // Norte.
            posicao.NovaPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if(Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Linha--;
            }

            // Sul.
            posicao.NovaPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if(Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Linha++;
            }

            // Direita.
            posicao.NovaPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if(Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Coluna++;
            }

            // Esquerda.
            posicao.NovaPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if(Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Coluna--;
            }

            return matriz;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
