using SimpleCalculator;

Console.WriteLine("Simple Calculator (Type 'exit' to quit)");

while (true)
{
    Console.WriteLine("Enter an expression (ex., 12 + 7): ");
    string? expression = Console.ReadLine();

    if (expression is null || expression.ToLower() == "exit")
        break;

    if (InputValidator.IsValidInput(expression))
    {
        var result = Calculator.Calculate(expression);

        result.Match(
            value => Console.WriteLine($"Result: {value}"),
            error => Console.WriteLine($"Error: {error}"));
    }
    else
        Console.WriteLine("Invalid input. Please enter a valid expression.");
}
