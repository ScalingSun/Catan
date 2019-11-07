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
            coords.AddRange(new List<Coordinate>
            {
                new Coordinate(1,1,EnumCoordinateType.Sea), new Coordinate(1,2,EnumCoordinateType.Harbour), new Coordinate(1,3,EnumCoordinateType.Sea),new Coordinate(1,4,EnumCoordinateType.Sea),
                new Coordinate(2,1,EnumCoordinateType.Harbour), new Coordinate(2,2,EnumCoordinateType.Land), new Coordinate(2,3,EnumCoordinateType.Land),new Coordinate(2,4,EnumCoordinateType.Land), new Coordinate(2,5,EnumCoordinateType.Harbour),
                new Coordinate(3,1,EnumCoordinateType.Sea), new Coordinate(3,2,EnumCoordinateType.Land), new Coordinate(3,3,EnumCoordinateType.Land),new Coordinate(3,4,EnumCoordinateType.Land), new Coordinate(3,5,EnumCoordinateType.Land), new Coordinate(3,6,EnumCoordinateType.Sea),
                new Coordinate(4,1,EnumCoordinateType.Harbour), new Coordinate(4,2,EnumCoordinateType.Land), new Coordinate(4,3,EnumCoordinateType.Land),new Coordinate(4,4,EnumCoordinateType.Land), new Coordinate(4,5,EnumCoordinateType.Land), new Coordinate(4,6,EnumCoordinateType.Land), new Coordinate(4,7,EnumCoordinateType.Harbour),
                new Coordinate(5,1,EnumCoordinateType.Sea), new Coordinate(5,2,EnumCoordinateType.Land), new Coordinate(5,3,EnumCoordinateType.Land),new Coordinate(5,4,EnumCoordinateType.Land), new Coordinate(5,5,EnumCoordinateType.Land), new Coordinate(5,6,EnumCoordinateType.Sea),
                new Coordinate(6,1,EnumCoordinateType.Harbour), new Coordinate(6,2,EnumCoordinateType.Land), new Coordinate(6,3,EnumCoordinateType.Land),new Coordinate(6,4,EnumCoordinateType.Land), new Coordinate(6,5,EnumCoordinateType.Harbour),
                new Coordinate(7,1,EnumCoordinateType.Sea), new Coordinate(7,2,EnumCoordinateType.Harbour), new Coordinate(7,3,EnumCoordinateType.Sea),new Coordinate(7,4,EnumCoordinateType.Harbour),
            });
        }
        /*public Coordinate GetOneRandomCoordinate()
        {
            Random random = new Random();
            Coordinate randomCoordinate = coords[random.Next(0, coords.Count-1)];
            coords.Remove(randomCoordinate);
            return randomCoordinate;
        }*/

        public Coordinate GetOneRandomCoordinate(EnumCoordinateType type)
        {
            Random random = new Random();
            int num = GetListCoordinates(type).Count - 1;
            Coordinate randomCoordinate = GetListCoordinates(type)[random.Next(0, num)];
            coords.Remove(randomCoordinate);
            return randomCoordinate;
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
