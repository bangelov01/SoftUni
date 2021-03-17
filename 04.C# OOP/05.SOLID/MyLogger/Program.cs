using MyLogger.Loggers;
using MyLogger.Layouts;
using MyLogger.Layouts.Contracts;
using MyLogger.Loggers.Contracts;
using MyLogger.Writers;
using MyLogger.Writers.Contracts;
using System;
using MyLogger.Enums;

namespace MyLogger
{
    class Program
    {
        static void Main(string[] args)
        {

            //Third implementation with report threshold - test.

            var jsonLayout = new XmlLayout();
            var writer = new FileWriter(jsonLayout, new LogFile(), ErrorLevel.Warning);

            var loggerFile = new Log(writer);

            loggerFile.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            loggerFile.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            loggerFile.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            loggerFile.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            loggerFile.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");


        }
    }
}
