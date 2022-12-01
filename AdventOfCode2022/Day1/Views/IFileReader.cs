namespace AdventOfCode2022.Day1.Views
{
    public interface IFileReader
    {
        IEnumerable<string> LinesOfProblemInput();
    }
}