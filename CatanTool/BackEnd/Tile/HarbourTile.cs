using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class HarbourTile : ISeaTile
    {
        public Coordinate Coordinate { get; private set; }
        public ITileType Resource { get; private set; }

        public HarbourTile(Coordinate coordinate, ITileType resource)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
        public HarbourTile(Coordinate coordinate, LandTileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
        [JsonConstructor]
        public HarbourTile(Coordinate coordinate, HarbourTileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
        public HarbourTile(Coordinate coordinate, WaterTileType resource, int value)
        {
            Coordinate = coordinate;
            Resource = resource;
        }
    }
}
