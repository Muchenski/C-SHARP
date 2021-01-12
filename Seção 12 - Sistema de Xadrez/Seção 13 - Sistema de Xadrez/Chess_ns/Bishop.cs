using Board_ns;

namespace Chess_ns
{
    class Bishop:Piece
    {

        public Bishop(Board board, Color color) : base(board, color)
        {

        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Rows];

            Position currentPosition = new Position(0, 0);

            // Checking Northeast 
            currentPosition.UpdateValues(Position.Row - 1, Position.Collumn + 1);
            while(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
                if(Board.GetPiece(currentPosition) != null && Board.GetPiece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Row--;
                currentPosition.Collumn++;
            }

            // Checking Northwest 
            currentPosition.UpdateValues(Position.Row - 1, Position.Collumn - 1);
            while(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
                if(Board.GetPiece(currentPosition) != null && Board.GetPiece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Collumn--;
                currentPosition.Row--;
            }

            // Checking Southeast
            currentPosition.UpdateValues(Position.Row + 1, Position.Collumn + 1);
            while(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
                if(Board.GetPiece(currentPosition) != null && Board.GetPiece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Collumn++;
                currentPosition.Row++;
            }

            // Checking Southwest
            currentPosition.UpdateValues(Position.Row + 1, Position.Collumn - 1);
            while(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
                if(Board.GetPiece(currentPosition) != null && Board.GetPiece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Collumn--;
                currentPosition.Row++;
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
            return "B";
        }
    }
}
