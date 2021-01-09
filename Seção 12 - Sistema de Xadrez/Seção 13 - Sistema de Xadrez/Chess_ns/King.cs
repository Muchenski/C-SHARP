using Board_ns;

namespace Chess_ns
{
    class King:Piece
    {
        public King(Color color, Board board) : base(color, board)
        {

        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Rows];

            Position currentPosition = new Position(0, 0);

            // Checking North 
            currentPosition.UpdateValues(Position.Row - 1, Position.Collumn);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            // Checking Northeast
            currentPosition.UpdateValues(Position.Row - 1, Position.Collumn + 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            // Checking Northwest
            currentPosition.UpdateValues(Position.Row - 1, Position.Collumn - 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            // Checking South 
            currentPosition.UpdateValues(Position.Row + 1, Position.Collumn);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            // Checking Southeast 
            currentPosition.UpdateValues(Position.Row + 1, Position.Collumn + 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            // Checking Southwest 
            currentPosition.UpdateValues(Position.Row + 1, Position.Collumn - 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            // Checking Left
            currentPosition.UpdateValues(Position.Row, Position.Collumn - 1);
            if(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
            }

            // Checking Right
            currentPosition.UpdateValues(Position.Row, Position.Collumn + 1);
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
            return "K";
        }
    }
}
