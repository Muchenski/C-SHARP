using System;
using Board_ns;

namespace Seção_12___Sistema_de_Xadrez
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            Piece piece;

            for(int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");

                for(int j = 0; j < board.Columns; j++)
                {
                    piece = board.GetPiece(new Position(i, j));

                    PrintPiece(piece);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor backgroundDefault = Console.BackgroundColor;
            ConsoleColor backgroundPerson = ConsoleColor.DarkGray;

            Piece piece;

            for(int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");

                for(int j = 0; j < board.Columns; j++)
                {
                    if(possiblePositions[i, j])
                    {
                        Console.BackgroundColor = backgroundPerson;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundDefault;
                    }
                    piece = board.GetPiece(new Position(i, j));
                    PrintPiece(piece);
                    Console.BackgroundColor = backgroundDefault;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = backgroundDefault;
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else
            {

                if(piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static ChessPosition InputChessPositions()
        {
            string origin = Console.ReadLine();
            return new ChessPosition(origin[0], int.Parse(origin[1] + ""));
        }
    }
}
