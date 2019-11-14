using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd
{
    public class Map
    {
        EnumMapType maptype;
        List<ITile> tiles;
        List<Junction> junctions;
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
            for (int tileNum = 0; tileNum < (int)maptype; tileNum++)
            {
                
            }
        }
        public Map(List<ITile> inTiles)
        {
            tiles = inTiles;
        }

        public List<Junction> FindAllJunctions(List<ITile> mapTiles)
        {
            List<Junction> foundJunctions = new List<Junction>();

            foreach (ITile originTile in mapTiles)
            {
                List<ITile> adjecentTiles = GetAdjacentsTiles(originTile.Coordinate);
                List<ITile> secondaryAdjecentTiles = null;
                try
                {
                    secondaryAdjecentTiles = GetAdjacentsTiles(adjecentTiles[0].Coordinate);
                }
                catch
                {
                    continue;
                }
                
                foreach(ITile adjecentTile in adjecentTiles)
                {
                    foreach (ITile secondaryAdjecentTile in secondaryAdjecentTiles)
                    {
                        if (adjecentTile == secondaryAdjecentTile && (adjecentTile != originTile || secondaryAdjecentTile != originTile))
                        {
                            Junction junction = new Junction(new List<ITile> { originTile, adjecentTile, secondaryAdjecentTile });

                            if (foundJunctions.Where(j => j.ThreeTiles.Contains(originTile) && j.ThreeTiles.Contains(adjecentTile) && j.ThreeTiles.Contains(secondaryAdjecentTile)).Count() == 0)
                            {
                                foundJunctions.Add(junction);
                            }
                        }
                    }
                }
            }

            return foundJunctions;
        }

        public bool AdjacentsTilesHas6or8(List<ITile> AdjacentsTiles)
        {
            foreach (LandTile landTile in AdjacentsTiles)
            {
                if (landTile.Value == 8 && landTile.Value == 6)
                {
                    return true;
                }
            }
            return false;
        }

        public List<ITile> GetAdjacentsTiles(Coordinate Coordinate)
        {
            List<ITile> junctionTiles = new List<ITile>();
            foreach (ITile tile in tiles)
            {
                if (tile.Coordinate.Yaxis == Coordinate.Yaxis - 1 && (tile.Coordinate.Xaxis == Coordinate.Xaxis - 1 || tile.Coordinate.Xaxis == Coordinate.Xaxis))
                {
                    junctionTiles.Add(tile);
                }
                if (tile.Coordinate.Yaxis == Coordinate.Yaxis && (tile.Coordinate.Xaxis == Coordinate.Xaxis - 1 || tile.Coordinate.Xaxis == Coordinate.Xaxis + 1))
                {
                    junctionTiles.Add(tile);
                }
                if (tile.Coordinate.Yaxis == Coordinate.Yaxis + 1 && (tile.Coordinate.Xaxis == Coordinate.Xaxis || tile.Coordinate.Xaxis == Coordinate.Xaxis + 1))
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
        public List<ITile> CreateLandTilesFor6And8()
        {
            List<ITile> landTiles8And6 = new List<ITile>();
            foreach (int num6Or8 in NumberDistributor.GetListNumbersOf(new List<int>() { 6, 8 }))
            {
                int number = num6Or8;
                EnumLandTileType tileType = TileDistributor.GetOneLandTileType();//should be tiledistributor.GetOneLANDtiletype.
                Coordinate coordinate = CoordsDistributor.GetOneRandomLandCoordinate();
                bool numberIsntAssignedInTile = true;

                while (numberIsntAssignedInTile)
                {
                    if (!AdjacentsTilesHas6or8(GetAdjacentsTiles(coordinate)))
                    {
                        landTiles8And6.Add(new LandTile(coordinate, tileType, number));
                        numberIsntAssignedInTile = false;
                    }
                   coordinate = CoordsDistributor.GetOneRandomLandCoordinate();            
                }
            }
            return landTiles8And6;
        }
    }
}
