using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public interface ITile
    {
        int Xaxis { get; }
        int Yaxis { get; }
        EnumTileType Resource { get; }
    }
}
