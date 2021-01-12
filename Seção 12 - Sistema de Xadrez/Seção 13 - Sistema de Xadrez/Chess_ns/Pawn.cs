using Board_ns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_ns
{
    class Pawn:Piece
    {
        private readonly ChessMatch ChessMatch;

        public Pawn(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
        }

        private bool ThereIsAnOponent(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != Color;
        }

        private bool Livre(Position position)
        {
            return Board.GetPiece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            if(Color == Color.White)
            {
                position.UpdateValues(Position.Row - 1, Position.Collumn);
                if(Board.ValidPosition(position) && Livre(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row - 2, Position.Collumn);
                Position p2 = new Position(position.Row - 1, position.Collumn);
                if(Board.ValidPosition(p2) && Livre(p2) && Board.ValidPosition(position) && Livre(position) && AmountOfMovements == 0)
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row - 1, Position.Collumn - 1);
                if(Board.ValidPosition(position) && ThereIsAnOponent(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row - 1, Position.Collumn + 1);
                if(Board.ValidPosition(position) && ThereIsAnOponent(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }

                // En Passant
                if(Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Collumn - 1);
                    if(Board.ValidPosition(left) && ThereIsAnOponent(left) && Board.GetPiece(left) == ChessMatch.EnPassantVulnerability)
                    {
                        mat[left.Row - 1, left.Collumn] = true;
                    }

                    Position right = new Position(Position.Row, Position.Collumn + 1);
                    if(Board.ValidPosition(right) && ThereIsAnOponent(right) && Board.GetPiece(right) == ChessMatch.EnPassantVulnerability)
                    {
                        mat[right.Row - 1, right.Collumn] = true;
                    }
                }
            }
            else
            {
                position.UpdateValues(Position.Row + 1, Position.Collumn);
                if(Board.ValidPosition(position) && Livre(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row + 2, Position.Collumn);
                Position p2 = new Position(position.Row + 1, position.Collumn);
                if(Board.ValidPosition(p2) && Livre(p2) && Board.ValidPosition(position) && Livre(position) && AmountOfMovements == 0)
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row + 1, Position.Collumn - 1);
                if(Board.ValidPosition(position) && ThereIsAnOponent(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row + 1, Position.Collumn + 1);
                if(Board.ValidPosition(position) && ThereIsAnOponent(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }

                // En Passant
                if(Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Collumn - 1);
                    if(Board.ValidPosition(left) && ThereIsAnOponent(left) && Board.GetPiece(left) == ChessMatch.EnPassantVulnerability)
                    {
                        mat[left.Row + 1, left.Collumn] = true;
                    }

                    Position right = new Position(Position.Row, Position.Collumn + 1);
                    if(Board.ValidPosition(right) && ThereIsAnOponent(right) && Board.GetPiece(right) == ChessMatch.EnPassantVulnerability)
                    {
                        mat[right.Row + 1, right.Collumn] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
