using System;
using System.Collections.Generic;
using System.Linq;

namespace _16._BalancedParantheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string parantheses = Console.ReadLine();
            List<char> paraList = new List<char>(parantheses);

            Stack<char> leftPara = new Stack<char>();

            for (int i = 0; i < parantheses.Length; i++)
            {
                if (parantheses[i] == '(' || parantheses[i] == '{' || parantheses[i] == '[')
                {
                    leftPara.Push(parantheses[i]);
                    paraList.Remove(parantheses[i]);
                }
                else
                {
                    if (leftPara.Count > 0)
                    {
                        char currPara = leftPara.Peek();
                        if ((currPara == '(' && parantheses[i] == ')') ||
                            (currPara == '[' && parantheses[i] == ']') ||
                            (currPara == '{' && parantheses[i] == '}'))
                        {
                            leftPara.Pop();
                            paraList.Remove(parantheses[i]);
                        }
                    }
                }
            }
            if (paraList.Count == 0 && leftPara.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
