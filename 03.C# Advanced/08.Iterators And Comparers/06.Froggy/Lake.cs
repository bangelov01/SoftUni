using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _06.Froggy
{
    public class Lake : IEnumerable<int>
    {
        public List<int> StonesList { get; private set; }

        public Lake(List<int> stonesList)
        {
            StonesList = stonesList;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < StonesList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return StonesList[i];
                }
            }

            for (int j = StonesList.Count - 1; j > 0; j--)
            {
                if (j % 2 != 0)
                {
                    yield return StonesList[j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
