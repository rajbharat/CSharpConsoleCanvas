namespace ConsoleCanvas.Shapes
{
    public class Rectangle : IShape
    {

        private Point _p1;
        private Point _p2;

        public Rectangle(Point p1, Point p2) : base()
        {
            this._p1 = p1;
            this._p2 = p2;
        }

        public byte[,] Draw(byte[,] output)
        {
            for (int row = _p1.GetY(); row <= _p2.GetY(); row++)
            {
                for (int col = _p1.GetX(); col <= _p2.GetX(); col++)
                {
                    if ((row == _p1.GetY() || row == _p2.GetY()) || (col == _p1.GetX() || col == _p2.GetX()))
                    {
                        output[row, col] = (byte)'x';
                    }
                }
            }
            return output;
        }
    }
}
