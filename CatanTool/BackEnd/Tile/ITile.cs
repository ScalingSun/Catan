using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public interface ITile
    {
        Coordinate Coordinate { get; }
        EnumLandTileType Resource { get; }
    }
}
