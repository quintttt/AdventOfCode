using System.Text.RegularExpressions;
namespace Dag6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag6/input.txt");
            string[] inputMathArray = readFromFile.Split("\n");


            ulong count = 0;
            ulong[] mathNumberArray0 = Array.ConvertAll(inputMathArray[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries), ulong.Parse);
            ulong[] mathNumberArray1 = Array.ConvertAll(inputMathArray[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries), ulong.Parse);
            ulong[] mathNumberArray2 = Array.ConvertAll(inputMathArray[2].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries), ulong.Parse);
            ulong[] mathNumberArray3 = Array.ConvertAll(inputMathArray[3].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries), ulong.Parse);
            char[] mathNumberArray4 = Array.ConvertAll(inputMathArray[4].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries), char.Parse);

            for (int i = 0; i < mathNumberArray0.Length; i++)
            {
                if (mathNumberArray4[i] == '+')
                {
                    Console.WriteLine(mathNumberArray0[i] + mathNumberArray1[i] + mathNumberArray2[i] + mathNumberArray3[i]);
                    count += mathNumberArray0[i] + mathNumberArray1[i] + mathNumberArray2[i] + mathNumberArray3[i];
                }
                if (mathNumberArray4[i] == '*')
                {
                    Console.WriteLine(mathNumberArray0[i] * mathNumberArray1[i] * mathNumberArray2[i] * mathNumberArray3[i]);
                    count += mathNumberArray0[i] * mathNumberArray1[i] * mathNumberArray2[i] * mathNumberArray3[i];
                }
            }
            Console.WriteLine(count);

            /*foreach (string mathNumber in mathNumberArray0)
            {
                Console.WriteLine(mathNumber);
            }
            foreach (string mathNumber in mathNumberArray1)
            {
                Console.WriteLine(mathNumber);
            }
            foreach (string mathNumber in mathNumberArray2)
            {
                Console.WriteLine(mathNumber);
            }
            foreach (string mathNumber in mathNumberArray3)
            {
                Console.Write(mathNumber + ' ');
            }*/

        }
    }
}