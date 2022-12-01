namespace AdventOfCode2022.Day1.Views
{
    internal class FileReader : IFileReader
    {
        public IEnumerable<string> LinesOfProblemInput()
        {
            const string Path = "./Day1/Input.txt";
            string allText = File.ReadAllText(Path);

            return allText.Split(Environment.NewLine);
        }
    }
}