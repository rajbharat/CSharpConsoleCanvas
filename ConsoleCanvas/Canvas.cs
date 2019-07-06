using ConsoleCanvas.Shapes;
using System;
using System.Collections.Generic;

namespace ConsoleCanvas
{
    public class Canvas
    {

        private int _height;
        private int _width;
        private readonly List<IShape> _shapes;

        // byte array instead of Character.
        private byte[,] canvasByteArray;
        /**
         * For the canvas borders, we add two columns and two rows
         *
         * @param width  int
         * @param height int
         */
        public Canvas(int width, int height)
        {
            this._height = height + 2; // why +2
            this._width = width + 2; // for the borders
            this._shapes = new List<IShape>();
            this.canvasByteArray = new Byte[_height, _width];
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int height)
        {
            this._height = height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void SetWidth(int width)
        {
            this._width = width;
        }



        public bool AddShape(IShape shapeInterface)
        {
            _shapes.Add(shapeInterface);
            return true;
        }

        /**
         * Method to render the canvas in the console
         */
        public void PrintCanvas()
        {

            // create borders.
            for (int row = 0; row < canvasByteArray.GetLength(0); row++)
            {
                for (int col = 0; col < canvasByteArray.GetLength(1); col++)
                {
                    if (row == 0 || row == canvasByteArray.GetLength(0) - 1)
                    {
                        canvasByteArray[row, col] = (byte)'-';
                    }
                    else if (col == 0 || col == canvasByteArray.GetLength(1) - 1)
                    {
                        canvasByteArray[row, col] = (byte)'|';
                    }
                    else
                    {
                        canvasByteArray[row, col] = (byte)' ';
                    }
                }
            }

            // append shapes one by one.
            foreach (IShape shapeInterface in _shapes)
            {
                canvasByteArray = shapeInterface.Draw(canvasByteArray);
            }

            // print to console.
            for (int i = 0; i < this._height; i++)
            {
                for (int j = 0; j < this._width; j++)
                {
                    Console.Write((char)canvasByteArray[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

}
