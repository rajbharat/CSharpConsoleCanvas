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
    }

}
