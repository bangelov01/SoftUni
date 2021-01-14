using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numsToOperateOn = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToEnqueue = numsToOperateOn[0];
            int elementsToDequeue = numsToOperateOn[1];
            int elementToLookFor = numsToOperateOn[2];

            Queue<int> intQueue = new Queue<int>(integers);

            int dequeued = 0;

            while (dequeued < elementsToDequeue)
            {
                intQueue.Dequeue();
                dequeued++;
            }

            if (intQueue.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
                return;
            }

            if (intQueue.Count > 0)
            {
                Console.WriteLine(intQueue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
