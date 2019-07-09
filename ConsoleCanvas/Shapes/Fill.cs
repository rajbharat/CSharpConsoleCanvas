namespace ConsoleCanvas.Shapes
{
    public class Fill : IShape
    {
        private readonly Point Pt;
        private readonly byte Color;

        public Fill(Point p, byte color)
        {
            Pt = p;
            Color = color;
        }

        public byte[,] Draw(byte[,] output)
        {
            BucketFill(output, this.Pt);
            return output;
        }

        /// <summary>
        ///   BucketFill Method, Fill empty spaces to the edge of other shapes Recursive Function
        /// </summary>
        /// <param name="output"></param>
        /// <param name="p"></param>
        private void BucketFill(byte[,] output, Point p)
        {
            int currentColor = output[p.Y, p.X];
            if (currentColor == ' ')
            {
                output[p.Y, p.X] = this.Color;
                BucketFill(output, new Point(p.X + 1, p.Y));
                BucketFill(output, new Point(p.X - 1, p.Y));
                BucketFill(output, new Point(p.X, p.Y + 1));
                BucketFill(output, new Point(p.X + 1, p.Y - 1));
            }
        }
    }
}
