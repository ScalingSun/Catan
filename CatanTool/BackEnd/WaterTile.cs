using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class WaterTile : ISeaTile
    {
        public int Xaxis { get; private set; }
        public int Yaxis { get; private set; }

        public TileType Resource { get; private set; }
    }
}
