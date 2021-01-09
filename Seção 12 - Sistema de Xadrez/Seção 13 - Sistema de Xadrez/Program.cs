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

            ChessMatch cm = new ChessMatch();

            do
            {
                try
                {
                    Console.Clear();
                    Screen.PrintBoard(cm.Board);

                    Console.WriteLine("\nEnter the origin position: ");
                    Position origin = Screen.InputChessPositions().ChessPositionToMatrixPosition();

                    Console.Clear();

                    bool[,] possiblePositions = cm.Board.GetPiece(origin).PossibleMovements();
                    Screen.PrintBoard(cm.Board, possiblePositions);

                    Console.WriteLine("\nEnter the destiny position: ");
                    Position destiny = Screen.InputChessPositions().ChessPositionToMatrixPosition();

                    cm.MovePiece(origin, destiny);
                }
                catch(BoardException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while(!cm.Finished);
        }
    }
}
