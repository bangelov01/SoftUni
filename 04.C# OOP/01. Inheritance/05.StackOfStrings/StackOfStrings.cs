using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public void AddRange(params string[] input)
        {
            foreach (var item in input)
            {
                base.Push(item);
            }
        }
    }
}
