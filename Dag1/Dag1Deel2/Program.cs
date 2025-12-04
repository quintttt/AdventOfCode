namespace Dag1
{
    internal class Program

    {
        static int clickCount = 0;
        static int Rotation(string inputRotation, int currentPosition)
        {
            int inputRotationInt = int.Parse(inputRotation[1..]);
            if (inputRotation.Contains('R'))
            {

                if (inputRotationInt > 100)
                {
                    clickCount += (inputRotationInt - (inputRotationInt % 100)) / 100;
                    inputRotationInt %= 100;
                }
                return ClampRotation(currentPosition += inputRotationInt);

            }
            else
            {
                if (inputRotationInt > -100)
                {
                    clickCount += (inputRotationInt - (inputRotationInt % 100)) / 100;
                    inputRotationInt %= 100;
                }
                return ClampRotation(currentPosition -= inputRotationInt);
            }
        }


        static int ClampRotation(int inputRotationInt)
        {
            if (inputRotationInt > 99 || inputRotationInt < 0)
            {
                clickCount++;
                if (inputRotationInt > 99) { return inputRotationInt - 100; }
                else { return 100 + inputRotationInt; }
            }
            else return inputRotationInt;
        }

        static void Main(string[] args)
        {
            string readFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag1/input.txt");
            string[] inputRotation = readFile.Trim().Split("\n");

            int currentPosition = 50;
            int zeroCount = 0;

            foreach (string inputRotationString in inputRotation)
            {
                currentPosition = Rotation(inputRotationString, currentPosition);
                if (currentPosition == 0) { zeroCount++; }
            }

            Console.WriteLine($"Aantal nullen: {zeroCount}");
            Console.WriteLine($"Aantal clicks: {clickCount}");
        }
    }
}