using System;

namespace _36._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOfLines = byte.Parse(Console.ReadLine());
            bool isNotBalanced = false;
            byte leftDuplCounter = 0;
            byte rightDuplCounter = 0;
            byte leftCount = 0;
            byte rightCount = 0;

            for (int i = 1; i <= numberOfLines; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    leftCount++;
                    leftDuplCounter++;
                    rightDuplCounter = 0;
                }
                else if (input == ")")
                {
                    rightCount++;
                    rightDuplCounter++;
                    leftDuplCounter = 0;
                }
                if (leftDuplCounter == 2 || rightDuplCounter == 2)
                {
                    isNotBalanced = true;
                }
            }
            if (isNotBalanced)
            {
                Console.WriteLine("UNBALANCED");
                return;
            }
            if (leftCount % 2 == 0 && rightCount % 2 == 0 || leftCount == 1 && rightCount == 1)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
