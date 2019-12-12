using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class WaterTile : ISeaTile
    {
        public Coordinate Coordinate { get; private set; }
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public ITileType Resource { get; private set; }

        public WaterTile(Coordinate coordinate, ITileType resource)
        {
            Coordinate = coordinate;
            Resource = new WaterTileType(EnumType.Water);
        }
        public WaterTile(Coordinate coordinate, LandTileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
        public WaterTile(Coordinate coordinate, HarbourTileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
        [JsonConstructor]
        public WaterTile(Coordinate coordinate, WaterTileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
    }
}
