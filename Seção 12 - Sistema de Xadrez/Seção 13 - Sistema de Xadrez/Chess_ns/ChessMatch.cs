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

        private readonly HashSet<Piece> AllPieces = new HashSet<Piece>();
        private readonly HashSet<Piece> CapturedPieces = new HashSet<Piece>();

        public bool Check { get; set; } = false;

        public Piece EnPassantVulnerability { get; private set; }

        public ChessMatch()
        {
            Finished = false;
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            SeedingPieces();
            EnPassantVulnerability = null;
        }

        private Color OpponentColor(Color color)
        {
            if(color == Color.Black)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        private Piece GetKing(Color color)
        {
            foreach(Piece piece in GetPiecesInPlay(color))
            {
                if(piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = GetKing(color);

            if(king == null)
            {
                throw new BoardException($"There is no king of the color {color} on the board.");
            }

            foreach(Piece piece in GetPiecesInPlay(OpponentColor(color)))
            {
                bool[,] possibleMovements = piece.PossibleMovements();
                if(possibleMovements[king.Position.Row, king.Position.Collumn])
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckMate(Color color)
        {
            if(!IsInCheck(color))
            {
                return false;
            }
            foreach(Piece piece in GetPiecesInPlay(color))
            {
                bool[,] possibleMovements = piece.PossibleMovements();
                for(int i = 0; i < Board.Rows; i++)
                {
                    for(int j = 0; j < Board.Columns; j++)
                    {
                        if(possibleMovements[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = MovePiece(piece.Position, destiny);
                            bool Check = IsInCheck(color);
                            UndoMove(origin, destiny, capturedPiece);
                            if(!Check)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public Piece MovePiece(Position origin, Position destiny)
        {
            Piece pieceOnMovement = Board.RemovePiece(origin);
            Piece capturedPiece = Board.RemovePiece(destiny);

            Board.SetPiece(pieceOnMovement, destiny);
            pieceOnMovement.IncreaseMovementsAmount();

            if(capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            //Castling King side
            if(pieceOnMovement is King && destiny.Collumn == origin.Collumn + 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Collumn + 3);
                Position towerDestiny = new Position(origin.Row, origin.Collumn + 1);
                Piece tower = Board.RemovePiece(towerOrigin);
                Board.SetPiece(tower, towerDestiny);
            }

            //Castling Queen side
            if(pieceOnMovement is King && destiny.Collumn == origin.Collumn - 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Collumn - 4);
                Position towerDestiny = new Position(origin.Row, origin.Collumn - 1);
                Piece tower = Board.RemovePiece(towerOrigin);
                Board.SetPiece(tower, towerDestiny);
            }

            // En passant
            if(pieceOnMovement is Pawn)
            {
                if(origin.Collumn != destiny.Collumn && capturedPiece == null)
                {
                    Position pawnPosition;
                    if(pieceOnMovement.Color == Color.White)
                    {
                        pawnPosition = new Position(destiny.Row + 1, destiny.Collumn);
                    }
                    else
                    {
                        pawnPosition = new Position(destiny.Row - 1, destiny.Collumn);
                    }
                    capturedPiece = Board.RemovePiece(pawnPosition);
                    CapturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void MakeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = MovePiece(origin, destiny);
            if(IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if(IsInCheck(OpponentColor(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if(CheckMate(OpponentColor(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            Piece piece = Board.GetPiece(destiny);
            //En Passant
            if(piece is Pawn && (destiny.Row == origin.Row - 2 || destiny.Row == origin.Row + 2))
            {
                EnPassantVulnerability = piece;
            }
            else
            {
                EnPassantVulnerability = null;
            }
        }

        public void UndoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece movedPiece = Board.RemovePiece(destiny);
            movedPiece.DecreaseMovementsAmount();
            if(capturedPiece != null)
            {
                Board.SetPiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }
            Board.SetPiece(movedPiece, origin);

            if(movedPiece is King && destiny.Collumn == origin.Collumn + 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Collumn + 3);
                Position towerDestiny = new Position(origin.Row, origin.Collumn + 1);
                Piece tower = Board.RemovePiece(towerOrigin);
                tower.DecreaseMovementsAmount();
                Board.SetPiece(tower, towerDestiny);
            }

            if(movedPiece is King && destiny.Collumn == origin.Collumn - 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Collumn - 3);
                Position towerDestiny = new Position(origin.Row, origin.Collumn - 1);
                Piece tower = Board.RemovePiece(towerOrigin);
                tower.DecreaseMovementsAmount();
                Board.SetPiece(tower, towerDestiny);
            }

            if(movedPiece is Pawn)
            {
                if(origin.Collumn != destiny.Collumn && capturedPiece == EnPassantVulnerability)
                {
                    Piece pawn = Board.RemovePiece(destiny);
                    Position pawnPosition;
                    if(pawn.Color == Color.White)
                    {
                        pawnPosition = new Position(3, destiny.Collumn);
                    }
                    else
                    {
                        pawnPosition = new Position(4, destiny.Collumn);
                    }
                    Board.SetPiece(pawn, pawnPosition);
                }
            }
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
            foreach(Piece piece in AllPieces)
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

        public void PutNewPiece(ChessPosition chessPosition, Piece piece)
        {
            Board.SetPiece(piece, chessPosition.ChessPositionToMatrixPosition());
            AllPieces.Add(piece);
        }

        public void SeedingPieces()
        {

            PutNewPiece(new ChessPosition('a', 1), new Tower(Board, Color.White));
            PutNewPiece(new ChessPosition('b', 1), new Horse(Board, Color.White));
            PutNewPiece(new ChessPosition('c', 1), new Bishop(Board, Color.White));
            PutNewPiece(new ChessPosition('d', 1), new Queen(Board, Color.White));
            PutNewPiece(new ChessPosition('e', 1), new King(Board, Color.White, this));
            PutNewPiece(new ChessPosition('f', 1), new Bishop(Board, Color.White));
            PutNewPiece(new ChessPosition('g', 1), new Horse(Board, Color.White));
            PutNewPiece(new ChessPosition('h', 1), new Tower(Board, Color.White));
            PutNewPiece(new ChessPosition('a', 2), new Pawn(Board, Color.White, this));
            PutNewPiece(new ChessPosition('b', 2), new Pawn(Board, Color.White, this));
            PutNewPiece(new ChessPosition('c', 2), new Pawn(Board, Color.White, this));
            PutNewPiece(new ChessPosition('d', 2), new Pawn(Board, Color.White, this));
            PutNewPiece(new ChessPosition('e', 2), new Pawn(Board, Color.White, this));
            PutNewPiece(new ChessPosition('f', 2), new Pawn(Board, Color.White, this));
            PutNewPiece(new ChessPosition('g', 2), new Pawn(Board, Color.White, this));
            PutNewPiece(new ChessPosition('h', 2), new Pawn(Board, Color.White, this));

            PutNewPiece(new ChessPosition('a', 8), new Tower(Board, Color.Black));
            PutNewPiece(new ChessPosition('b', 8), new Horse(Board, Color.Black));
            PutNewPiece(new ChessPosition('c', 8), new Bishop(Board, Color.Black));
            PutNewPiece(new ChessPosition('d', 8), new Queen(Board, Color.Black));
            PutNewPiece(new ChessPosition('e', 8), new King(Board, Color.Black, this));
            PutNewPiece(new ChessPosition('f', 8), new Bishop(Board, Color.Black));
            PutNewPiece(new ChessPosition('g', 8), new Horse(Board, Color.Black));
            PutNewPiece(new ChessPosition('h', 8), new Tower(Board, Color.Black));
            PutNewPiece(new ChessPosition('a', 7), new Pawn(Board, Color.Black, this));
            PutNewPiece(new ChessPosition('b', 7), new Pawn(Board, Color.Black, this));
            PutNewPiece(new ChessPosition('c', 7), new Pawn(Board, Color.Black, this));
            PutNewPiece(new ChessPosition('d', 7), new Pawn(Board, Color.Black, this));
            PutNewPiece(new ChessPosition('e', 7), new Pawn(Board, Color.Black, this));
            PutNewPiece(new ChessPosition('f', 7), new Pawn(Board, Color.Black, this));
            PutNewPiece(new ChessPosition('g', 7), new Pawn(Board, Color.Black, this));
            PutNewPiece(new ChessPosition('h', 7), new Pawn(Board, Color.Black, this));

        }
    }
}
