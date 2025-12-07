namespace Dag6
{
    internal class Program
    {

        static ulong ExpressionParser(string mathExpression)
        {
            ulong[] mathNumbers = Array.ConvertAll(mathExpression.Split('+', '*'), ulong.Parse);
            ulong mathResult = mathNumbers[0];
            for (int i = 1; i < mathNumbers.Length; i++)
            {
                if (mathExpression.Contains('+')) { mathResult += mathNumbers[i]; }
                if (mathExpression.Contains('*')) { mathResult *= mathNumbers[i]; }
            }
            return mathResult;
        }

        static void Main(string[] args)
        {
            string readFromFile = File.ReadAllText("/home/quinn/Documents/Visual Studio Code/AdventOfCode/Dag6/input.txt");
            string[] inputMathArray = readFromFile.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            int[] intMathNumberArray = Array.ConvertAll(inputMathArray[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

            int i = 0;
            int j = 0;
            ulong totalCount = 0;
            char mathOperator = ' ';
            string mathExpression;

            foreach (int mathColumn in intMathNumberArray)
            {
                j = 0;
                mathExpression = "";
                
                Dictionary<int, ulong> mathNumbers = new Dictionary<int, ulong>();
                foreach (string inputMathString in inputMathArray)
                {
                    if (!inputMathString.Contains('+') && !inputMathString.Contains('*'))
                    {
                        ulong[] mathNumberArray = Array.ConvertAll(inputMathArray[j].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries), ulong.Parse);
                        mathNumbers.Add(j, mathNumberArray[i]);
                        if (j < (inputMathArray.Length - 2)) { j++; }
                    }
                    else if (inputMathString.Contains('+') || inputMathString.Contains('*'))
                    {
                        char[] mathOperatorArray = Array.ConvertAll(inputMathString.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries), char.Parse);
                        mathOperator = mathOperatorArray[i];
                    }
                }
                foreach (var mathNumber in mathNumbers)
                {
                    mathExpression += mathNumber.Value;
                    if (mathNumber.Key < mathNumbers.Count - 1) { mathExpression += mathOperator; }
                }
                totalCount += ExpressionParser(mathExpression);
                i++;
            }
            Console.WriteLine(totalCount);
        }
    }
}