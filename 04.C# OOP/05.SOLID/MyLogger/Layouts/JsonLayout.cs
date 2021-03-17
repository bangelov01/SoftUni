using MyLogger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Layouts
{
    class JsonLayout : ILayout
    {
        public string Template => GetTemplate();

        private string GetTemplate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"""log"": {{");
            sb.AppendLine(@"   ""date"": ""{0}"",");
            sb.AppendLine(@"   ""level"": ""{1}"",");
            sb.AppendLine(@"   ""message"": ""{2}""");
            sb.AppendLine("}},");
            return sb.ToString();
        }
    }
}
