using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class LandTile : ITile
    {
        public Coordinate Coordinate { get; private set; }
        public EnumLandTileType Resource { get; private set; }
        public int Value { get; private set; }

        public LandTile(Coordinate coordinate, EnumLandTileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
            Value = value;
        }
    }
}
