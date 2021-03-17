using MyLogger.Loggers;
using MyLogger.Layouts;
using MyLogger.Layouts.Contracts;
using MyLogger.Loggers.Contracts;
using MyLogger.Writers;
using MyLogger.Writers.Contracts;
using System;
using MyLogger.Enums;
using System.Collections.Generic;
using MyLogger.Core.Factories.Contracts;
using MyLogger.Core.Factories;
using MyLogger.Core.Contracts;
using MyLogger.Core;

namespace MyLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ILayout> layoutsByType = new Dictionary<string, ILayout>()
            {
                {nameof(ConsoleLayout), new ConsoleLayout()},
                {nameof(XmlLayout), new XmlLayout()},
                {nameof(JsonLayout), new JsonLayout()}
            };

            IWriterFactory writerFactory = new WriterFactory();

            IEngine engine = new Engine(layoutsByType, writerFactory);

            engine.Run();
        }
    }
}
