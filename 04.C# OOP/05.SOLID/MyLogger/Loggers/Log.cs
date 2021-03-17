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

        public void Info(string date, string message)
        {
            WriteAll(date, ErrorLevel.Info, message);
        }

        public void Warning(string date, string message)
        {
            WriteAll(date, ErrorLevel.Warning, message);
        }

        public void Error(string date, string message)
        {
            WriteAll(date, ErrorLevel.Error, message);
        }

        public void Critical(string date, string message)
        {
            WriteAll(date, ErrorLevel.Critical, message);
        }
        public void Fatal(string date, string message)
        {
            WriteAll(date, ErrorLevel.Fatal, message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.writers)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private void WriteAll(string date, ErrorLevel level, string message)
        {
            foreach (var writer in writers)
            {
                if (level >= writer.ErrorLevel)
                {
                    writer.Write(date, level, message);
                }
            }
        }
    }
}
