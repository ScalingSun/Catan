﻿using System;
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
        private List<ITile> CreateLandTilesFor6And8()
        {
            List<ITile> landTiles8And6 = new List<ITile>();
            foreach (int num6Or8 in NumberDistributor.GetListNumbersOf(new List<int>() { 6, 8 }))
            {
                int number = num6Or8;
                ITileType tileType = TileDistributor.GetOneRandomTileTypeOfTypeSort(TypeSort.Land);
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
        private List<ITile> CreateRemainingNumbersForTiles()
        {
            List<ITile> landTiles = new List<ITile>();

            List<int> numbers = NumberDistributor.GetNumbers();
            ITileType tileType = TileDistributor.GetOneRandomTileTypeOfTypeSort(TypeSort.Land);
            Coordinate coordinate = CoordsDistributor.GetOneRandomLandCoordinate();
            foreach (int number in numbers)
            {
                ITile newTile = new LandTile(coordinate, tileType, number);
                landTiles.Add(newTile);
            }
            return landTiles;
        }
        private ITile CreateDesertTile()
        {
            ITileType tileType = TileDistributor.GetDesertTileType();
            Coordinate coordinate = CoordsDistributor.GetOneRandomLandCoordinate();
            int number = NumberDistributor.Get7FromList();

            ITile desertTile = new LandTile(coordinate, tileType, number);
            return desertTile;
        }
        public List<ITile> createtiles(EnumMapType type)
        {
            List<ITile> result = new List<ITile>();
            result.Add(CreateDesertTile());
            result.AddRange(CreateLandTilesFor6And8());
            result.AddRange(CreateRemainingNumbersForTiles());
            //result.AddRange(CreateHarbourTiles());
            //result.AddRange(CreateSeaTiles());
            return result;
        }
    }
}
