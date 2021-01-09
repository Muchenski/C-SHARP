using Board_ns;
using Board_ns.exceptions;

namespace Chess_ns
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
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
        }

        public void MakeMove(Position origin, Position destiny)
        {
            MovePiece(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOrigin(Position position)
        {
            if(Board.GetPiece(position) == null)
            {
                throw new BoardException("There are no pieces in the chosen position!");
            }
            if(CurrentPlayer != Board.GetPiece(position).Color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if(!Board.GetPiece(position).ThereArePossibleMovements())
            {
                throw new BoardException("There are no possible moves for the chosen piece!");
            }
        }

        public void ValidateDestiny(Position origin, Position destiny)
        {
            if(!Board.GetPiece(origin).CanMoveToTheDestiny(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        public void ChangePlayer()
        {
            if(CurrentPlayer == Color.Black)
            {
                CurrentPlayer = Color.White;
            }
            else
            {
                CurrentPlayer = Color.Black;
            }
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
