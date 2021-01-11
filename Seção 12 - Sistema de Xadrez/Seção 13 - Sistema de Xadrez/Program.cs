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

            ChessMatch chessMatch = new ChessMatch();
            try
            {
                do
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintChessMatch(chessMatch);
                        Console.WriteLine("\nEnter the origin position: ");
                        Position origin = Screen.InputChessPositions().ChessPositionToMatrixPosition();
                        Console.WriteLine();
                        chessMatch.ValidateOrigin(origin);

                        Console.Clear();

                        bool[,] possiblePositions = chessMatch.Board.GetPiece(origin).PossibleMovements();
                        Screen.PrintBoard(chessMatch.Board, possiblePositions);

                        Console.WriteLine("\nEnter the destiny position: ");
                        Position destiny = Screen.InputChessPositions().ChessPositionToMatrixPosition();
                        Console.WriteLine();
                        chessMatch.ValidateDestiny(origin, destiny);
                        chessMatch.MakeMove(origin, destiny);

                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }

                } while(!chessMatch.Finished);
                Console.Clear();
                Screen.PrintChessMatch(chessMatch);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
