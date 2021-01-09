using System;
using Board_ns;

namespace Seção_12___Sistema_de_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(8, 8);
            Screen.PrintBoard(b);
        }
    }
}
