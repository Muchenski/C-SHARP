using Board_ns;

namespace Chess_ns
{
    class Horse:Piece
    {

        public Horse(Board board, Color color) : base(board, color)
        {

        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Rows];

            Position currentPosition = new Position(0, 0);

            currentPosition.UpdateValues(Position.Row - 1, Position.Collumn - 2);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            currentPosition.UpdateValues(Position.Row - 2, Position.Collumn - 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            currentPosition.UpdateValues(Position.Row - 1, Position.Collumn + 2);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            currentPosition.UpdateValues(Position.Row - 2, Position.Collumn + 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            currentPosition.UpdateValues(Position.Row + 1, Position.Collumn + 2);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            currentPosition.UpdateValues(Position.Row + 2, Position.Collumn + 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            currentPosition.UpdateValues(Position.Row + 1, Position.Collumn - 2);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            currentPosition.UpdateValues(Position.Row + 2, Position.Collumn - 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            return matrix;
        }


        public bool CanMove(Position position)
        {
            // if there's no piece on the destiny position, or there's a adversary piece.
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
