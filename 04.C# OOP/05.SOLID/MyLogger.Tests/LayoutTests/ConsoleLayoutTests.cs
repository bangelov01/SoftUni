using MyLogger.Layouts;
using MyLogger.Layouts.Contracts;
using NUnit.Framework;
using System;

namespace MyLogger.Tests
{
    [TestFixture]
    public class ConsoleLayoutTests
    {
        [Test]

        public void When_ConsoleLayout_is_Created_Template_ShouldBeSet()
        {
            ILayout consoleLayout = new ConsoleLayout();
            string template = "{0} - {1} - {2}";

            Assert.AreEqual(consoleLayout.Template, template);
        }
    }
}
