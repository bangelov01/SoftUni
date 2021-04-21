using _01.SingletonPattern.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SingletonPattern.Models
{
    public sealed class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer instance;
        private static readonly object padLock = new object();
        private Dictionary<string, int> capitals;

        private SingletonDataContainer()
        {
            capitals = new Dictionary<string, int>();

            var elements = File.ReadAllText("../../../Capitals.txt");
            var elementsArr = elements.Split(new string[] {" ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < elementsArr.Length; i+=2)
            {
                capitals.Add(elementsArr[i], int.Parse(elementsArr[i + 1]));
            }
        }

        public static SingletonDataContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padLock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDataContainer();
                        }
                    }
                }
                return instance;
            }
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
