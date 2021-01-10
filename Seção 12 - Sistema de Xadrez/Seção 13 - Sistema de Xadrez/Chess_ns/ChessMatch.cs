using Board_ns;
using Board_ns.exceptions;
using System.Collections.Generic;

namespace Chess_ns
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        private HashSet<Piece> AllPieces = new HashSet<Piece>();
        private HashSet<Piece> CapturedPieces = new HashSet<Piece>();

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

            if(capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> GetPiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece piece in CapturedPieces)
            {
                if(piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(GetCapturedPieces(color));
            return aux;
        }

        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece piece in CapturedPieces)
            {
                if(piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public void PutNewPiece(Piece piece, ChessPosition chessPosition)
        {
            Board.SetPiece(piece, chessPosition.ChessPositionToMatrixPosition());
            AllPieces.Add(piece);
        }

        public void SeedingPieces()
        {
            PutNewPiece(new Tower(Color.White, Board), new ChessPosition('c', 1));
            PutNewPiece(new Tower(Color.White, Board), new ChessPosition('c', 2));
            PutNewPiece(new King(Color.White, Board), new ChessPosition('d', 1));
            PutNewPiece(new Tower(Color.White, Board), new ChessPosition('d', 2));
            PutNewPiece(new Tower(Color.White, Board), new ChessPosition('e', 1));
            PutNewPiece(new Tower(Color.White, Board), new ChessPosition('e', 2));

            PutNewPiece(new Tower(Color.Black, Board), new ChessPosition('c', 7));
            PutNewPiece(new Tower(Color.Black, Board), new ChessPosition('c', 8));
            PutNewPiece(new Tower(Color.Black, Board), new ChessPosition('d', 7));
            PutNewPiece(new King(Color.Black, Board), new ChessPosition('d', 8));
            PutNewPiece(new Tower(Color.Black, Board), new ChessPosition('e', 7));
            PutNewPiece(new Tower(Color.Black, Board), new ChessPosition('e', 8));
        }
    }
}
