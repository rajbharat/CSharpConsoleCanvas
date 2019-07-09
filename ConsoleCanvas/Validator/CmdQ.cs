using System;

namespace ConsoleCanvas.Validator
{
    public class CmdQ : Command
    {
        public override String GetName()
        {
            return "q";
        }

        public override int Execute(String[] parameters)
        {
            if (this.ValidateLength(parameters))
            {
                Console.WriteLine(Constants.EXIT);
                Environment.Exit(0);
            }
            return 0;
        }

        public override bool ValidateLength(String[] parameters)
        {
            if (parameters.Length != Command.QUIT)
            {
                Console.WriteLine(Constants.INCORRECT_PARAMS);
                return false;
            }
            return true;
        }
    }
}
