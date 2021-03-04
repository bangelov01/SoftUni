using _05.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
