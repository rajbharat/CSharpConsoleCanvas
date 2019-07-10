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
            BaseCanvas.AddShape(fill);
            BaseCanvas.PrintCanvas();
            return 0;
        }

        public override bool ValidateLength(String[] parameters)
        {
            if (parameters.Length != Command.FILL)
            {
                Console.WriteLine(Constants.WRONG_PARAMS_LENGTH);
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
                    Console.WriteLine(Constants.NON_INTEGER_PARAM, parameters[i]);
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
                    int z1 = Int32.Parse(parameters[2]);

                    if (x1 < 0 || y1 < 0)
                    {
                        Console.WriteLine(Constants.NEGATIVE_ARGS);
                        return false;
                    }

                    if (this.BaseCanvas.Width < x1 || this.BaseCanvas.Height < y1)
                    {
                        Console.WriteLine(Constants.COORDINATES_OUTSIDE_CANVAS);
                        return false;
                    }
                    if (z1 < 0)
                    {
                        Console.WriteLine(Constants.NEGATIVE_ARGS);
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
