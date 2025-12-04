using System.Text.RegularExpressions;

namespace Dag2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag2/input.txt");
            string[] inputID = readFromFile.Split(",");

            long invalidIdSum = 0;
            string allowedChar = """\b(\d+)\1+\b""";

            foreach (string inputIdString in inputID)
            {
                string[] idRange = inputIdString.Split('-');
                for (long id = long.Parse(idRange[0]); id <= long.Parse(idRange[1]); id++)
                {
                    string idString = id.ToString();
                    if (Regex.IsMatch(idString, allowedChar)) { invalidIdSum += id; }
                }
            }
            Console.WriteLine($"Som van ongeldige ID's: {invalidIdSum++}");
        }
    }
}