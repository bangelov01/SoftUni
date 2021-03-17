using MyLogger.Enums;
using MyLogger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Writers.Contracts
{
    public interface IWriter
    {
        ErrorLevel ErrorLevel { get; }
        void Write(string date, ErrorLevel level, string message);
    }
}
