using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class HarbourTile : ISeaTile
    {
        public Coordinate Coordinate { get; private set; }

        public EnumTileType Resource { get; private set; }

        public HarbourTile(Coordinate coordinate, EnumTileType resource)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
    }
}
