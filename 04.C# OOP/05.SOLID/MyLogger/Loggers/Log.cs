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
        private readonly IWriter[] writers;

        public Log(params IWriter[] writers)
        {
            this.writers = writers;
        }

        public void Error(string date, string message)
        {
            WriteAll(date, ErrorLevel.Error, message);
        }

        public void Info(string date, string message)
        {
            WriteAll(date, ErrorLevel.Info, message);
        }

        private void WriteAll(string date, ErrorLevel level, string message)
        {
            foreach (var writer in writers)
            {
                writer.Write(date, level, message);
            }
        }
    }
}
