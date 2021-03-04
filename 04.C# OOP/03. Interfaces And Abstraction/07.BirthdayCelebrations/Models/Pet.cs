using _07.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
    }
}
