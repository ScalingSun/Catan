using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class HarbourTile : ISeaTile
    {
        public Coordinate Coordinate { get; private set; }

        public ITileType Resource { get; private set; }

        public HarbourTile(Coordinate coordinate, ITileType resource)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
    }
}
