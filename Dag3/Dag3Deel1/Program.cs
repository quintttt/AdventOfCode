namespace Dag3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputJoltageTest = { "987654321111111", "811111111111119", "234234234234278", "818181911112111" };

            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag3/input.txt");
            string[] inputJoltage = readFromFile.Split("\n");
            int totalOutput = 0;
            /* Note to self, wat hier gebeurt is: we checken het grootste nummer in een string. hierna checken met de index de locatie van deze char. \
            als deze aan het einde staat maken we de string een stukje korter en zoeken we in de nieuwe string opnieuw naar het grootste cijfer. 
            hierna, of als de char niet aan het einde maken we de string korter zodat we alleen nog het stuk ná de grootste char hebben,
            waarin we dan weer naar het grootste karakter dáárin kunnen zoeken.
            als we deze beiden hebben kunnen we ze samenvoegen en optellen bij het totaal aantal jolt. */
            for (int i = 0; i < 200; i++)
            {
                char max = char.Parse(inputJoltage[i].Max().ToString());
                Console.WriteLine(max);
                int location = inputJoltage[i].IndexOf(max);
                // Console.WriteLine(location);
                if (location < 99)
                {
                    Console.WriteLine(inputJoltage[i].Substring(location + 1));
                    char max2 = char.Parse(inputJoltage[i].Substring(location + 1).Max().ToString());
                    int amogus = Convert.ToInt32(string.Format("{0}{1}", max, max2));
                    Console.WriteLine($"max capaciteit: {amogus}");
                    totalOutput += amogus;
                }
                else
                {
                    char max1 = char.Parse(inputJoltage[i][..99].Max().ToString());
                    Console.WriteLine(max1);
                    // Console.WriteLine(location2);
                    Console.WriteLine(inputJoltage[i].Substring(location + 1));
                    char max2 = char.Parse(inputJoltage[i].Substring(location).Max().ToString());
                    int amogus = Convert.ToInt32(string.Format("{0}{1}", max1, max2));
                    Console.WriteLine($"max capaciteit: {amogus}");
                    totalOutput += amogus;
                }
            }
            Console.WriteLine(totalOutput);
        }
    }
}