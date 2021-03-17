using MyLogger.Core.Contracts;
using MyLogger.Core.Factories.Contracts;
using MyLogger.Enums;
using MyLogger.Layouts.Contracts;
using MyLogger.Loggers;
using MyLogger.Loggers.Contracts;
using MyLogger.Writers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Core
{
    public class Engine : IEngine
    {
        private readonly Dictionary<string, ILayout> layoutsByType;
        private readonly IWriterFactory writerFactory;
        private ILogger logger;

        public Engine(Dictionary<string, ILayout> layoutsByType, IWriterFactory writerFactory)
        {
            this.layoutsByType = layoutsByType;
            this.writerFactory = writerFactory;
        }

        public void Run()
        {
            int incomingLayouts = int.Parse(Console.ReadLine());

            IWriter[] writers = ReadWriters(incomingLayouts, layoutsByType, writerFactory);

            this.logger = new Log(writers);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split("|");

                ErrorLevel level = Enum.Parse<ErrorLevel>(parts[0], true);
                string date = parts[1];
                string message = parts[2];

                this.ProcessCommand(level, date, message);

            }

            Console.WriteLine(logger);
        }

        private void ProcessCommand(ErrorLevel level, string date, string message)
        {
            switch (level)
            {
                case ErrorLevel.Info:
                    logger.Info(date, message);
                    break;
                case ErrorLevel.Warning:
                    logger.Warning(date, message);
                    break;
                case ErrorLevel.Error:
                    logger.Error(date, message);
                    break;
                case ErrorLevel.Critical:
                    logger.Critical(date, message);
                    break;
                case ErrorLevel.Fatal:
                    logger.Fatal(date, message);
                    break;
            }
        }

        private IWriter[] ReadWriters(int times, Dictionary<string, ILayout> layoutsByType, IWriterFactory writerFactory)
        {
            IWriter[] writers = new IWriter[times];

            for (int i = 0; i < times; i++)
            {
                string[] writerParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string writerType = writerParts[0];
                string layoutType = writerParts[1];
                ErrorLevel errorLevel = writerParts.Length == 3 ? Enum.Parse<ErrorLevel>(writerParts[2], true) : ErrorLevel.Info;

                IWriter writer = writerFactory.CreateWriter(writerType, layoutsByType[layoutType], errorLevel);

                writers[i] = writer;
            }

            return writers;
        }
    }
}
