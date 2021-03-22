using MyLogger.Enums;
using MyLogger.Layouts;
using MyLogger.Layouts.Contracts;
using MyLogger.Writers;
using MyLogger.Writers.Contracts;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace MyLogger.Tests.WriterTests
{
    [TestFixture]
    public class ConsoleWriterTests
    {
        private ILayout consoleLayout;
        private IWriter consoleWriter;
        private string date;
        private string message;
        private ErrorLevel error;

        [SetUp]
        public void SetUp()
        {
            consoleLayout = new ConsoleLayout();
            consoleWriter = new ConsoleWriter(consoleLayout);
            date = "3/26/2015 2:08:11 PM";
            message = "Error parsing JSON.";
            error = ErrorLevel.Error;
        }
        [Test]

        public void When_WritingToConsole_OutputLayout_Should_BeCorrectFormat()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                string expOut = string.Format(consoleLayout.Template, date, error, message + Environment.NewLine);

                consoleWriter.Write(date, error, message);

                Assert.AreEqual(expOut, sw.ToString());
            }
        }

        [Test]
        public void When_InitializingWriterWith_SpecificErrorMessage_ErrorMessage_Should_BeSet()
        {
            consoleWriter = new ConsoleWriter(consoleLayout, error);

            Assert.AreEqual(error, consoleWriter.ErrorLevel);
        }

        //Private field unit test with reflection. Not good practice.

        [Test]
        public void When_WritingMessage_MessageCount_ShouldIncrease()
        {
            int messageCount = 1;
            consoleWriter.Write(date, error, message);

            Type type = consoleWriter.GetType();

            PropertyInfo prop = type.GetProperty("MessagesCount", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(messageCount, prop.GetValue(consoleWriter,null));
        }
    }
}
