using System;
using System.Collections.Generic;

namespace BackEnd
{
    public class Map
    {
        EnumMapType maptype;
        List<ITile> tiles;
        TileDistributor TileDistributor;
        NumberDistributor NumberDistributor;
        CoordsDistributor CoordsDistributor;
        public Map(EnumMapType maptype)
        {
            tiles = new List<ITile>();
            this.maptype = maptype;

            TileDistributor = new TileDistributor(maptype);
            NumberDistributor = new NumberDistributor(maptype);
            CoordsDistributor = new CoordsDistributor(maptype);
            
        }

        public int GetTileValue(Coordinate tileCoordinate)
        {
            foreach (LandTile landTile in GetAdjacentsTiles(tileCoordinate))
            {
                if (landTile.Value != 8 && landTile.Value != 6)
                {

                }
            }
        }
        public List<ITile> GetAdjacentsTiles(Coordinate Coordinate)
        {
            List<ITile> junctionTiles = new List<ITile>();
            foreach (ITile tile in tiles)
            {
                if (tile.Coordinate.Yaxis == Coordinate.Yaxis - 1 & tile.Coordinate.Xaxis == Coordinate.Xaxis - 1 | tile.Coordinate.Xaxis == Coordinate.Xaxis)
                {
                    junctionTiles.Add(tile);
                }
                if (tile.Coordinate.Yaxis == Coordinate.Yaxis & tile.Coordinate.Xaxis == Coordinate.Xaxis - 1 | tile.Coordinate.Xaxis == Coordinate.Xaxis + 1)
                {
                    junctionTiles.Add(tile);
                }
                if (tile.Coordinate.Yaxis == Coordinate.Yaxis + 1 & tile.Coordinate.Xaxis == Coordinate.Xaxis | tile.Coordinate.Xaxis == Coordinate.Xaxis + 1)
                {
                    junctionTiles.Add(tile);
                }
            }
            return junctionTiles;
        }
        public ITile GetTile(Coordinate coordinate)
        {
            foreach (ITile tile in tiles)
            {
                if (tile.Coordinate == coordinate)
                {
                    return tile;
                }
            }
            return null;
        }
    }
}
