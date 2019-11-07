using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class WaterTile : ISeaTile
    {
        public Coordinate Coordinate { get; private set; }

        public ITileType Resource { get; private set; }

        public WaterTile(Coordinate coordinate, ITileType resource)
        {
            Coordinate = coordinate;
            Resource = new WaterTileType(EnumType.Water);
        }
    }
}
