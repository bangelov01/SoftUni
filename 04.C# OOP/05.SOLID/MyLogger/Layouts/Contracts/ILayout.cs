using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Layouts.Contracts
{
    public interface ILayout 
    {
        string Template { get; }
    }
}
