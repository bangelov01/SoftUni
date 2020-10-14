using System;
using System.Linq;

namespace _22.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split();

                if (commandArray[0] == "exchange")
                {
                    int index = int.Parse(commandArray[1]);

                    if (index >= 0 && index < initialArray.Length)
                    {
                        initialArray = ReturnReorganizedArray(initialArray, index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                }
                else if (commandArray[0] == "max" || commandArray[0] == "min")
                {
                    string minOrMax = commandArray[0].ToString();
                    string oddOrEven = commandArray[1].ToString();

                    Console.WriteLine(ReturnMaxOrMin(minOrMax, oddOrEven, initialArray));
                }
                else if (commandArray[0] == "first" || commandArray[0] == "last")
                {
                    int count = int.Parse(commandArray[1]);

                    if (count >= 0 && count <= initialArray.Length)
                    {
                        string position = commandArray[0].ToString();
                        string evenOrOdd = commandArray[2].ToString();

                        Console.WriteLine($"[{string.Join(", ", ReturnFirstOrLast(position, count, evenOrOdd, initialArray))}]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", initialArray)}]");

        }

        static int[] ReturnReorganizedArray(int[] initialArray, int index)
        {
            int[] subArrayOne = new int[1 + index];
            int[] subArrayTwo = new int[initialArray.Length - subArrayOne.Length];
            int[] returnArray = new int[initialArray.Length];
            Array.Copy(initialArray, 0, subArrayOne, 0, subArrayOne.Length);
            Array.Copy(initialArray, subArrayOne.Length, subArrayTwo, 0, subArrayTwo.Length);

            Array.Copy(subArrayTwo, 0, returnArray, 0, subArrayTwo.Length);
            Array.Copy(subArrayOne, 0, returnArray, subArrayTwo.Length, subArrayOne.Length);

            return returnArray;
        }

        static string ReturnMaxOrMin(string minOrMax, string oddOrEven, int[] initialArray)
        {
            if (minOrMax == "max")
            {
                if (oddOrEven == "even")
                {
                    return ReturnEvenOrOddForMax(0, initialArray);
                }
                else
                {

                    return ReturnEvenOrOddForMax(1, initialArray);
                }
            }
            else
            {
                if (oddOrEven == "even")
                {
                    return ReturnEvenOrOddForMin(0, initialArray);
                }
                else
                {

                    return ReturnEvenOrOddForMin(1, initialArray);
                }
            }
        }

        static int[] ReturnFirstOrLast(string position, int count, string evenOrOdd, int[] initialArray)
        {
            if (position == "first")
            {
                if (evenOrOdd == "even")
                {
                    return EvenOrOddForFirst(0, count, initialArray);
                }
                else
                {
                    return EvenOrOddForFirst(1, count, initialArray);
                }
            }
            else
            {
                if (evenOrOdd == "even")
                {
                    return EvenOrOddForLast(0, count, initialArray);
                }
                else
                {
                    return EvenOrOddForLast(1, count, initialArray);
                }
            }
        }

        static int[] EvenOrOddForFirst(int divideLeftover, int count, int[] initialArray)
        {
            int[] printArray = new int[count];
            int internalCount = 0;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] % 2 == divideLeftover && internalCount < count)
                {
                    printArray[internalCount] = initialArray[i];
                    internalCount++;
                }
            }
            if (internalCount >= count)
            {
                return printArray;
            }
            else
            {
                int[] holderArray = new int[internalCount];
                Array.Copy(printArray, holderArray, internalCount);
                return holderArray;
            }
        }

        static int[] EvenOrOddForLast(int divideLeftover, int count, int[] initialArray)
        {
            int[] resultArr = new int[count];
            int currCounter = 0;

            for (int i = initialArray.Length - 1; i >= 0; i--)
            {
                if (initialArray[i] % 2 == divideLeftover && currCounter < count)
                {
                    resultArr[currCounter] = initialArray[i];
                    currCounter++;
                }
            }

            if (currCounter >= count)
            {
                return resultArr.Reverse().ToArray();
            }
            else
            {
                int[] holderArray = new int[currCounter];
                Array.Copy(resultArr, holderArray, currCounter);
                return holderArray.Reverse().ToArray();
            }
        }

        static string ReturnEvenOrOddForMax(int divideLeftover, int[] initialArray)
        {
            int maxEven = int.MinValue;
            int saveIndex = 0;
            bool isFound = false;
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] % 2 == divideLeftover)
                {
                    if (initialArray[i] >= maxEven)
                    {
                        maxEven = initialArray[i];
                        saveIndex = i;
                        isFound = true;
                    }
                }
            }
            if (isFound)
            {
                return saveIndex.ToString();
            }
            else
            {
                return "No matches";
            }
        }

        static string ReturnEvenOrOddForMin(int divideLeftover, int[] initialArray)
        {
            int minEven = int.MaxValue;
            int saveIndex = 0;
            bool isFound = false;
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] % 2 == divideLeftover)
                {
                    if (initialArray[i] <= minEven)
                    {
                        minEven = initialArray[i];
                        saveIndex = i;
                        isFound = true;
                    }
                }
            }
            if (isFound)
            {
                return saveIndex.ToString();
            }
            else
            {
                return "No matches";
            }
        }
    }
}


