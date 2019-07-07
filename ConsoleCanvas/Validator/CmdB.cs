using ConsoleCanvas.Shapes;
using System;

namespace ConsoleCanvas.Validator
{
    public class CmdB : Command
    {


        public override String GetName()
        {
            return "b";
        }

        public override int Execute(String[] parameters)
        {
            if (!this.Validate(parameters))
            {
                return -1;
            }
            Point p = new Point(Int32.Parse(parameters[0]), Int32.Parse(parameters[1]));
            IShape fill = new Fill(p, (byte)(parameters[2])[0]);
            canvas.AddShape(fill);
            canvas.PrintCanvas();
            return 0;
        }
        //need to remove
        public override bool ValidateLength(String[] parameters)
        {
            if (parameters.Length != Command.FILL)
            {
                Console.WriteLine("Wrong parameters to Fill canvas, please check your command");
                return false;
            }
            return true;
        }


        public override bool ValidateTypes(String[] parameters)
        {
            for (int i = 0; i < parameters.Length - 1; i++)
            {
                if (!IsInteger(parameters[i]))
                {
                    Console.WriteLine("Parameter (" + parameters[i] + ") is not and integer");
                    return false;
                }
            }
            return true;
        }

        public override bool Validate(String[] parameters)
        {
            // check if it's null to avoid NullPointerException
            try
            {
                var basicValidation = base.Validate(parameters);

                if (basicValidation)
                {
                    int x1 = Int32.Parse(parameters[0]);
                    int y1 = Int32.Parse(parameters[1]);

                    if (x1 < 0 || y1 < 0)
                    {
                        Console.WriteLine("Negative arguments invalid ");
                        return false;
                    }

                    if (this.canvas.GetWidth() < x1 || this.canvas.GetHeight() < y1)
                    {
                        Console.WriteLine("Invalid Coordinates for Bucket Fill");
                        return false;
                    }

                }
                return basicValidation;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
                return false;
            }
        }

    }

}
