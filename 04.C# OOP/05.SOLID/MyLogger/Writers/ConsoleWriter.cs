﻿using MyLogger.Enums;
using MyLogger.Layouts.Contracts;
using MyLogger.Writers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Writers
{
    public class ConsoleWriter : Writer
    {
        public ConsoleWriter(ILayout layout) 
            : base(layout)
        {
        }

        public override void Write(string date, ErrorLevel level, string message)
        {
            string output = string.Format(layout.Template, date, level, message);

            WriteToConsole(output);
        }

        private void WriteToConsole(string output)
        {
            Console.WriteLine(output);
        }
    }
}
