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

        public Canvas BaseCanvas { get; set; }

        public abstract String GetName();

        public abstract int Execute(String[] parameters);

        public abstract bool ValidateLength(String[] parameters);

        public virtual bool Validate(String[] parameters)
        {
            if (parameters == null)
            {
                return false;
            }
            if (this.BaseCanvas == null)
            {
                Console.WriteLine(Constants.MISSING_CANVAS);
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
                    Console.WriteLine(Constants.NON_INTEGER_PARAM, param);
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

        protected bool ValidateParams(String[] parameters)
        {
            if (parameters == null)
            {
                Console.WriteLine(Constants.MISSING_PARAMS);
                return false;
            }

            return true;
        }
    }
}
