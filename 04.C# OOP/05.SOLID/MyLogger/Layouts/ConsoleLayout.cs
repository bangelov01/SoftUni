using MyLogger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Layouts
{
    public class ConsoleLayout : ILayout
    {
        public string Template => "{0} - {1} - {2}";
    }
}
