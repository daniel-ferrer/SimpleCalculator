using System.Text.RegularExpressions;

namespace SimpleCalculator
{
    public class InputValidator
    {
        public static bool IsValidInput(string expression)
        {
            string pattern = @"^[\d+\-*/() \t]+$";
            if(!Regex.IsMatch(expression, pattern))
                return false;

            int openParenCount = 0;
            foreach(char c in expression)
            {
                if (c == '(')
                    openParenCount++;
                else if (c == ')')
                {
                    if(openParenCount == 0) 
                        return false;
                    openParenCount--;
                }
            }

            return openParenCount == 0;
        }
    }
}
