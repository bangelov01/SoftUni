using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsArr = Console.ReadLine().Split(", ");

            Queue<string> songQueue = new Queue<string>(songsArr);

            bool isFinished = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (isFinished)
                {
                    break;
                }
                string command = input.Substring(0, 4);

                if (command.Contains("Play"))
                {
                    songQueue.Dequeue();
                    if (songQueue.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        isFinished = true;
                    }
                    continue;
                }
                else if (command.Contains("Add"))
                {
                    string song = input.Substring(4, input.Length - 4);

                    if (!songQueue.Contains(song))
                    {
                        songQueue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ",songQueue));
                }
            }
        }
    }
}
