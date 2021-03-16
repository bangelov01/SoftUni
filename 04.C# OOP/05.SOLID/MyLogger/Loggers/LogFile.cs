using MyLogger.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Loggers
{
    public class LogFile : ILogFile
    {
        private const string filePath = "../../../log.txt";
        public int Size => File.ReadAllText(filePath)
            .Where(s => char.IsLetter(s))
            .Sum(s => s);

        public void Write(string content)
        {
            StringBuilder builder = new StringBuilder();

            File.AppendAllText(filePath, content);
        }
    }
}
