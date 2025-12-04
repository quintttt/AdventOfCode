namespace Dag3
{
    internal class Program
    {
        static string[] InputJoltage()
        {
            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag3/input.txt");
            return readFromFile.Trim().Split("\n");
        }

        static int OutputJoltage(string inputString, int stringLength)
        {
            char highestNumber = char.Parse(inputString.Max().ToString());
            int numberLocation = inputString.IndexOf(highestNumber);
            if (numberLocation < stringLength)
            {
                char secondHighestNumber = char.Parse(inputString.Substring(numberLocation + 1).Max().ToString());
                int outputJoltage = Convert.ToInt32(string.Concat(highestNumber, secondHighestNumber));
                return outputJoltage;
            }
            else
            {
                char highestNumber2 = char.Parse(inputString[..stringLength].Max().ToString());
                char secondHighestNumber = char.Parse(inputString[numberLocation..].Max().ToString());
                int outputJoltage = Convert.ToInt32(string.Concat(highestNumber2, secondHighestNumber));
                return outputJoltage;
            }
        }

        static void Main(string[] args)
        {
            int outputTotalJoltage = 0;
            int stringLength = InputJoltage()[0].Length - 1;

            foreach (string inputString in InputJoltage())
            {
                outputTotalJoltage += OutputJoltage(inputString, stringLength);
            }
            Console.WriteLine($"Totale max capaciteit: {outputTotalJoltage}");
        }
    }
}
