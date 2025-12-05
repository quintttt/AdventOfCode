namespace Dag5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag5/input.txt");
            string[] inputIdFile = readFromFile.Split("\n");

            int arraySplitLocation = 0;
            while (inputIdFile[arraySplitLocation] != "") { arraySplitLocation++; }
            int arrayStringLength = inputIdFile.Length - arraySplitLocation - 2;

            string[] idRangeArray = new string[arraySplitLocation];
            string[] idStringArray = new string[arrayStringLength];

            Array.Copy(inputIdFile, idRangeArray, arraySplitLocation);
            Array.Copy(inputIdFile, arraySplitLocation + 1, idStringArray, 0, arrayStringLength);

            int freshCounter = 0;
            bool isSpoiled;

            foreach (string id in idStringArray)
            {
                isSpoiled = true;
                foreach (string idRange in idRangeArray)
                {
                    string[] idRangeSplit = idRange.Split('-');
                    if (ulong.Parse(id) >= ulong.Parse(idRangeSplit[0]) && ulong.Parse(id) <= ulong.Parse(idRangeSplit[1]))
                    {
                        if (isSpoiled == true) { freshCounter++; }
                        isSpoiled = false;
                    }
                }
            }
            Console.WriteLine($"{freshCounter} producten zijn nog vers.");
        }
    }
}