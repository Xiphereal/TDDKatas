namespace AdventOfCode2022.Utils
{
    internal class FileReader
    {
        public static IEnumerable<string> LinesOfProblemInput(string path)
        {
            string allText = File.ReadAllText(path);

            return allText.Split(Environment.NewLine);
        }
    }
}