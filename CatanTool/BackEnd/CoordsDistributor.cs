using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BackEnd;

namespace BackEnd
{
    public class CoordsDistributor
    {
        EnumMapType Type;
        public List<Coordinate> coords;

        public CoordsDistributor(EnumMapType type)
        {
            Type = type;
            coords = new List<Coordinate>();
            //FIX DIT
            coords.Add(new Coordinate(1,0));coords.Add(new Coordinate(2,0)); coords.Add(new Coordinate(3,0)); coords.Add(new Coordinate(4, 0));
        }
        public int GetOneRandomCoordinate()
        {
            return 1;
        }





    }
}
