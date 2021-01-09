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
                ChessMatch cm = new ChessMatch();

                do
                {
                    Console.Clear();
                    Screen.PrintBoard(cm.board);

                    Console.WriteLine("\nEnter the origin position: ");
                    Position origin = Screen.InputChessPositions().ChessPositionToMatrixPosition();

                    Console.WriteLine("\nEnter the destiny position: ");
                    Position destiny = Screen.InputChessPositions().ChessPositionToMatrixPosition();

                    cm.MovePiece(origin, destiny);

                } while(!cm.Finished);


            } catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
