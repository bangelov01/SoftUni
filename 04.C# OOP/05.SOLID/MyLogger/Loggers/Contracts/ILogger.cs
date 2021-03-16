using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string date, string message);
        void Info(string date, string message);
    }
}
