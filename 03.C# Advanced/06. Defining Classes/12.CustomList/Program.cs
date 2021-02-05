using System;
using System.Collections.Generic;

namespace _12.CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList myList = new CustomList();
            int[] nums = new int[5] {3, 4, 5, 2, 4};

            for (int i = 0; i < nums.Length; i++)
            {
                myList.Add(nums[i]);
            }

            myList.RemoveAt(4);

            var returnList = myList.Reverse();

            bool doesCont = myList.Contains(4);

            myList.Insert(1, 10);

            myList.Swap(2, 3);

            int num = myList.Find(x => x == 3);
        }
    }
}
