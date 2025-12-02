using System.Security.Claims;

namespace Dag1
{
    internal class Program

    {
        static int Rotation(string inputRotation, int currentPosition)
        {
            if (inputRotation.Contains("R"))
            {
                Console.Write("Rechts - ");
                int inputRotationInt = int.Parse(inputRotation.Substring(1));
                if (inputRotationInt>100) 
                {
                    inputRotationInt %= 100;
                }
                return clamp1(currentPosition += inputRotationInt);
                
            }
            else
            {
                Console.Write("Links - ");
                int inputRotationInt = int.Parse(inputRotation.Substring(1));
                if (inputRotationInt>-100)
                {
                    inputRotationInt %=100;
                }
                return clamp1(currentPosition -= inputRotationInt);
            }
        }


        static int clamp1(int input)
        {
            if (input>99)
            {
                return input-100;
            }
            else if (input<0)
            {
                return 100 + input;   
            }
            else return input;
        }

        static void Main(string[] args)
        {
            string readFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag1/input.txt");
            string [] inputRotation = readFile.Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
            int defaultPosition = 50;
            int currentPosition = defaultPosition;
            int zeroCount = 0;

            for (int i=0; i<(inputRotation.Length-1); i++)
            {
                currentPosition = Rotation(inputRotation[i], currentPosition);
                Console.WriteLine(currentPosition);
                if (currentPosition==0){zeroCount++;}
            }

            Console.WriteLine(zeroCount);
        }
    }
}