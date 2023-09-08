namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var openingParantheses = new Stack<char>();
            var closingParantheses = new List<char>(parentheses);

            var paranthesesKVP = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }
            };

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '(' || parentheses[i] == '[' || parentheses[i] == '{')
                {
                    openingParantheses.Push(parentheses[i]);
                    closingParantheses.Remove(parentheses[i]);
                }
                else
                {
                    if (openingParantheses.Count > 0)
                    {
                        char currentParantheses = openingParantheses.Peek();

                        if (paranthesesKVP[currentParantheses] == parentheses[i])
                        {
                            openingParantheses.Pop();
                            closingParantheses.Remove(parentheses[i]);
                        }
                    }
                }
            }

            return !openingParantheses.Any() && !closingParantheses.Any();
        }
    }
}
