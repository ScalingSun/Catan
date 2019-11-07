using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class HarbourTileType : TileType
    {
        public HarbourTileType(Type type) : base(type)
        {
            TypeSort = TypeSort.Sea;
        }
    }
}
