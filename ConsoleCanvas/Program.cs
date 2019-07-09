using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCanvas
{
    public class Program
    {
        public static readonly Dictionary<char, Type> CmdDict = new Dictionary<char, Type>();

        public static void Main()
        {
            Canvas canvas = null;
            Command command;

            BuildCommands();
            PrintMenu();

            while (true)
            {
                Console.Write("$ ");
                String userInput = Console.ReadLine().Trim();
                if (!userInput.Equals(""))
                {
                    String[] splitCmd = userInput.Split(' ');
                    Char cmd = splitCmd[0].ToLower()[0];
                    String[] parameters = splitCmd.Skip(1).ToArray();
                    // check if the command exists
                    if (CmdDict.TryGetValue(cmd, out Type cmdType))
                    {
                        command = CommandFactory.GetCommand(cmdType);
                        if (canvas != null)
                        {
                            command.BaseCanvas = canvas;
                        }
                        command.Execute(parameters);
                        canvas = command.BaseCanvas;
                    }
                    else
                    {
                        Console.WriteLine(Constants.WRONGSWITCH);
                    }
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("***********  Hello Dear Reviewer *********");
            Console.WriteLine("******************************************");
            Console.WriteLine("*                                        *");
            Console.WriteLine("*                  CMD                   *");
            Console.WriteLine("*                                        *");
            Console.WriteLine("*   0) C w h          to create a canvas *");
            Console.WriteLine("*   1) L x1 y1 x2 y2  to draw a line     *");
            Console.WriteLine("*   2) R x1 y1 x2 y2  to draw rectangle  *");
            Console.WriteLine("*   3) B x1 y1 color  to refill          *");
            Console.WriteLine("*                                        *");
            Console.WriteLine("******************************************");
            Console.WriteLine("*   3) Q              to Exit            *");
            Console.WriteLine("******************************************");
        }

        private static void BuildCommands()
        {
            CmdDict.Add('c', typeof(CmdC));
            CmdDict.Add('l', typeof(CmdL));
            CmdDict.Add('r', typeof(CmdR));
            CmdDict.Add('b', typeof(CmdB));
            CmdDict.Add('q', typeof(CmdQ));
        }
    }
}
