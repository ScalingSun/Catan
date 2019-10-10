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
            foreach (ITile tile in tiles)
            {
                tile[tileCoordinate.Xaxis]
            }
            if ()
            {

            }
        }
        public ITile GetTile(Coordinate coordinate)
        {
            foreach (ITile tile in tiles)
            {
                if (tile.Yaxis )
                {

                }
            }
        }
    }
}
