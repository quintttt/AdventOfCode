namespace Dag1
{
    internal class Program

    {
        static int Rotation(string inputRotation, int currentPosition)
        {
            int inputRotationInt = int.Parse(inputRotation.Substring(1));
            if (inputRotation.Contains("R"))
            {
                if (inputRotationInt > 100) { inputRotationInt %= 100; }
                return clampRotation(currentPosition += inputRotationInt);

            }
            else
            {
                if (inputRotationInt > -100) { inputRotationInt %= 100; }
                return clampRotation(currentPosition -= inputRotationInt);
            }
        }

        static int clampRotation(int inputRotationInt)
        {
            if (inputRotationInt > 99) { return inputRotationInt - 100; }
            else if (inputRotationInt < 0) { return 100 + inputRotationInt; }
            else return inputRotationInt;
        }

        static void Main(string[] args)
        {
            string readFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag1/input.txt");
            string[] inputRotation = readFile.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int currentPosition = 50;
            int zeroCount = 0;

            for (int i = 0; i < (inputRotation.Length - 1); i++)
            {
                currentPosition = Rotation(inputRotation[i], currentPosition);
                if (currentPosition == 0) { zeroCount++; }
            }

            Console.WriteLine($"Aantal nullen: {zeroCount}");
        }
    }
}