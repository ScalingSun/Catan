using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public abstract class TileType : ITileType
    {
        public EnumType Type { get; private set; }
        public EnumCoordinateType TypeSort { get; protected set; }
        public TileType(EnumType type)
        {
            Type = type;
        }
    }
}
