namespace Dag1
{
    internal class Program

    {

        static int clicks = 0;
        static int Rotation(string inputRotation, int currentPosition)
        {
            if (inputRotation.Contains("R"))
            {
                int inputRotationInt = int.Parse(inputRotation.Substring(1));
                if (inputRotationInt>100) 
                {
                    clicks += (inputRotationInt-(inputRotationInt%100))/100;
                    inputRotationInt %= 100;
                }
                return clampRotation(currentPosition += inputRotationInt);
                
            }
            else
            {
                int inputRotationInt = int.Parse(inputRotation.Substring(1));
                if (inputRotationInt>-100)
                {
                    clicks += (inputRotationInt-(inputRotationInt%100))/100;
                    inputRotationInt %=100;
                }
                return clampRotation(currentPosition -= inputRotationInt);
            }
        }


        static int clampRotation(int inputRotationInt)
        {
            if (inputRotationInt>99)
            {
                clicks++;
                return inputRotationInt-100;
            }
            else if (inputRotationInt<0)
            {
                clicks++;
                return 100 + inputRotationInt;   
            }
            else return inputRotationInt;
        }

        static void Main(string[] args)
        {
            string readFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag1/input.txt");
            string [] inputRotation = readFile.Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
            int defaultPosition = 50;
            int currentPosition = defaultPosition;
            int zeroCount = 0;

            string[] inputRotationTest = {"L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"};

            for (int i=0; i<(inputRotation.Length-1); i++)
            {
                currentPosition = Rotation(inputRotation[i], currentPosition);
                if (currentPosition==0){zeroCount++;}
            }

            Console.WriteLine($"Aantal nullen: {zeroCount}");
            Console.WriteLine($"Aantal clicks: {clicks}");
        }
    }
}