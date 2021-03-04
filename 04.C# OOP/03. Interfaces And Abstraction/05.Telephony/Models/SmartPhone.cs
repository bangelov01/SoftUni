using _05.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Telephony
{
    public class SmartPhone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
           return $"Calling... {number}";
        }
        public string Browse(string website)
        {
           return $"Browsing: {website}!";
        }
    }
}
