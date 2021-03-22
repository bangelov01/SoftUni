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
    public class JsonLayoutTests
    {
        [Test]
        public void When_JsonLayout_is_Initiated_TemplateShouldBeSet()
        {
            ILayout jsonLayout = new JsonLayout();
            StringBuilder template = new StringBuilder();
            template.AppendLine(@"""log"": {{");
            template.AppendLine(@"   ""date"": ""{0}"",");
            template.AppendLine(@"   ""level"": ""{1}"",");
            template.AppendLine(@"   ""message"": ""{2}""");
            template.AppendLine("}},");

            Assert.AreEqual(jsonLayout.Template, template.ToString());
        }
    }
}
