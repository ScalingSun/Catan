using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class WaterTileType : TileType
    {
        public WaterTileType(Type type) : base(type)
        {
            TypeSort = TypeSort.Sea;
        }
    }
}
