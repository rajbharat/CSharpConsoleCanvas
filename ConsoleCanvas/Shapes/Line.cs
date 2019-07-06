namespace ConsoleCanvas.Shapes
{
    public class Line : IShape
    {

        private readonly Point _p1;
        private readonly Point _p2;


        public Line(Point p1, Point p2) : base()
        {

            this._p1 = p1;
            this._p2 = p2;
        }

        /**
         * Draw Line using Bresenham Algorithm
         */
        public byte[,] Draw(byte[,] output)
        {

            output[_p1.GetY(), _p1.GetX()] = (byte)'x';
            output[_p2.GetY(), _p2.GetX()] = (byte)'x';

            DrawLine(_p1.GetX(), _p1.GetY(), _p2.GetX(), _p2.GetY(), output);
            return output;
        }

        // Recursive function drawLine
        private void DrawLine(int x0, int y0, int x1, int y1, byte[,] output)
        {
            int xMid, yMid;

            xMid = (x0 + x1) / 2;
            yMid = (y0 + y1) / 2;

            if ((x0 == xMid && y0 == yMid) || (x1 == xMid && y1 == yMid)) return;
            // insert the char to matrix
            output[yMid, xMid] = (byte)'x';

            DrawLine(x0, y0, xMid, yMid, output);
            DrawLine(xMid, yMid, x1, y1, output);
        }
    }
}
