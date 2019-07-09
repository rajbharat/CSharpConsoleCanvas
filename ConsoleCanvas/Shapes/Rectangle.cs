namespace ConsoleCanvas.Shapes
{
    public class Rectangle : IShape
    {

        private readonly Point _p1;
        private readonly Point _p2;

        public Rectangle(Point p1, Point p2) : base()
        {
            this._p1 = p1;
            this._p2 = p2;
        }

        public byte[,] Draw(byte[,] output)
        {
            for (int row = _p1.Y; row <= _p2.Y; row++)
            {
                for (int col = _p1.X; col <= _p2.X; col++)
                {
                    if ((row == _p1.Y || row == _p2.Y) || (col == _p1.X || col == _p2.X))
                    {
                        output[row, col] = (byte)'x';
                    }
                }
            }
            return output;
        }
    }
}
