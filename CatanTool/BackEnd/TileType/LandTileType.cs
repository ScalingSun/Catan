using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class LandTileType : TileType
    {
        public LandTileType(EnumType type) : base(type)
        {
            TypeSort = EnumTypeSort.Land;
        }
    }
}
