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

        private bool TilesAreSame(ITile tile1, ITile tile2)
        {
            if (tile1.Coordinate.Xaxis == tile2.Coordinate.Xaxis && tile1.Coordinate.Yaxis == tile2.Coordinate.Yaxis)
            {
                return true;
            }
            return false;
        }

        public List<Junction> FindAllJunctions(List<ITile> mapTiles)
        {
            List<Junction> foundJunctions = new List<Junction>();

            foreach (ITile originTile in mapTiles)
            {
                List<ITile> adjecentTiles = GetAdjacentTiles(originTile.Coordinate);

                foreach (ITile adjecentTile in adjecentTiles)
                {
                    List<ITile> secondaryAdjecentTiles = GetAdjacentTiles(adjecentTile.Coordinate);

                    foreach (ITile secondaryAdjecentTile in secondaryAdjecentTiles)
                    {
                        bool tisnto1 = TileIsNextToOrigin(originTile, adjecentTile);
                        bool tisnto2 = TileIsNextToOrigin(originTile, secondaryAdjecentTile);
                        bool tas = TilesAreSame(originTile, secondaryAdjecentTile);

                        if (TileIsNextToOrigin(originTile, adjecentTile) && TileIsNextToOrigin(originTile, secondaryAdjecentTile) && !TilesAreSame(originTile, secondaryAdjecentTile))
                        {
                            if (foundJunctions.Where(fj => fj.ThreeTiles.Contains(originTile) && fj.ThreeTiles.Contains(adjecentTile) && fj.ThreeTiles.Contains(secondaryAdjecentTile)).Count() == 0)
                            {
                                foundJunctions.Add(new Junction(new List<ITile> { originTile, adjecentTile, secondaryAdjecentTile }));
                            }
                        }
                    }
                }
            }

            return foundJunctions;
        }

        private bool TileIsNextToOrigin(ITile originTile, ITile adjecentTile)
        {
            if (originTile.Coordinate.Xaxis == adjecentTile.Coordinate.Xaxis && originTile.Coordinate.Yaxis == adjecentTile.Coordinate.Yaxis)
            {
                return false;
            }

            if (originTile.Coordinate.Xaxis - 1 <= adjecentTile.Coordinate.Xaxis && originTile.Coordinate.Xaxis + 1 >= adjecentTile.Coordinate.Xaxis)
            {
                if (originTile.Coordinate.Yaxis - 1 <= adjecentTile.Coordinate.Yaxis && originTile.Coordinate.Yaxis + 1 >= adjecentTile.Coordinate.Yaxis)
                {
                    if (originTile.Coordinate.Xaxis == adjecentTile.Coordinate.Yaxis ^ originTile.Coordinate.Yaxis == adjecentTile.Coordinate.Xaxis)
                    {
                        return true;
                    }  
                }
            }

            return false;
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

        public List<ITile> GetAdjacentTiles(Coordinate Coordinate)
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
                    if (!AdjacentsTilesHas6or8(GetAdjacentTiles(coordinate)))
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
