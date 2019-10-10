using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            coords.AddRange(new List<Coordinate>
            {
                new Coordinate(1,1), new Coordinate(1,2), new Coordinate(1,3),new Coordinate(1,4),
                new Coordinate(2,1), new Coordinate(2,2), new Coordinate(2,3),new Coordinate(2,4), new Coordinate(2,5),
                new Coordinate(3,1), new Coordinate(3,2), new Coordinate(3,3),new Coordinate(3,4), new Coordinate(3,5), new Coordinate(3,6),
                new Coordinate(4,1), new Coordinate(4,2), new Coordinate(4,3),new Coordinate(4,4), new Coordinate(4,5), new Coordinate(4,6), new Coordinate(4,7),
                new Coordinate(5,1), new Coordinate(5,2), new Coordinate(5,3),new Coordinate(5,4), new Coordinate(5,5), new Coordinate(5,6),
                new Coordinate(6,1), new Coordinate(6,2), new Coordinate(6,3),new Coordinate(6,4), new Coordinate(6,5),
                new Coordinate(7,1), new Coordinate(7,2), new Coordinate(7,3),new Coordinate(7,4),
            });
        }
        public int GetOneRandomCoordinate()
        {
            return 1;
        }





    }
}
