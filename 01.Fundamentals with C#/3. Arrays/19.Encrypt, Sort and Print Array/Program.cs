using System;

namespace _19.Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] saveArray = new int[n];

            for (int i = 0; i < saveArray.Length; i++)
            {
                string word = Console.ReadLine();
                int sumVowels = 0;
                int sumCons = 0;

                foreach (char item in word)
                {
                    if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u'
                        || item == 'A' || item == 'E' || item == 'I' || item == 'O' || item == 'U')
                    {
                        sumVowels += Convert.ToInt32(item) * word.Length;
                    }
                    else
                    {
                        sumCons += Convert.ToInt32(item) / word.Length;
                    }
                }
                int charSum = sumCons + sumVowels;

                saveArray[i] = charSum;
            }

            Array.Sort(saveArray);

            foreach (int value in saveArray)
            {
                Console.WriteLine(value);
            }
        }
    }
}
