using _01.SingletonPattern.Models;
using System;

namespace _01.SingletonPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));
            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db2.GetPopulation("Beijing"));
        }
    }
}
