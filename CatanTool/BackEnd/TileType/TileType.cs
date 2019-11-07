using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public abstract class TileType : ITileType
    {
        public Type Type { get; private set; }
        public TypeSort TypeSort { get; protected set; }

        public TileType(Type type)
        {
            Type = type;
        }
    }
}
