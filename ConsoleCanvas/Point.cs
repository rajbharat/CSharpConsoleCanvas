namespace ConsoleCanvas
{
    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public int GetX()
        {
            return _x;
        }

        public void SetX(int x)
        {
            this._x = x;
        }

        public int GetY()
        {
            return _y;
        }

        public void SetY(int y)
        {
            this._y = y;
        }

    }

}
