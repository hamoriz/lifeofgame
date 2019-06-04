namespace Conways_Game_of_Life_cs
{
    public class Cell
    {
        public int X;
        public int Y;


        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

       
        public override bool Equals(object obj)
        {
            Cell otherCell = (Cell) obj;
            
            if (X == otherCell.X && Y == otherCell.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}