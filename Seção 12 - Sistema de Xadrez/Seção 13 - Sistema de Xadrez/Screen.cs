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
                for(int j = 0; j < board.Columns; j++)
                {

                    piece = board.GetPiece(new Position(i, j));

                    if(piece != null)
                    {
                        Console.Write(piece + " ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
