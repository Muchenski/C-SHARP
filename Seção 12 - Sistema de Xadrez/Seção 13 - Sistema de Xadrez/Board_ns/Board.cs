using Board_ns.exceptions;
using Chess_ns;

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

        public Piece GetPiece(Position position)
        {
            return Pieces[position.Row, position.Collumn];
        }

        public void SetPiece(Piece piece, Position position)
        {
            if(PositionAlreadyOccupied(position))
            {
                throw new BoardException("There's already a piece in that position!");
            }
            Pieces[position.Row, position.Collumn] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            Piece piece = GetPiece(position);

            if(piece == null)
            {
                return null;
            }

            piece.Position = null;
            Pieces[position.Row, position.Collumn] = null;
            return piece;
        }

        public bool PositionAlreadyOccupied(Position position)
        {
            PositionExceptionCheck(position);
            return GetPiece(position) != null;
        }

        public bool ValidPosition(Position position)
        {
            if(position.Row >= Rows || position.Collumn >= Columns || position.Row < 0 || position.Collumn < 0)
            {
                return false;
            }
            return true;
        }

        public void PositionExceptionCheck(Position position)
        {
            if(!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
