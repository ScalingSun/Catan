﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class LandTile : ITile, ILandTile
    {
        public Coordinate Coordinate { get; private set; }
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public ITileType Resource { get; private set; }
        public int Value { get; private set; }

        public LandTile(Coordinate coordinate, ITileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
            Value = value;
        }
        [JsonConstructor]
        public LandTile(Coordinate coordinate, LandTileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
            Value = value;
        }
    }
}
