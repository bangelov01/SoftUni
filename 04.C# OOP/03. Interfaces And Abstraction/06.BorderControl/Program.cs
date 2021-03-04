using _06.BorderControl.Interfaces;
using _06.BorderControl.Models;
using System;
using System.Collections.Generic;

namespace _06.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<IIdentifiable> ids = new List<IIdentifiable>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split();

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    IIdentifiable person = new Citizen(name, age, id);
                    ids.Add(person);
                }
                else
                {
                    string model = info[0];
                    string id = info[1];
                    IIdentifiable robot = new Robot(model, id);
                    ids.Add(robot);
                }
            }

            string idCheck = Console.ReadLine();

            foreach (var entity in ids)
            {
                if (entity.Id.EndsWith(idCheck))
                {
                    Console.WriteLine(entity.Id);
                }
            }
        }
    }
}
