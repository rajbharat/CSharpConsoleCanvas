using ConsoleCanvas.Shapes;
using System;

namespace ConsoleCanvas.Validator
{
    public class CmdL : Command
    {

        public override String GetName()
        {
            return "l";
        }

        public override int Execute(String[] parameters)
        {
            if (!this.Validate(parameters))
            {
                return -1;
            }

            Point p1 = new Point(Int32.Parse(parameters[0]), Int32.Parse(parameters[1]));
            Point p2 = new Point(Int32.Parse(parameters[2]), Int32.Parse(parameters[3]));
            IShape line = new Line(p1, p2);
            canvas.AddShape(line);
            canvas.PrintCanvas();
            return 0;
        }

        public override bool ValidateLength(String[] parameters)
        {
            if (parameters.Length != Command.LINE)
            {
                Console.WriteLine("Wrong parameters to draw line, please check your command");
                return false;
            }
            return true;
        }
    }

}
