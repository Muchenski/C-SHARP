using Board_ns;

namespace Chess_ns
{
    class King:Piece
    {

        private ChessMatch ChessMatch;

        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
        }

        private bool TowerCastlingTest(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece is Tower && piece.Color == Color && piece.AmountOfMovements == 0;
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

            // #Castling
            if(AmountOfMovements == 0 && !ChessMatch.Check)
            {
                // Castling King side
                Position towerPosition1 = new Position(Position.Row, Position.Collumn + 3);
                if(TowerCastlingTest(towerPosition1))
                {
                    Position p1 = new Position(Position.Row, Position.Collumn + 1);
                    Position p2 = new Position(Position.Row, Position.Collumn + 2);

                    if(Board.GetPiece(p1) == null && Board.GetPiece(p2) == null)
                    {
                        matrix[Position.Row, Position.Collumn + 2] = true;
                    }
                }

                // Castling Queen side
                Position towerPosition2 = new Position(Position.Row, Position.Collumn - 4);
                if(TowerCastlingTest(towerPosition2))
                {
                    Position p1 = new Position(Position.Row, Position.Collumn - 1);
                    Position p2 = new Position(Position.Row, Position.Collumn - 2);
                    Position p3 = new Position(Position.Row, Position.Collumn - 3);

                    if(Board.GetPiece(p1) == null && Board.GetPiece(p2) == null && Board.GetPiece(p3) == null)
                    {
                        matrix[Position.Row, Position.Collumn - 2] = true;
                    }
                }
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
