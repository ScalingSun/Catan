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
                numberlist.Add(2);
                numberlist.Add(3);
                numberlist.Add(3);
                numberlist.Add(4);
                numberlist.Add(4);
                numberlist.Add(5);
                numberlist.Add(5);
                numberlist.Add(6);
                numberlist.Add(6);
                numberlist.Add(8);
                numberlist.Add(8);
                numberlist.Add(9);
                numberlist.Add(9);
                numberlist.Add(10);
                numberlist.Add(10);
                numberlist.Add(11);
                numberlist.Add(11);
                numberlist.Add(12);
            }
            shuffler.Shuffle(numberlist);
        }
        /// <summary>
        /// gets a number from the list, and removes it from further use.
        /// </summary>
        /// <returns></returns>
        public int GetNumber()
        {
            int ValueNumber = 0;
            foreach(int number in numberlist)
            {
                ValueNumber = number;
                numberlist.Remove(number);
                break;
            }
            return ValueNumber;
        }
        public int GetNumber(List<int> omitNumberList)
        {
            int ValueNumber = 0;
            foreach (int number in numberlist)
            {
                foreach (int omitNumber in omitNumberList)
                {
                    if (number != omitNumber)
                    {
                        ValueNumber = number;
                        numberlist.Remove(number);
                        return ValueNumber;
                    }
                }
            }
            return ValueNumber;
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

    }
}
