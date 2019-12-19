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
            if(type == EnumMapType.small)
            {
                coords.AddRange(new List<Coordinate>
            {
                new Coordinate(0, 0, EnumCoordinateType.Harbour), new Coordinate(0,1, EnumCoordinateType.Sea), new Coordinate(0,2, EnumCoordinateType.Harbour), new Coordinate(0,3, EnumCoordinateType.Sea),
                new Coordinate(1,0, EnumCoordinateType.Sea), new Coordinate(1, 1, EnumCoordinateType.Land), new Coordinate(1, 2, EnumCoordinateType.Land), new Coordinate(1,3, EnumCoordinateType.Land), new Coordinate(1,4, EnumCoordinateType.Harbour),
                new Coordinate(2,0, EnumCoordinateType.Harbour), new Coordinate(2,1,EnumCoordinateType.Land), new Coordinate(2,2,EnumCoordinateType.Land),new Coordinate(2,3,EnumCoordinateType.Land),new Coordinate(2,4,EnumCoordinateType.Land),new Coordinate(2,5,EnumCoordinateType.Sea),
                new Coordinate(3,0,EnumCoordinateType.Sea), new Coordinate(3,1,EnumCoordinateType.Land), new Coordinate(3,2,EnumCoordinateType.Land),new Coordinate(3,3,EnumCoordinateType.Land), new Coordinate(3,4,EnumCoordinateType.Land), new Coordinate(3,5,EnumCoordinateType.Land), new Coordinate(3,6,EnumCoordinateType.Harbour),
                new Coordinate(4,1,EnumCoordinateType.Harbour), new Coordinate(4,2,EnumCoordinateType.Land), new Coordinate(4,3,EnumCoordinateType.Land),new Coordinate(4,4,EnumCoordinateType.Land), new Coordinate(4,5,EnumCoordinateType.Land), new Coordinate(4,6,EnumCoordinateType.Sea),
                new Coordinate(5,2,EnumCoordinateType.Sea), new Coordinate(5,3,EnumCoordinateType.Land), new Coordinate(5,4,EnumCoordinateType.Land),new Coordinate(5,5,EnumCoordinateType.Land), new Coordinate(5,6,EnumCoordinateType.Harbour),
                new Coordinate(6,3,EnumCoordinateType.Harbour), new Coordinate(6,4,EnumCoordinateType.Sea), new Coordinate(6,5,EnumCoordinateType.Harbour),new Coordinate(6,6,EnumCoordinateType.Sea),
            });
            }
            if(type == EnumMapType.big)
            {
                coords.AddRange(new List<Coordinate>
            {
                new Coordinate(0, 0, EnumCoordinateType.Harbour), new Coordinate(0,1, EnumCoordinateType.Sea), new Coordinate(0,2, EnumCoordinateType.Harbour), new Coordinate(0,3, EnumCoordinateType.Sea),
                new Coordinate(1,0, EnumCoordinateType.Sea), new Coordinate(1, 1, EnumCoordinateType.Land), new Coordinate(1, 2, EnumCoordinateType.Land), new Coordinate(1,3, EnumCoordinateType.Land), new Coordinate(1,4, EnumCoordinateType.Harbour),
                new Coordinate(2,0, EnumCoordinateType.Harbour), new Coordinate(2,1,EnumCoordinateType.Land), new Coordinate(2,2,EnumCoordinateType.Land),new Coordinate(2,3,EnumCoordinateType.Land),new Coordinate(2,4,EnumCoordinateType.Land),new Coordinate(2,5,EnumCoordinateType.Sea),
                new Coordinate(3,0,EnumCoordinateType.Sea), new Coordinate(3,1,EnumCoordinateType.Land), new Coordinate(3,2,EnumCoordinateType.Land),new Coordinate(3,3,EnumCoordinateType.Land), new Coordinate(3,4,EnumCoordinateType.Land), new Coordinate(3,5,EnumCoordinateType.Land), new Coordinate(3,6,EnumCoordinateType.Harbour),
                new Coordinate(4,0,EnumCoordinateType.Harbour),new Coordinate(4,1,EnumCoordinateType.Land), new Coordinate(4,2,EnumCoordinateType.Land), new Coordinate(4,3,EnumCoordinateType.Land),new Coordinate(4,4,EnumCoordinateType.Land), new Coordinate(4,5,EnumCoordinateType.Land), new Coordinate(4,6,EnumCoordinateType.Land),new Coordinate(4,7,EnumCoordinateType.Sea),
                new Coordinate(5,1,EnumCoordinateType.Sea),new Coordinate(5,2,EnumCoordinateType.Land), new Coordinate(5,3,EnumCoordinateType.Land), new Coordinate(5,4,EnumCoordinateType.Land),new Coordinate(5,5,EnumCoordinateType.Land), new Coordinate(5,6,EnumCoordinateType.Land),new Coordinate(5,7,EnumCoordinateType.Harbour),
                new Coordinate(6,2,EnumCoordinateType.Harbour),new Coordinate(6,3,EnumCoordinateType.Land), new Coordinate(6,4,EnumCoordinateType.Land), new Coordinate(6,5,EnumCoordinateType.Land),new Coordinate(6,6,EnumCoordinateType.Land),new Coordinate(6,7,EnumCoordinateType.Sea),
                new Coordinate(7,3,EnumCoordinateType.Sea),new Coordinate(7,4,EnumCoordinateType.Land),new Coordinate(7,5,EnumCoordinateType.Land),new Coordinate(7,6,EnumCoordinateType.Land),new Coordinate(7,7,EnumCoordinateType.Harbour),
                new Coordinate(8,4,EnumCoordinateType.Harbour),new Coordinate(8,5,EnumCoordinateType.Sea),new Coordinate(8,6,EnumCoordinateType.Harbour),new Coordinate(8,7,EnumCoordinateType.Sea),
            });
            }
        }

        public Coordinate GetOneRandomCoordinate(EnumCoordinateType type)
        {
            Random random = new Random();

            Shuffler shuffle = new Shuffler();
            List<Coordinate> list = GetListCoordinates(type);
            Coordinate result = null;
            shuffle.Shuffle(list);
            foreach(Coordinate coord in list)
            {
                coords.Remove(coord);
                result = coord;
                break;
            }
            return result;
        }
        public List<Coordinate> GetListCoordinates(EnumCoordinateType type)
        {
            List<Coordinate> LandCoordinates = new List<Coordinate>();
            foreach (Coordinate coordinate in coords)
            {
                if (coordinate.CoordinateType == type)
                {
                    LandCoordinates.Add(coordinate);
                }
            }
            return LandCoordinates;
        }
    }
}
