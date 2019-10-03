using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BackEnd
{
    public class CoordsDistributor
    {
        MapType Type;
        public List<int> coords;

        public CoordsDistributor(MapType type)
        {
            Type = type;
            coords = new List<int>();
            //DEZE HARDCODED COORDS MOETEN NOG NAAR GEKEKEN WORDEN. IVM VERANDERING VAN ALGORITME.
            //
            coords.Add(00);coords.Add(01); coords.Add(02); coords.Add(03); coords.Add(04); coords.Add(05); coords.Add(06); coords.Add(07); coords.Add(10); coords.Add(11); coords.Add(12); coords.Add(13); coords.Add(14); coords.Add(15); coords.Add(16); coords.Add(17); coords.Add(20); coords.Add(21); coords.Add(22); coords.Add(23); coords.Add(24); coords.Add(25); coords.Add(26); coords.Add(27); coords.Add(30); coords.Add(31); coords.Add(32); coords.Add(33); coords.Add(34); coords.Add(35); coords.Add(36); coords.Add(37); coords.Add(40); coords.Add(41); coords.Add(42); coords.Add(43); coords.Add(44); coords.Add(45); coords.Add(46); coords.Add(47); coords.Add(50); coords.Add(51); coords.Add(52); coords.Add(53); coords.Add(54); coords.Add(55); coords.Add(56); coords.Add(57); coords.Add(60); coords.Add(61); coords.Add(62); coords.Add(63); coords.Add(64); coords.Add(65); coords.Add(66); coords.Add(67); coords.Add(70); coords.Add(71); coords.Add(72); coords.Add(73); coords.Add(74); coords.Add(75); coords.Add(76); coords.Add(77);
        }
        public void AssignCoordsToTile(MapType maptype)
        {
            Shuffler shuffler = new Shuffler();
            int coord = 0;
            shuffler.Shuffle(coords);
            foreach (int number in coords)
            {
                coords.Remove(number);
                coord = number;
                break;
            }
        }





    }
}
