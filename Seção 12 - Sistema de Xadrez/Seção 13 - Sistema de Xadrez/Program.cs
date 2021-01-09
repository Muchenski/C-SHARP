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
            try
            {
                do
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(cm.Board);
                        Console.WriteLine($"\nTurn: {cm.Turn}\nWaiting for >> {cm.CurrentPlayer}'s <<");

                        Console.WriteLine("\nEnter the origin position: ");
                        Position origin = Screen.InputChessPositions().ChessPositionToMatrixPosition();
                        cm.ValidateOrigin(origin);

                        Console.Clear();

                        bool[,] possiblePositions = cm.Board.GetPiece(origin).PossibleMovements();
                        Screen.PrintBoard(cm.Board, possiblePositions);

                        Console.WriteLine("\nEnter the destiny position: ");
                        Position destiny = Screen.InputChessPositions().ChessPositionToMatrixPosition();
                        cm.ValidateDestiny(origin, destiny);
                        cm.MakeMove(origin, destiny);

                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }

                } while(!cm.Finished);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
