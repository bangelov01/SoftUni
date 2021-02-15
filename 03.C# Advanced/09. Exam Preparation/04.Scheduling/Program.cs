using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> taskStack = new Stack<int>(tasks);

            int[] threads = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> threadQueue = new Queue<int>(threads);

            int taskToBeKilled = int.Parse(Console.ReadLine());
            int killerThread = 0;

            while (true)
            {
                int task = taskStack.Peek();
                int thread = threadQueue.Peek();

                if (task == taskToBeKilled)
                {
                    killerThread = threadQueue.Peek();
                    break;
                }
                if (thread >= task)
                {
                    taskStack.Pop();
                    threadQueue.Dequeue();
                }
                else
                {
                    threadQueue.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {killerThread} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ",threadQueue));
        }
    }
}
