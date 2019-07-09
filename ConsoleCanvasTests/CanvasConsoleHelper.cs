using ConsoleCanvas;
using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCanvasTests
{
    class CanvasConsoleHelper
    {
        public static readonly Dictionary<char, Type> CmdDict = new Dictionary<char, Type>();

        private static void BuildCommands()
        {
            if (CmdDict.Count == 0)
            {
                CmdDict.Add('c', typeof(CmdC));
                CmdDict.Add('l', typeof(CmdL));
                CmdDict.Add('r', typeof(CmdR));
                CmdDict.Add('b', typeof(CmdB));
                CmdDict.Add('q', typeof(CmdQ));
            }
        }

        public static Type GetCommand(Char cmd)
        {
            BuildCommands();

            if (CmdDict.TryGetValue(Char.ToLower(cmd), out Type cmdType))
            {
                return cmdType;
            }
            else
            {
                Console.WriteLine(Constants.WRONGSWITCH);
                return null;
            }
        }



    }
}
