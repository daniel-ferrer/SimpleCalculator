namespace SimpleCalculator
{
    public class Tokenization
    {
        public static string[] Tokenize(string expression)
        {
            List<string> tokens = new();

            string[] splitByWhitespace = expression.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in splitByWhitespace)
            {
                string[] subTokens = System.Text.RegularExpressions.Regex.Split(token, @"(?<=[-+*/()])|(?=[-+*/()])");

                foreach (string subToken in subTokens)
                {
                    if(!string.IsNullOrWhiteSpace(subToken))
                        tokens.Add(subToken);
                }
            }

            return tokens.ToArray();
        }
    }
}
