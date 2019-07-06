using System;

namespace ConsoleCanvas.Validator
{
    public abstract class Command
    {
        protected static int QUIT = 0;
        protected static int CREATE = 2;
        protected static int LINE = 4;
        protected static int RECTANGLE = 4;
        protected static int FILL = 3;
        protected Canvas canvas;

        public Canvas GetCanvas()
        {
            return canvas;
        }

        public void SetCanvas(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public abstract String GetName();

        public abstract int Execute(String[] parameters);

        public abstract bool ValidateLength(String[] parameters);

        public virtual bool Validate(String[] parameters)
        {
            if (parameters == null)
            {
                return false;
            }
            if (this.canvas == null)
            {
                Console.WriteLine("You need to Create a Canvas first");
                return false;
            }
            return ValidateLength(parameters) && ValidateTypes(parameters);
        }

        public virtual bool ValidateTypes(String[] parameters)
        {
            foreach (String param in parameters)
            {
                if (!IsInteger(param))
                {
                    Console.WriteLine("Parameter (" + param + ") is not and integer");
                    return false;
                }
            }
            return true;
        }

        protected static bool IsInteger(String s)
        {
            try
            {
                Int32.Parse(s);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
                return false;
            }
            return true;
        }

        protected static bool ValidateParams(String[] parameters)
        {
            if (parameters == null)
            {
                Console.WriteLine("Parameters are missing");
                return false;
            }
            return true;
        }

    }
}
