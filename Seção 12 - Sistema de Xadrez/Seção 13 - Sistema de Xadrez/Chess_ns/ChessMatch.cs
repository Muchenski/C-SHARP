using Board_ns;

namespace Chess_ns
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn { get; set; }
        private Color CurrentPlayer { get; set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Finished = false;
            board = new Board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            SeedingPieces();
        }

        public void MovePiece(Position origin, Position destiny)
        {
            Piece pieceOnMovement = board.RemovePiece(origin);
            Piece capturedPiece = board.RemovePiece(destiny);

            board.SetPiece(pieceOnMovement, destiny);
            pieceOnMovement.IncreaseMovementsAmount();
            turn++;
        }

        public void SeedingPieces()
        {
            board.SetPiece(new Tower(Color.White, board), new ChessPosition('c', 1).ChessPositionToMatrixPosition());
            board.SetPiece(new Tower(Color.White, board), new ChessPosition('c', 2).ChessPositionToMatrixPosition());
            board.SetPiece(new King(Color.White, board), new ChessPosition('d', 1).ChessPositionToMatrixPosition());
            board.SetPiece(new Tower(Color.White, board), new ChessPosition('d', 2).ChessPositionToMatrixPosition());
            board.SetPiece(new Tower(Color.White, board), new ChessPosition('e', 1).ChessPositionToMatrixPosition());
            board.SetPiece(new Tower(Color.White, board), new ChessPosition('e', 2).ChessPositionToMatrixPosition());

            board.SetPiece(new Tower(Color.Black, board), new ChessPosition('c', 7).ChessPositionToMatrixPosition());
            board.SetPiece(new Tower(Color.Black, board), new ChessPosition('c', 8).ChessPositionToMatrixPosition());
            board.SetPiece(new Tower(Color.Black, board), new ChessPosition('d', 7).ChessPositionToMatrixPosition());
            board.SetPiece(new King(Color.Black, board), new ChessPosition('d', 8).ChessPositionToMatrixPosition());
            board.SetPiece(new Tower(Color.Black, board), new ChessPosition('e', 7).ChessPositionToMatrixPosition());
            board.SetPiece(new Tower(Color.Black, board), new ChessPosition('e', 8).ChessPositionToMatrixPosition());
        }
    }
}
