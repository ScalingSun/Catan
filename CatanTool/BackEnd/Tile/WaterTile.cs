using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class WaterTile : ISeaTile
    {
        public Coordinate Coordinate { get; private set; }

        public EnumLandTileType Resource { get; private set; }

        public WaterTile(Coordinate coordinate, EnumLandTileType resource)
        {
            Coordinate = coordinate;
            Resource = EnumLandTileType.Sea;
        }
    }
}
