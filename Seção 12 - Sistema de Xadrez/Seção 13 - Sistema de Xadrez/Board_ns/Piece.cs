

namespace Board_ns
{
    class Piece
    {
        public Position Position { get; set; }

        // The Color property can only be seted by his own subclasses and this class.
        public Color Color { get; protected set; }

        // The AmountOfMovements property can only be seted by his own subclasses and this class.
        public int AmountOfMovements { get; protected set; }

        // The Board property can only be seted by his own subclasses and this class.
        public Board Board { get; protected set; }

        public Piece()
        {
            AmountOfMovements = 0;
        }

        public Piece(Position position, Color color, int amountOfMovements, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
        }
    }
}
