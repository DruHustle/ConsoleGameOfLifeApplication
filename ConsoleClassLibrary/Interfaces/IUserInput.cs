namespace ConsoleClassLibrary
{
    public interface IUserInput
    {
        int GetValues( out bool generationsIsParsable);
        int GetValues(string s, int lowBound, int upperBound, out bool widthIsParsable);
    }
}