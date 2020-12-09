using System;

namespace _10._WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] commandArr = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArr[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(commandArr[1]);
                    string insString = commandArr[2];

                    if (index >= 0 && index <= stops.Length - 1)
                    {
                        stops = stops.Insert(index, insString);
                    }
                    Console.WriteLine(stops);
                }
                else if (action == "Remove Stop")
                {
                    int index = int.Parse(commandArr[1]);
                    int endIndex = int.Parse(commandArr[2]);

                    if ((index >= 0 && index <= stops.Length - 1) && (endIndex >= 0 && endIndex <= stops.Length - 1))
                    {
                        int count = endIndex - index + 1;
                        //if ((index + count) < stops.Length)
                        //{
                        //    count += 1;
                        //}
                        stops = stops.Remove(index, count);
                    }
                    Console.WriteLine(stops);
                }
                else if (action == "Switch")

                {
                    string oldString = commandArr[1];
                    string newString = commandArr[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                    Console.WriteLine(stops);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
