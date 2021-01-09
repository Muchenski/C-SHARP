
namespace Board_ns
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        // The Board has an two-dimensional matrix of Pieces.
        // The property Pieces can only be seted and geted by this class.
        private Piece[,] Pieces { get; set; }

        public Board()
        {
        }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }
    }
}
