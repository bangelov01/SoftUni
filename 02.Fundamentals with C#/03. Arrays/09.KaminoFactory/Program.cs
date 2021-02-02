using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //int numberOfSequence = int.Parse(Console.ReadLine());

            //string sequence = Console.ReadLine();
            //int bestLength = 1;
            //int bestStartIndex = 0;
            //int bestSequenceSum = 0;
            //int bestSequenceIndex = 0;
            //int seqCounter = 0;
            //int[] saveSequence = new int[numberOfSequence];

            //while (sequence != "Clone them!")
            //{
            //    int[] currentSquence = sequence.Split("!", StringSplitOptions.RemoveEmptyEntries)
            //        .Select(int.Parse)
            //        .ToArray();
            //    seqCounter++;

            //    int length = 1;
            //    int bestCurrentLength = 1;
            //    int startIndex = 0;
            //    int currentSequenceSum = 0;

            //    for (int i = 0; i < currentSquence.Length - 1; i++)
            //    {
            //        if (currentSquence[i] == currentSquence[i+1])
            //        {
            //            length++;
            //        }
            //        else
            //        {
            //            length = 1;
            //        }
            //        if (length > bestCurrentLength)
            //        {
            //            bestCurrentLength = length;
            //            startIndex = i;
            //        }
            //        currentSequenceSum += currentSquence[i];
            //    }
            //    currentSequenceSum += currentSquence[numberOfSequence - 1];

            //    if (bestCurrentLength > bestLength)
            //    {
            //        bestLength = bestCurrentLength;
            //        bestStartIndex = startIndex;
            //        bestSequenceSum = currentSequenceSum;
            //        bestSequenceIndex = seqCounter;
            //        saveSequence = currentSquence.ToArray();
            //    }
            //    else if (bestCurrentLength == bestLength)
            //    {
            //        if (startIndex < bestStartIndex)
            //        {
            //            bestLength = bestCurrentLength;
            //            bestStartIndex = startIndex;
            //            bestSequenceSum = currentSequenceSum;
            //            bestSequenceIndex = seqCounter;
            //            saveSequence = currentSquence.ToArray();
            //        }
            //        else if (startIndex == bestStartIndex)
            //        {
            //            if (currentSequenceSum > bestSequenceSum)
            //            {
            //                bestLength = bestCurrentLength;
            //                bestStartIndex = startIndex;
            //                bestSequenceSum = currentSequenceSum;
            //                bestSequenceIndex = seqCounter;
            //                saveSequence = currentSquence.ToArray();
            //            }
            //        }
            //    }

            //    sequence = Console.ReadLine();
            //}
            //Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.\r\n" +
            //    $"{string.Join(' ', saveSequence)}");

            //Kamino Factory second solution.

            int size = int.Parse(Console.ReadLine());

            string input = string.Empty;
            int counter = 0;
            int bestCount = 0;
            int bestBeginIndex = 0;
            int bestSum = 0;
            string bestSequence = "";
            int bestCounter = 0;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                string sequence = input.Replace("!", "");
                string[] dnaParts = sequence.Split("0", StringSplitOptions.RemoveEmptyEntries);
                counter++;


                int count = 0;
                int sum = 0;
                string bestSubSequence = "";

                foreach (string dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count)
                    {
                        count = dnaPart.Length;
                        bestSubSequence = dnaPart;
                    }
                    sum += dnaPart.Length;
                }

                int beginIndex = sequence.IndexOf(bestSubSequence);

                if (count > bestCount ||
                    (count == bestCount && beginIndex < bestBeginIndex) ||
                    (count == bestCount && beginIndex == bestBeginIndex && sum > bestSum) ||
                    counter == 1)
                {
                    bestCount = count;
                    bestSequence = sequence;
                    bestBeginIndex = beginIndex;
                    bestSum = sum;
                    bestCounter = counter;
                }
            }

            char[] result = bestSequence.ToCharArray();

            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ", result)}");
        }
    }
}
