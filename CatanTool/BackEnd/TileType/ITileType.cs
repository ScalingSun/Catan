using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public interface ITileType
    {
        Type Type { get; }
        TypeSort TypeSort { get; }
    }
}
