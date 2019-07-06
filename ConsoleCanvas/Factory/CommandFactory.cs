using ConsoleCanvas.Validator;
using System;

namespace ConsoleCanvas.Factory
{
    public class CommandFactory
    {
        public Command GetCommand(Char cmd)
        {
            if (cmd.Equals(' '))
            {
                return null;
            }

            if (cmd.Equals('c'))
            {
                return new CmdC();
            }
            else if (cmd.Equals('l'))
            {
                return new CmdL();
            }
            else if (cmd.Equals('r'))
            {
                return new CmdR();
            }
            else if (cmd.Equals('b'))
            {
                return new CmdB();
            }
            else if (cmd.Equals('q'))
            {
                return new CmdQ();
            }
            return null;
        }
    }
}
