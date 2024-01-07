namespace ConsoleCanvas
{
    public class Constants
    {
        //Validation for Commands
        public const string WRONG_PARAMS_LENGTH = "Incorrect number of arguments for this Switch";
        public const string NEGATIVE_NON_ZERO_ARGS = "Values should be a whole number greater than Zero";
        public const string INCORRECT_PARAMS = "Wrong parameters to Quit!";
        public const string MISSING_PARAMS = "Input Parameters are missing";
        public const string NON_INTEGER_PARAM = "Parameter {0} is not an integer";
        public const string COORDINATES_OUTSIDE_CANVAS = "Coordinates are Outside Canvas! Please supply valid parameters";
        public const string MISSING_CANVAS = "You need to Create a Canvas first";
        public const string WRONG_LINE_PARAMS = "Only Horizontal and Vertical lines are allowed!";
        public const string EXIT = "Exit...";
        public const string WRONGSWITCH = "**********WRONG COMMAND TRY AGAIN ********";
        public const string MAX_CANVAS_SIZE_EXCEEDED = "Max Canvas Size is 100 * 100";
        public const string MAX_COLOR_EXCEEDED = "Canvas should be between 0-9";
        public const int MAX_CANVAS_SIZE = 100;
        public const int MAX_COLOR_SIZE = 9;
    }
}
