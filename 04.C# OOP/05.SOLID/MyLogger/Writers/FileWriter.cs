using MyLogger.Enums;
using MyLogger.Layouts.Contracts;
using MyLogger.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Writers
{
    public class FileWriter : Writer
    {
        private ILogFile logFile;
        public FileWriter(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Write(string date, ErrorLevel level, string message)
        {
            string content = string.Format(layout.Template, date, level, message + Environment.NewLine);

            WriteToFile(content);
        }

        private void WriteToFile(string content)
        {
            logFile.Write(content);
        }
    }
}
