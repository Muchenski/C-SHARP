using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Columas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int columas)
        {
            Linhas = linhas;
            Columas = columas;
            Pecas = new Peca[linhas, columas];
        }

        public Peca GetPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public Peca GetPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca RemoverPeca(Posicao posicao)
        {
            if(GetPeca(posicao) == null)
            {
                return null;
            }

            Peca aux = GetPeca(posicao);
            aux.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;
            return aux;
        }

        public void SetPeca(Peca peca, Posicao posicao)
        {
            if(ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            }
            // Inserindo a peça em uma determinada posição do tabuleiro.
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            // Setando a posição da peça, na própria peça.
            peca.Posicao = posicao;
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return GetPeca(posicao) != null;
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if(posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Columas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if(!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
