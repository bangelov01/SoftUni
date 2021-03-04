using _06.BorderControl.Models;
using _07.BirthdayCelebrations.Interfaces;
using _07.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;

namespace _07.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<IBirthable> birthDates = new List<IBirthable>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (info[0] == "Citizen")
                {
                    string name = info[1];
                    int age = int.Parse(info[2]);
                    string id = info[3];
                    DateTime birthdate = DateTime.ParseExact(info[4], "dd/MM/yyyy", null);
                    IBirthable citizen = new Citizen(name, age, id, birthdate);
                    birthDates.Add(citizen);
                }
                else if (info[0] == "Pet")
                {
                    string name = info[1];
                    DateTime birthdate = DateTime.ParseExact(info[2], "dd/MM/yyyy",null);
                    IBirthable pet = new Pet(name,birthdate);
                    birthDates.Add(pet);
                }
            }

            int year = int.Parse(Console.ReadLine());

            foreach (var entity in birthDates)
            {
                if (entity.Birthdate.Year == year)
                {
                    Console.WriteLine(entity.Birthdate.ToString("dd/MM/yyyy"));
                }
            }
        }
    }
}
