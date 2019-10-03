using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    interface ITile
    {
        int Xaxis { get; }
        int Yaxis { get; }
        TileType Resource { get; }
    }
}
