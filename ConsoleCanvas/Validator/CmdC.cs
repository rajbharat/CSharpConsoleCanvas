using System;

namespace ConsoleCanvas.Validator
{
    public class CmdC : Command
    {
        public override String GetName()
        {
            return "c";
        }

        public override int Execute(String[] parameters)
        {
            if (!this.Validate(parameters))
            {
                return -1;
            }

            base.BaseCanvas = new Canvas(Int32.Parse(parameters[0]), Int32.Parse(parameters[1]));
            BaseCanvas.PrintCanvas();
            return 0;
        }

        public override bool ValidateLength(String[] parameters)
        {
            if (parameters.Length != Command.CREATE)
            {
                Console.WriteLine(Constants.WRONG_PARAMS_LENGTH);
                return false;
            }
            return true;
        }

        public override bool Validate(String[] parameters)
        {
            // check if it's null to avoid NullPointerException
            try
            {
                var basicValidation = ValidateParams(parameters) && ValidateLength(parameters) && ValidateTypes(parameters);
                if (basicValidation)
                {
                    int x1 = Int32.Parse(parameters[0]);
                    int y1 = Int32.Parse(parameters[1]);

                    if (x1 < 0 || y1 < 0)
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
