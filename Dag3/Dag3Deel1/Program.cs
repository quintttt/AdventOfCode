namespace Dag3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag3/input.txt");
            string[] inputJoltage = readFromFile.Trim().Split("\n");

            int outputTotalJoltage = 0;
            int stringLength = inputJoltage[0].Length - 1;

            foreach (string inputString in inputJoltage)
            {
                char highestNumber = char.Parse(inputString.Max().ToString());
                int numberLocation = inputString.IndexOf(highestNumber);
                if (numberLocation < stringLength)
                {
                    char secondHighestNumber = char.Parse(inputString.Substring(numberLocation + 1).Max().ToString());
                    int outputJoltage = Convert.ToInt32(string.Format("{0}{1}", highestNumber, secondHighestNumber));
                    outputTotalJoltage += outputJoltage;
                }
                else
                {
                    char highestNumber2 = char.Parse(inputString[..stringLength].Max().ToString());
                    char secondHighestNumber = char.Parse(inputString[numberLocation..].Max().ToString());
                    int outputJoltage = Convert.ToInt32(string.Format("{0}{1}", highestNumber2, secondHighestNumber));
                    outputTotalJoltage += outputJoltage;
                }
            }
            Console.WriteLine($"Totale max capaciteit: {outputTotalJoltage}");
        }
    }
}