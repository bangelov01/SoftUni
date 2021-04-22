using _04.PrototypePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PrototypePattern.Repositories
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches = new();

        public SandwichPrototype this[string name]
        {
            get => sandwiches[name];
            set => sandwiches.Add(name, value);
        }
    }
}
