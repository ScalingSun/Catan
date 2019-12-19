using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd
{
    public class NumberDistributor
    {
        public List<int> numberlist = new List<int>();
        public NumberDistributor(EnumMapType maptype)
        {
            Shuffler shuffler = new Shuffler();
            if (maptype == EnumMapType.small)
            {
                numberlist.Add(12);
                numberlist.Add(2);
                numberlist.Add(7);
                for (int i = 0; i < 2; i++)
                {
                    numberlist.Add(3);
                    numberlist.Add(4);
                    numberlist.Add(5);
                    numberlist.Add(6);
                    numberlist.Add(8);
                    numberlist.Add(9);
                    numberlist.Add(10);
                    numberlist.Add(11);
                }
            }
            if(maptype == EnumMapType.big)
            {
                for (int i = 0; i < 2; i++)
                {
                    numberlist.Add(2);
                    numberlist.Add(12);
                    numberlist.Add(7);
                }
                for (int i = 0; i < 3; i++)
                {
                    numberlist.Add(3);
                    numberlist.Add(4);
                    numberlist.Add(5);
                    numberlist.Add(6);
                    numberlist.Add(8);
                    numberlist.Add(9);
                    numberlist.Add(10);
                    numberlist.Add(11);
                }
            }
            shuffler.Shuffle(numberlist);
        }
        /// <summary>
        /// gets a number from the list, and removes it from further use.
        /// </summary>
        /// <returns></returns>
        public List<int> GetNumbers()
        {
            List<int> result = new List<int>();
            result.AddRange(numberlist);
            numberlist.Clear();
            return result;
        }
        /// <summary>
        /// get a list of numbers, and removes it from further use.
        /// </summary>
        /// <returns></returns>
        public List<int> GetListNumbersOf(List<int> numberList)
        {
            List<int> numberListResult = new List<int>();
            foreach (int numberListFromClass in numberlist.ToList())
            {
                foreach (int numberListFromParameter in numberList.ToList())
                {
                    if (numberListFromClass == numberListFromParameter)
                    {
                        numberListResult.Add(numberListFromClass);
                        numberlist.Remove(numberListFromClass);
                    }
                }
            }
            return numberListResult;
        }
        public int Get7FromList()
        {
            int result = 0;
            foreach(int number in numberlist.ToList())
            {
                if(number == 7)
                {
                    numberlist.Remove(number);
                    result = number;
                    break;
                }
            }
            return result;
        }

    }
}
