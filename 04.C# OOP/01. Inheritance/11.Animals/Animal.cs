using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }
        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name}" +
                $"{Environment.NewLine}" +
                $"{Name} {Age} {Gender}";
        }
    }
}
