using Board_ns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_ns
{
    class Queen:Piece
    {

        public Queen(Board board, Color color) : base(board, color)
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
                currentPosition.Row++;
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
                currentPosition.Collumn--;
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
                currentPosition.Collumn++;
            }

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
            return piece == null || piece.Color != Color;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
