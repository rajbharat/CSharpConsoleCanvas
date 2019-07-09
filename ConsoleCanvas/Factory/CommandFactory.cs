using ConsoleCanvas.Validator;
using System;
using System.Reflection;

namespace ConsoleCanvas.Factory
{
    public class CommandFactory
    {
        public static Command GetCommand(Type command)
        {
            return Activator.CreateInstance(command) as Command;
        }

        public static Command GetCommand(string cmd)
        {
            Type type = Assembly.GetExecutingAssembly().GetType(cmd);
            return Activator.CreateInstance(type) as Command;
        }
    }
}
