using ConsoleCanvas.Shapes;
using System;

namespace ConsoleCanvas.Validator
{
    public class CmdR : Command
    {

        public override String GetName()
        {
            return "r";
        }

        public override int Execute(String[] parameters)
        {
            if (!this.Validate(parameters))
            {
                return -1;
            }
            Point p3 = new Point(Int32.Parse(parameters[0]), Int32.Parse(parameters[1]));
            Point p4 = new Point(Int32.Parse(parameters[2]), Int32.Parse(parameters[3]));
            IShape rectangle = new Rectangle(p3, p4);
            canvas.AddShape(rectangle);
            canvas.PrintCanvas();
            return 0;
        }

        public override bool ValidateLength(String[] parameters)
        {
            if (parameters.Length != Command.RECTANGLE)
            {
                Console.WriteLine("Wrong parameters to draw rectangle, please check your command");
                return false;
            }
            return true;
        }
        public override bool Validate(String[] parameters)
        {
            var basicValidation = base.Validate(parameters);

            if (basicValidation)
            {
                int x1 = Int32.Parse(parameters[0]);
                int y1 = Int32.Parse(parameters[1]);
                int x2 = Int32.Parse(parameters[2]);
                int y2 = Int32.Parse(parameters[3]);

                if (x2 < 0 || y2 < 0 || x1 < 0 || y1 < 0)
                {
                    Console.WriteLine("Negative arguments invalid ");
                    return false;
                }
                if ( this.canvas.GetWidth() < x1|| this.canvas.GetWidth() <x2 ||  this.canvas.GetHeight() <y1||  this.canvas.GetHeight()<y2)
                {
                    Console.WriteLine("Invalid Coordinates for Rectangle");
                    return false;
                }

            }

            return basicValidation;
        }
    }

}
