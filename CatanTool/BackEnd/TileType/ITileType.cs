using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public interface ITileType
    {
        EnumType Type { get; }
        EnumCoordinateType TypeSort { get; }
    }
}
