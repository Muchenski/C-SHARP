using Board_ns;

namespace Board_ns
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Row { get; set; }
       
        public ChessPosition()
        {
        }

        public ChessPosition(char column, int row)
        {
            Row = row;
            Column = column;
        }

        public Position ChessPositionToMatrixPosition()
        {
            // https://www.asciitable.com/
            return new Position(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return $"{Row}{Column}";
        }
    }
}
