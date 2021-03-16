using MyLogger.Enums;
using MyLogger.Layouts.Contracts;
using MyLogger.Writers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Writers
{
    public abstract class Writer : IWriter
    {
        protected readonly ILayout layout;

        protected Writer(ILayout layout)
        {
            this.layout = layout;
        }

        public abstract void Write(string date, ErrorLevel level, string message);
    }
}
