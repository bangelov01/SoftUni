using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public override string ToString()
        {
            return $"{Item.GetType()}: {Item}";
        }
    }
}
