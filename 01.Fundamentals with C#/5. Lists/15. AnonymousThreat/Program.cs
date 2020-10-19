using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15._AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] commandArr = command.Split();

                StringBuilder concate = new StringBuilder();

                string mainCommand = commandArr[0];

                if (mainCommand == "merge")
                {
                    short startIndex = short.Parse(commandArr[1]);
                    short endIndex = short.Parse(commandArr[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (startIndex > input.Count - 1)
                    {
                        startIndex = (short)(input.Count - 1);
                    }
                    if (endIndex > input.Count - 1)
                    {
                        endIndex = (short)(input.Count - 1);
                    }

                    int counter = 0;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        counter++;
                        string[] currString = input[i].Split().ToArray();

                        foreach (string item in currString)
                        {
                            concate.Append(item);
                        }
                    }
                    input.RemoveRange(startIndex, counter);
                    input.Insert(startIndex, concate.ToString());

                }
                else
                {
                    short index = short.Parse(commandArr[1]);
                    byte partitions = byte.Parse(commandArr[2]);

                    string currString = input[index];

                    input.RemoveAt(index);

                    ReturnManipultedArray(input, currString, index, partitions, concate);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }

        static void ReturnManipultedArray(List<string> input, string currString, short index, byte partitions, StringBuilder concate)
        {
            int partLength = currString.Length / partitions;
            int remain = currString.Length % partitions;
            int counterForPart = 0;
            int counterForInsert = 0;

            for (int i = 0; i <= currString.Length - remain; i++)
            {
                if (counterForPart == partLength)
                {
                    input.Insert(index + counterForInsert, concate.ToString());
                    concate.Clear();
                    counterForInsert++;
                    counterForPart = 0;
                    if (i >= currString.Length - remain)
                    {
                        break;
                    }
                    i--;
                    continue;
                }
                counterForPart++;

                if ((partitions - 1) == i && remain != 0)
                {
                    concate.Append(currString, i, currString.Length - i);
                    input.Insert(index + (partLength + remain), concate.ToString());
                    break;
                }  
                concate.Append(currString[i]);
            }
        }
    }
}

