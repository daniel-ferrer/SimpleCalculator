namespace SimpleCalculator
{
    public class OperationParser
    {
        public static BinaryOperation ParseOperator(string operationToken)
        {
            return operationToken switch
            {
                "+" => BinaryOperation.Add,
                "-" => BinaryOperation.Subtract,
                "*" => BinaryOperation.Multiply,
                "/" => BinaryOperation.Divide,
                _ => throw new ArgumentException(ErrorMessages.InvalidOperator),
            };
        }
    }
}
