using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class Shuffler
    {
        //totally didnt copy paste this from the web 
        private Random rng = new Random();

        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
