using System.Text.RegularExpressions;

partial class CalcThis
{
    public static void Main(string[] args)
    {
        string expression = string.Join("", args).Replace(" ", "");

        if (string.IsNullOrEmpty(expression))
        {
            Console.WriteLine("Invalid expression.");
            return;
        }
        string result = ParseAndEvaluate(expression);

        Console.WriteLine($"Result: {result}");
    }
    private static string ParseAndEvaluate(string expression)
    {
        Match match = MathExpressionRegex().Match(expression);
        if (!match.Success)
        {
            return "Invalid expression";
        }
        double operand1 = double.Parse(match.Groups[1].Value);
        double operand2 = double.Parse(match.Groups[3].Value);
        char operation = match.Groups[2].Value[0];

        if (operation == '/' && operand2 == 0)
        {
            return "Invalid expression";
        }

        return operation switch
        {
            '+' => (operand1 + operand2).ToString(),
            '-' => (operand1 - operand2).ToString(),
            '*' => (operand1 * operand2).ToString(),
            '/' => (operand1 / operand2).ToString(),
            _ => "Invalid expression"
        };
    }

    [GeneratedRegex(@"([-+]?\d*\.?\d+)([-+*/])([-+]?\d*\.?\d+)")]
    private static partial Regex MathExpressionRegex();

}

/*
OUTPUT:
    dotnet run 3 +4
    Result: 7

OUTPUT:
    dotnet run -3 + 4.4 =
    Result: 1.4

OUTPUT:
    dotnet run -3 /- 4  . 4=
    Result: 0.6818181818181818
*/