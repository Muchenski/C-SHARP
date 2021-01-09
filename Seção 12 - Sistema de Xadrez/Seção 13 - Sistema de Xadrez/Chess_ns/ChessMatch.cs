using Board_ns;

namespace Chess_ns
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn { get; set; }
        private Color CurrentPlayer { get; set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Finished = false;
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            SeedingPieces();
        }

        public void MovePiece(Position origin, Position destiny)
        {
            Piece pieceOnMovement = Board.RemovePiece(origin);
            Piece capturedPiece = Board.RemovePiece(destiny);

            Board.SetPiece(pieceOnMovement, destiny);
            pieceOnMovement.IncreaseMovementsAmount();
            Turn++;
        }

        public void SeedingPieces()
        {
            Board.SetPiece(new Tower(Color.White, Board), new ChessPosition('c', 1).ChessPositionToMatrixPosition());
            Board.SetPiece(new Tower(Color.White, Board), new ChessPosition('c', 2).ChessPositionToMatrixPosition());
            Board.SetPiece(new King(Color.White, Board), new ChessPosition('d', 1).ChessPositionToMatrixPosition());
            Board.SetPiece(new Tower(Color.White, Board), new ChessPosition('d', 2).ChessPositionToMatrixPosition());
            Board.SetPiece(new Tower(Color.White, Board), new ChessPosition('e', 1).ChessPositionToMatrixPosition());
            Board.SetPiece(new Tower(Color.White, Board), new ChessPosition('e', 2).ChessPositionToMatrixPosition());

            Board.SetPiece(new Tower(Color.Black, Board), new ChessPosition('c', 7).ChessPositionToMatrixPosition());
            Board.SetPiece(new Tower(Color.Black, Board), new ChessPosition('c', 8).ChessPositionToMatrixPosition());
            Board.SetPiece(new Tower(Color.Black, Board), new ChessPosition('d', 7).ChessPositionToMatrixPosition());
            Board.SetPiece(new King(Color.Black, Board), new ChessPosition('d', 8).ChessPositionToMatrixPosition());
            Board.SetPiece(new Tower(Color.Black, Board), new ChessPosition('e', 7).ChessPositionToMatrixPosition());
            Board.SetPiece(new Tower(Color.Black, Board), new ChessPosition('e', 8).ChessPositionToMatrixPosition());
        }
    }
}
