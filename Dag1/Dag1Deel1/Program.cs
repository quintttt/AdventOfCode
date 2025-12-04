namespace Dag1
{
    internal class Program

    {
        static int Rotation(string inputRotation, int currentPosition)
        {
            int inputRotationInt = int.Parse(inputRotation[1..]);
            char rotationDirection = inputRotation[0];
            switch (rotationDirection)
            {
                case 'R':
                    if (inputRotationInt > 100) { inputRotationInt %= 100; }
                    return ClampRotation(currentPosition += inputRotationInt);
                case 'L':
                    if (inputRotationInt > -100) { inputRotationInt %= 100; }
                    return ClampRotation(currentPosition -= inputRotationInt);
                default:
                    Console.WriteLine($"{inputRotation} - Geen geldige richting aangegeven.");
                    return 1;
            }
        }

        static int ClampRotation(int inputRotationInt)
        {
            if (inputRotationInt > 99) { return inputRotationInt - 100; }
            else if (inputRotationInt < 0) { return 100 + inputRotationInt; }
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
        }
    }
}