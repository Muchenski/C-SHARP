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

                    if(piece != null)
                    {
                        PrintPiece(piece);
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
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
        }

        public static ChessPosition InputChessPositions()
        {
            string origin = Console.ReadLine();
            return new ChessPosition(origin[0], int.Parse(origin[1] + ""));
        }
    }
}
