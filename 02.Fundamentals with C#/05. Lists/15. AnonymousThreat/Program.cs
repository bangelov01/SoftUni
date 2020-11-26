using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
            List<string> tempList = new List<string>();
            StringBuilder saveConc = new StringBuilder();
            int counter = 0;

            for (int i = 0; i < partitions; i++)
            {
                if (i == (partitions - 1) && remain != 0)
                {
                    int startIndex = saveConc.Length;
                    string tempString = currString.Substring(startIndex);
                    tempList.Add(tempString);
                    break;
                }

                for (int j = 0; j < partLength; j++)
                {
                    concate.Append(currString[counter]);
                    counter++;
                }
                tempList.Add(concate.ToString());
                saveConc.Append(concate);
                concate.Clear();
            }
            input.InsertRange(index, tempList);
        }
    }
}

