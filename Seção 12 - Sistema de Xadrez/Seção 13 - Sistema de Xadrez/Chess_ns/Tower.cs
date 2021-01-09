using Board_ns;

namespace Chess_ns
{
    class Tower:Piece
    {
        public Tower(Color color, Board board) : base(color, board)
        {

        }

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Rows];

            Position currentPosition = new Position(0, 0);

            // Checking North 
            currentPosition.UpdateValues(Position.Row - 1, Position.Collumn);
            while(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
                if(Board.GetPiece(currentPosition) != null && Board.GetPiece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Row--;
            }

            // Checking South 
            currentPosition.UpdateValues(Position.Row + 1, Position.Collumn);
            while(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
                if(Board.GetPiece(currentPosition) != null && Board.GetPiece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Row++;
            }

            // Checking Left
            currentPosition.UpdateValues(Position.Row, Position.Collumn - 1);
            while(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
                if(Board.GetPiece(currentPosition) != null && Board.GetPiece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Collumn--;
            }

            // Checking Right
            currentPosition.UpdateValues(Position.Row, Position.Collumn + 1);
            while(Board.ValidPosition(currentPosition) && CanMove(currentPosition))
            {
                matrix[currentPosition.Row, currentPosition.Collumn] = true;
                if(Board.GetPiece(currentPosition) != null && Board.GetPiece(currentPosition).Color != Color)
                {
                    break;
                }
                currentPosition.Collumn++;
            }

            return matrix;
        }

        public bool CanMove(Position position)
        {
            // if there's no piece on the destiny position, or there's a adversary piece.
            Piece piece = Board.GetPiece(position);
            return (piece == null || piece.Color != Color);
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
