using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] names = ArrayCreator.Create(5, "Pesho");

            int[] nums = ArrayCreator.Create(10, 33);
        }
    }
}
