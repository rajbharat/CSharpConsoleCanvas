using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using System;
using System.Linq;

namespace ConsoleCanvas
{
    class Program
    {
        private static readonly String _availableCmd = "clrbq";

        public static void Main(String[] args)
        {
            Canvas canvas = null;
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

                    CommandFactory commandFactory = new CommandFactory();
                    Command command;
                    // check if the command exists
                    if (_availableCmd.IndexOf(cmd) > -1)
                    {
                        switch (cmd)
                        {
                            case 'c':
                                // command Create
                                command = commandFactory.GetCommand(cmd);
                                command.Execute(parameters);
                                canvas = command.GetCanvas();
                                break;
                            case 'l':
                                // command Line
                                command = commandFactory.GetCommand(cmd);
                                command.SetCanvas(canvas);
                                command.Execute(parameters);
                                break;
                            case 'r':
                                // command Rectangle
                                command = commandFactory.GetCommand(cmd);
                                command.SetCanvas(canvas);
                                command.Execute(parameters);
                                break;
                            case 'b':
                                // command bucket fill
                                command = commandFactory.GetCommand(cmd);
                                command.SetCanvas(canvas);
                                command.Execute(parameters);
                                break;
                            case 'q':
                                // command exit
                                Command command4 = commandFactory.GetCommand(cmd);
                                command4.Execute(parameters);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("**********WRONG COMMAND TRY AGAIN ********");
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
            Console.WriteLine("*   0) C w h          to create a convas *");
            Console.WriteLine("*   1) L x1 y1 x2 y2  to draw a line     *");
            Console.WriteLine("*   2) R x1 y1 x2 y2  to draw rectangle  *");
            Console.WriteLine("*   3) B x1 y1 color  to refill          *");
            Console.WriteLine("*                                        *");
            Console.WriteLine("******************************************");
            Console.WriteLine("*   3) Q              to Exit            *");
            Console.WriteLine("******************************************");
        }
    }
}
