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
                ChessPosition cp = new ChessPosition('c', 7);
                Console.WriteLine(cp);
                Console.WriteLine(cp.ChessPositionToMatrixPosition());

            } catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
