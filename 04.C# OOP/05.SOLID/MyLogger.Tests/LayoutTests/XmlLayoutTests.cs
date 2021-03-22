using MyLogger.Layouts;
using MyLogger.Layouts.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Tests.LayoutTests
{
    [TestFixture]
    public class XmlLayoutTests
    {
        [Test]
        public void When_XmlLayout_Is_Initiated_Template_ShouldBeSet()
        {
            ILayout xmlLayout = new XmlLayout();
            StringBuilder template = new StringBuilder();
            template.AppendLine("<log>");
            template.AppendLine("   <date>{0}</date>");
            template.AppendLine("   <level>{1}</level>");
            template.AppendLine("   <message>{2}</message>");
            template.AppendLine("</log>");

            Assert.AreEqual(xmlLayout.Template, template.ToString());
            Assert.That(template.ToString(), Is.EqualTo(xmlLayout.Template));
        }
    }
}
