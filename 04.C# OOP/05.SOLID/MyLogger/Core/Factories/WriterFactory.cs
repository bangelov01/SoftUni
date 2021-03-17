using MyLogger.Core.Factories.Contracts;
using MyLogger.Enums;
using MyLogger.Layouts.Contracts;
using MyLogger.Loggers;
using MyLogger.Writers;
using MyLogger.Writers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Core.Factories
{
    public class WriterFactory : IWriterFactory
    {
        public IWriter CreateWriter(string type, ILayout layout, ErrorLevel error)
        {
            IWriter writer;

            switch (type)
            {
                case nameof(ConsoleWriter):
                    writer = new ConsoleWriter(layout, error);
                    break;
                case nameof(FileWriter):
                    writer = new FileWriter(layout, new LogFile(),error);
                    break;
                default:
                    throw new ArgumentException($"{type} is invalid Writer type!");
            }

            return writer;
        }
    }
}
