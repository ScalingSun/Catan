﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class HarbourTile : ISeaTile
    {
        public int Xaxis { get; private set; }
        public int Yaxis { get; private set; }

        public EnumTileType Resource { get; private set; }

        public HarbourTile(int xaxis, int yaxis, EnumTileType resource)
        {
            Xaxis = xaxis;
            Yaxis = yaxis;
            Resource = resource;
        }
    }
}
