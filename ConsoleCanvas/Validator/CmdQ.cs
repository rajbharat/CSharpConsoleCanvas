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
                Console.WriteLine("Exit...");
                return (0);
            }
            return 0;
        }

        public override bool ValidateLength(String[] parameters)
        {
            if (parameters.Length != Command.QUIT)
            {
                Console.WriteLine("Wrong parameters!");
                return false;
            }
            return true;
        }
    }
}
