using ConsoleCanvas.Shapes;
using System;
using System.Collections.Generic;

namespace ConsoleCanvas
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private readonly List<IShape> _shapes;
        // byte array instead of Character.
        private byte[,] canvasByteArray;
        /// <summary>
        /// For the canvas borders, we add two columns and two rows
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Canvas(int width, int height)
        {
            Height = height + 2; // why +2
            Width = width + 2; // for the borders
            this._shapes = new List<IShape>();
            this.canvasByteArray = new Byte[Height, Width];
        }

        public bool AddShape(IShape shapeInterface)
        {
            _shapes.Add(shapeInterface);
            return true;
        }

        /// <summary>
        /// Method to render the canvas in the console
        /// </summary>
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
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write((char)canvasByteArray[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

}
