using MyLogger.Loggers;
using MyLogger.Layouts;
using MyLogger.Layouts.Contracts;
using MyLogger.Loggers.Contracts;
using MyLogger.Writers;
using MyLogger.Writers.Contracts;
using System;

namespace MyLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            //ILayout consoleLayout = new ConsoleLayout();
            //IWriter consoleWriter = new ConsoleWriter(consoleLayout);
            //ILogger logger = new Log(consoleWriter);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            var simpleLayout = new ConsoleLayout();
            var consoleWriter = new ConsoleWriter(simpleLayout);

            var file = new LogFile();
            var fileWriter = new FileWriter(simpleLayout, file);

            var logger = new Log(consoleWriter, fileWriter);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");



        }
    }
}
