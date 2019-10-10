using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class WaterTile : ISeaTile
    {
        public Coordinate Coordinate { get; private set; }

        public EnumTileType Resource { get; private set; }

        public WaterTile(Coordinate coordinate, EnumTileType resource)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
    }
}
