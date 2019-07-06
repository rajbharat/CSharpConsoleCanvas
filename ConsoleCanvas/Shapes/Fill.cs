namespace ConsoleCanvas.Shapes
{
    public class Fill : IShape
    {
        private readonly Point _p;
        private readonly byte _color;

        public Fill(Point p, byte color)
        {
            this._p = p;
            this._color = color;
        }

        public byte[,] Draw(byte[,] output)
        {
            BucketFill(output, this._p);
            return output;
        }

        /**
         * BucketFill Method, Fill empty spaces to the edge of other shapes
         * Recursive Function
         * @param output byte[][]
         * @param p Point
         */
        private void BucketFill(byte[,] output, Point p)
        {
            int currentColor = output[p.GetY(), p.GetX()];
            if (currentColor == ' ')
            {
                output[p.GetY(), p.GetX()] = this._color;
                BucketFill(output, new Point(p.GetX() + 1, p.GetY()));
                BucketFill(output, new Point(p.GetX() - 1, p.GetY()));
                BucketFill(output, new Point(p.GetX(), p.GetY() + 1));
                BucketFill(output, new Point(p.GetX() + 1, p.GetY() - 1));
            }
        }

    }
}
