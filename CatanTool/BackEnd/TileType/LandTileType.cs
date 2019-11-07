using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class LandTileType : TileType
    {
        public LandTileType(Type type) : base(type)
        {
            TypeSort = TypeSort.Land;
        }
    }
}
