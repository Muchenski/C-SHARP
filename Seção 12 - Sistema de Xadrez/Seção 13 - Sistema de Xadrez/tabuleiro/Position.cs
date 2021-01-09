
namespace tabuleiro
{
    class Position
    {
        public int Row { get; set; }
        public int Collumn { get; set; }

        public Position()
        {

        }

        public Position(int row, int collumn)
        {
            Row = row;
            Collumn = collumn;
        }

        public override string ToString()
        {
            return $"{Row},{Collumn}";
        }
    }
}
