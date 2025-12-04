namespace Dag3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag3/input.txt");
            string[] inputJoltage = readFromFile.Split("\n");

            int outputTotalJoltage = 0;
            int stringLength = inputJoltage[0].Length - 1;

            for (int i = 0; i < inputJoltage.Length - 1; i++)
            {
                char highestNumber = char.Parse(inputJoltage[i].Max().ToString());
                int numberLocation = inputJoltage[i].IndexOf(highestNumber);
                if (numberLocation < stringLength)
                {
                    char secondHighestNumber = char.Parse(inputJoltage[i].Substring(numberLocation + 1).Max().ToString());
                    int outputJoltage = Convert.ToInt32(string.Format("{0}{1}", highestNumber, secondHighestNumber));
                    outputTotalJoltage += outputJoltage;
                }
                else
                {
                    char highestNumber2 = char.Parse(inputJoltage[i][..stringLength].Max().ToString());
                    char secondHighestNumber = char.Parse(inputJoltage[i][numberLocation..].Max().ToString());
                    int outputJoltage = Convert.ToInt32(string.Format("{0}{1}", highestNumber2, secondHighestNumber));
                    outputTotalJoltage += outputJoltage;
                }
            }
            Console.WriteLine($"Totale max capaciteit: {outputTotalJoltage}");
        }
    }
}