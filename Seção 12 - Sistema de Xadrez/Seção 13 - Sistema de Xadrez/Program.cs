using System;
using Board_ns;
using Board_ns.exceptions;
using Chess_ns;

namespace Seção_12___Sistema_de_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board b = new Board(8, 8);
                b.SetPiece(new Tower(Color.Black, b), new Position(0, 0));
                b.SetPiece(new Tower(Color.White, b), new Position(1, 3));
                b.SetPiece(new King(Color.Black, b), new Position(0, 2));
                b.SetPiece(new Tower(Color.White, b), new Position(3, 5));
                Screen.PrintBoard(b);

            } catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
