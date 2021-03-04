using System;
using System.Collections.Generic;
using System.Text;

namespace _07.BirthdayCelebrations.Interfaces
{
    public interface IBirthable
    {
        public string Name { get; }
        public DateTime Birthdate { get; }

    }
}
