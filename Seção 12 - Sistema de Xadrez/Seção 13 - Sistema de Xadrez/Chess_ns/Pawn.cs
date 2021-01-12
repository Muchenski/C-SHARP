using Board_ns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_ns
{
    class Pawn:Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        private bool existeInimigo(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != Color;
        }

        private bool livre(Position position)
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
                if(Board.ValidPosition(position) && livre(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row - 2, Position.Collumn);
                Position p2 = new Position(position.Row - 1, position.Collumn);
                if(Board.ValidPosition(p2) && livre(p2) && Board.ValidPosition(position) && livre(position) && AmountOfMovements == 0)
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row - 1, Position.Collumn - 1);
                if(Board.ValidPosition(position) && existeInimigo(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row - 1, Position.Collumn + 1);
                if(Board.ValidPosition(position) && existeInimigo(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
            }
            else
            {
                position.UpdateValues(Position.Row + 1, Position.Collumn);
                if(Board.ValidPosition(position) && livre(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row + 2, Position.Collumn);
                Position p2 = new Position(position.Row + 1, position.Collumn);
                if(Board.ValidPosition(p2) && livre(p2) && Board.ValidPosition(position) && livre(position) && AmountOfMovements == 0)
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row + 1, Position.Collumn - 1);
                if(Board.ValidPosition(position) && existeInimigo(position))
                {
                    mat[position.Row, position.Collumn] = true;
                }
                position.UpdateValues(Position.Row + 1, Position.Collumn + 1);
                if(Board.ValidPosition(position) && existeInimigo(position))
                {
                    mat[position.Row, position.Collumn] = true;
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
