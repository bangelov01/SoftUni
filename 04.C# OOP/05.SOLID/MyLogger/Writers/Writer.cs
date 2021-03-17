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

        protected Writer(ILayout layout, ErrorLevel error) : this(layout)
        {
            ErrorLevel = error;
        }

        public ErrorLevel ErrorLevel { get; private set; }

        protected int MessagesCount { get; set; }
        public abstract void Write(string date, ErrorLevel level, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ErrorLevel}, Messages appended: {MessagesCount}";
        }
    }
}
