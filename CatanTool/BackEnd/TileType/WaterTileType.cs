using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class WaterTileType : TileType
    {
        public WaterTileType(EnumType type) : base(type)
        {
            TypeSort = EnumCoordinateType.Sea;
        }
    }
}
