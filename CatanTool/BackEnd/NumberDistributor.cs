using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class NumberDistributor
    {
        public List<int> numberlist;
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
        public int GetNumber(List<ITile> AdjacentsTiles)
        {
            foreach (LandTile landTile in AdjacentsTiles)
            {
                if (landTile.Value != 8 && landTile.Value != 6)
                {
                    
                    
                }
            }
        }
    }
}
