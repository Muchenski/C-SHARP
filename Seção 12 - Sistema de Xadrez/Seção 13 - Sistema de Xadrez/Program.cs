using System;
using Board_ns;
using Chess_ns;

namespace Seção_12___Sistema_de_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(8, 8);

            b.SetPiece(new Tower(Color.Black, b), new Position(0, 0));
            b.SetPiece(new Tower(Color.Black, b), new Position(1, 3));
            b.SetPiece(new King(Color.Black, b), new Position(2, 4));

            Screen.PrintBoard(b);
        }
    }
}
