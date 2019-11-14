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
                new Coordinate(0, 0, EnumTypeSort.Harbour), new Coordinate(0,1, EnumTypeSort.Sea), new Coordinate(0,2, EnumTypeSort.Harbour), new Coordinate(0,3, EnumTypeSort.Sea),
                new Coordinate(1,0, EnumTypeSort.Sea), new Coordinate(1, 1, EnumTypeSort.Land), new Coordinate(1, 2, EnumTypeSort.Land), new Coordinate(1,3, EnumTypeSort.Land), new Coordinate(1,4, EnumTypeSort.Harbour),
                new Coordinate(2,0, EnumTypeSort.Harbour), new Coordinate(2,1,EnumTypeSort.Land), new Coordinate(2,2,EnumTypeSort.Land),new Coordinate(2,3,EnumTypeSort.Land),new Coordinate(2,4,EnumTypeSort.Land),new Coordinate(2,5,EnumTypeSort.Sea),
                new Coordinate(3,0,EnumTypeSort.Sea), new Coordinate(3,1,EnumTypeSort.Land), new Coordinate(3,2,EnumTypeSort.Land),new Coordinate(3,3,EnumTypeSort.Land), new Coordinate(3,4,EnumTypeSort.Land), new Coordinate(3,5,EnumTypeSort.Land), new Coordinate(3,6,EnumTypeSort.Harbour),
                new Coordinate(4,1,EnumTypeSort.Harbour), new Coordinate(4,2,EnumTypeSort.Land), new Coordinate(4,3,EnumTypeSort.Land),new Coordinate(4,4,EnumTypeSort.Land), new Coordinate(4,5,EnumTypeSort.Land), new Coordinate(4,6,EnumTypeSort.Sea),
                new Coordinate(5,2,EnumTypeSort.Sea), new Coordinate(5,3,EnumTypeSort.Land), new Coordinate(5,4,EnumTypeSort.Land),new Coordinate(5,5,EnumTypeSort.Land), new Coordinate(5,6,EnumTypeSort.Harbour),
                new Coordinate(6,3,EnumTypeSort.Harbour), new Coordinate(6,4,EnumTypeSort.Sea), new Coordinate(6,5,EnumTypeSort.Harbour),new Coordinate(6,6,EnumTypeSort.Sea),
            });
        }

        public Coordinate GetOneRandomCoordinate(EnumTypeSort type)
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
        public List<Coordinate> GetListCoordinates(EnumTypeSort type)
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
