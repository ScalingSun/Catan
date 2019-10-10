using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class LandTile : ITile
    {
        public int Xaxis { get; private set; }
            
        public int Yaxis { get; private set; }
        public EnumTileType Resource { get; private set; }
        public int Value { get; private set; }

        public LandTile(int xaxis, int yaxis, EnumTileType resource, int value)
        {
            Xaxis = xaxis;
            Yaxis = yaxis;
            Resource = resource;
            Value = value;
        }
    }
}
