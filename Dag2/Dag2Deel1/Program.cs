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

            for (int i = 0; i < inputID.Length; i++)
            {
                string[] idRange = inputID[i].Split('-');
                for (long id = long.Parse(idRange[0]); id <= long.Parse(idRange[1]); id++)
                {
                    string idString = id.ToString();
                    int splitId = idString.Length / 2;
                    if (Regex.IsMatch(idString, allowedChar) && idString[0..splitId] == idString[splitId..])
                    {
                        Console.WriteLine(id);
                        invalidIdSum += id;
                    }
                }
            }
            Console.WriteLine(invalidIdSum++);
        }
    }
}