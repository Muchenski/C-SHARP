using Board_ns;

namespace Chess_ns
{
    class Tower:Piece
    {
        public Tower(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
