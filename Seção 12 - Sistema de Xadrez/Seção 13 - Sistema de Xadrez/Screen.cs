using System;
using Board_ns;

namespace Seção_12___Sistema_de_Xadrez
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for(int i = 0; i < board.Rows; i++)
            {
                for(int j = 0; j < board.Columns; j++)
                {
                    if(board.GetPiece(new Position(i, j)) == null)
                    {
                        Console.Write(board.GetPiece(new Position(i, j)) + "- ");
                    }
                    else
                    {
                        Console.WriteLine("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
