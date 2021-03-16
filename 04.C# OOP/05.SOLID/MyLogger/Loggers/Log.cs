using MyLogger.Enums;
using MyLogger.Loggers.Contracts;
using MyLogger.Writers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Loggers
{
    public class Log : ILogger
    {
        private readonly IWriter writer;

        public Log(IWriter writer)
        {
            this.writer = writer;
        }

        public void Error(string date, string message)
        {
            writer.Write(date, ErrorLevel.Error, message);
        }

        public void Info(string date, string message)
        {
            writer.Write(date, ErrorLevel.Info, message);
        }
    }
}
