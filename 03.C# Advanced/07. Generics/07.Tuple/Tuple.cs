using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
 
    public class Tuple<T1,T2,T3>
    {
        public Tuple(T1 itemOne, T2 itemTwo, T3 itemThree)
        {
            ItemOne = itemOne;
            ItemTwo = itemTwo;
            ItemThree = itemThree;
        }

        public T1 ItemOne { get; set; }
        public T2 ItemTwo { get; set; }
        public T3 ItemThree { get; set; }

        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo} -> {ItemThree}";
        }
    }
}
