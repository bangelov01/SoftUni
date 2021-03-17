using MyLogger.Enums;
using MyLogger.Layouts.Contracts;
using MyLogger.Writers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Core.Factories.Contracts
{
    public interface IWriterFactory
    {
        IWriter CreateWriter(string type, ILayout layout, ErrorLevel error);
    }
}
