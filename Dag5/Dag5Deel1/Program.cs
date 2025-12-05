namespace Dag5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag5/input.txt");
            string[] inputIDfile = readFromFile.Split("\n");
            string[] idRangelist;
            idRangelist = new string[167];
            string[] idstring;
            idstring = new string[1000];

            int verscounter = 0;

            Array.Copy(inputIDfile, idRangelist, 167);
            Array.Copy(inputIDfile, 168, idstring, 0, 1000);

            ulong[] idulongarr;
            idulongarr = Array.ConvertAll(idstring, ulong.Parse);

            Array.Sort(idRangelist);
            bool isspoiled = false;
            foreach (ulong idulong in idulongarr)
            {
                isspoiled = true;
                foreach (string idRange in idRangelist)
                {
                    string[] idRangestartend = idRange.Split('-');
                    ulong[] idRangeStartend = Array.ConvertAll(idRangestartend, ulong.Parse);

                    if (idulong >= idRangeStartend[0] && idulong <= idRangeStartend[1])
                    {
                        Console.WriteLine($"{idulong} is tussen {idRangeStartend[0]} en {idRangeStartend[1]}: VERS");
                        if (isspoiled == true)
                        {
                            verscounter++;
                            isspoiled = false;
                        }
                    }
                }
            }
            Console.WriteLine(verscounter);
        }
    }
}