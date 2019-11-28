using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class HarbourTileType : TileType
    {
        public HarbourTileType(EnumType type) : base(type)
        {
            TypeSort = EnumTypeSort.Harbour;
        }

    }
}
