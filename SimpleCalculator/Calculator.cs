namespace SimpleCalculator
{
    public class Calculator
    {
        public static Result<double> Calculate(string expression)
        {
            try
            {
                var tokens = expression.Split(' ');
                if (tokens.Length != 3)
                    return Result<double>.Fail(ErrorMessages.InvalidExpression);

                double leftOperand = double.Parse(tokens[0]);
                BinaryOperation operation = OperationParser.ParseOperator(tokens[1]);
                double rightOperand = double.Parse(tokens[2]);

                switch (operation)
                {
                    case BinaryOperation.Add:
                        return Result<double>.Ok(leftOperand + rightOperand);
                    case BinaryOperation.Subtract:
                        return Result<double>.Ok(leftOperand - rightOperand);
                    case BinaryOperation.Multiply:
                        return Result<double>.Ok(leftOperand * rightOperand);
                    case BinaryOperation.Divide:
                        if (rightOperand == 0)
                            return Result<double>.Fail(ErrorMessages.DivisionByZero);
                        return Result<double>.Ok(leftOperand / rightOperand);
                    default:
                        return Result<double>.Fail(ErrorMessages.InvalidOperator);
                }
            }
            catch (Exception ex)
            {
                return Result<double>.Fail($"An error occurred: {ex.Message}");
            }
        }
    }
}
