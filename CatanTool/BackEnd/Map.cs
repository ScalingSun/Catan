using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd
{
    public class Map
    {
        EnumMapType maptype;
        List<Junction> junctions;
        public List<ITile> tiles;
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
            createtiles(maptype);
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
                if (landTile.Value == 8)
                {
                    return true;
                }
                if (landTile.Value == 6)
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
                if (tile.Coordinate.Yaxis == Coordinate.Yaxis - 1 && tile.Coordinate.Xaxis == Coordinate.Xaxis - 1 | tile.Coordinate.Xaxis == Coordinate.Xaxis)
                {
                    junctionTiles.Add(tile);
                }
                else if (tile.Coordinate.Yaxis == Coordinate.Yaxis && tile.Coordinate.Xaxis == Coordinate.Xaxis - 1 | tile.Coordinate.Xaxis == Coordinate.Xaxis + 1)
                {
                    junctionTiles.Add(tile);
                }
                else if (tile.Coordinate.Yaxis == Coordinate.Yaxis + 1 && tile.Coordinate.Xaxis == Coordinate.Xaxis | tile.Coordinate.Xaxis == Coordinate.Xaxis + 1)
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
        private void CreateLandTilesFor6And8()
        {
            foreach (int num6Or8 in NumberDistributor.GetListNumbersOf(new List<int>() { 6, 8 }))
            {
                int number = num6Or8;
                ITileType tileType = TileDistributor.GetOneRandomTileTypeOfTypeSort(EnumTypeSort.Land);
                Coordinate coordinate = null;
                
                bool numberIsntAssignedInTile = true;

                while (numberIsntAssignedInTile)
                {
                    coordinate = CoordsDistributor.GetOneRandomCoordinate(EnumTypeSort.Land);
                    if (!AdjacentsTilesHas6or8(GetAdjacentsTiles(coordinate)))
                    {
                        tiles.Add(new LandTile(coordinate, tileType, number));
                        numberIsntAssignedInTile = false;
                    }
                    else
                    {
                        CoordsDistributor.coords.Add(coordinate);
                    }
          
                }
            }
        }
        private List<ITile> CreateRemainingNumbersForTiles()
        {
            List<ITile> landTiles = new List<ITile>();

            List<int> numbers = NumberDistributor.GetNumbers();
            foreach (int number in numbers)
            {
                ITileType tileType = TileDistributor.GetOneRandomTileTypeOfTypeSort(EnumTypeSort.Land);
                Coordinate coordinate = CoordsDistributor.GetOneRandomCoordinate(EnumTypeSort.Land);
                ITile newTile = new LandTile(coordinate, tileType, number);
                landTiles.Add(newTile);
            }
            return landTiles;
        }
        private ITile CreateDesertTile()
        {
            ITileType tileType = TileDistributor.GetDesertTileType();
            Coordinate coordinate = CoordsDistributor.GetOneRandomCoordinate(EnumTypeSort.Land);
            int number = NumberDistributor.Get7FromList();

            ITile desertTile = new LandTile(coordinate, tileType, number);
            return desertTile;
        }
        public List<ITile> CreateHarbourTiles()
        {
            List<ITile> HarbourTiles = new List<ITile>();

            IList<ITileType> tileTypes = TileDistributor.GetListTileTypesOfTypeSort(EnumTypeSort.Harbour);
            List<Coordinate> coordinates = CoordsDistributor.GetListCoordinates(EnumTypeSort.Harbour);

            foreach(TileType tile in tileTypes)
            {
                HarbourTiles.Add(new HarbourTile(CoordsDistributor.GetOneRandomCoordinate(EnumTypeSort.Harbour), tile));
            }
            return HarbourTiles;

        }
        public List<ITile> CreateSeaTiles()
        {
            List<ITile> SeaTiles = new List<ITile>();
            IList<ITileType> tileTypes = TileDistributor.GetListTileTypesOfTypeSort(EnumTypeSort.Sea);
            List<Coordinate> coordinates = CoordsDistributor.GetListCoordinates(EnumTypeSort.Sea);

            foreach (TileType tile in tileTypes)
            {
                SeaTiles.Add(new WaterTile(CoordsDistributor.GetOneRandomCoordinate(EnumTypeSort.Sea), tile));
            }
            return SeaTiles;

        }
        public void createtiles(EnumMapType type)
        {
            if(type == EnumMapType.small)
            {
            tiles.Add(CreateDesertTile());
            }
            if(type == EnumMapType.big)
            {
                tiles.Add(CreateDesertTile());
                tiles.Add(CreateDesertTile());
            }
            CreateLandTilesFor6And8();
            tiles.AddRange(CreateRemainingNumbersForTiles());
            tiles.AddRange(CreateHarbourTiles());
            tiles.AddRange(CreateSeaTiles());
        }
        public List<ITile> createABCTiles()
        {
            List<ITile> result = new List<ITile>();
            result.Add(new HarbourTile(new Coordinate(0,0, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoStoneHarbour))); result.Add(new WaterTile(new Coordinate(0,1, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new HarbourTile(new Coordinate(0,2, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoWoodHarbour))); result.Add(new WaterTile(new Coordinate(0,3, EnumTypeSort.Sea), new WaterTileType(EnumType.Water)));
            result.Add(new WaterTile(new Coordinate(1,0, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new LandTile(new Coordinate(1,1, EnumTypeSort.Land), new LandTileType(EnumType.Wood), 5)); result.Add(new LandTile(new Coordinate(1,2, EnumTypeSort.Land), new LandTileType(EnumType.Wood), 10)); result.Add(new LandTile(new Coordinate(1,3, EnumTypeSort.Land), new LandTileType(EnumType.Wheat), 8)); result.Add(new HarbourTile(new Coordinate(1,4, EnumTypeSort.Harbour), new HarbourTileType(EnumType.OneToThreeHarbour)));
            result.Add(new HarbourTile(new Coordinate(2,0, EnumTypeSort.Harbour), new HarbourTileType(EnumType.OneToThreeHarbour))); result.Add(new LandTile(new Coordinate(2,1, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 2)); result.Add(new LandTile(new Coordinate(2,2, EnumTypeSort.Land), new LandTileType(EnumType.Desert), 7)); result.Add(new LandTile(new Coordinate(2,3, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 3)); result.Add(new LandTile(new Coordinate(2,4, EnumTypeSort.Land), new LandTileType(EnumType.Stone), 4)); result.Add(new WaterTile(new Coordinate(2,5, EnumTypeSort.Sea), new WaterTileType(EnumType.Water)));
            result.Add(new WaterTile(new Coordinate(3, 0, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new LandTile(new Coordinate(3,1, EnumTypeSort.Land), new LandTileType(EnumType.Ore), 6)); result.Add(new LandTile(new Coordinate(3,2, EnumTypeSort.Land), new LandTileType(EnumType.Wheat), 9)); result.Add(new LandTile(new Coordinate(3,3, EnumTypeSort.Land), new LandTileType(EnumType.Ore), 11)); result.Add(new LandTile(new Coordinate(3,4, EnumTypeSort.Land), new LandTileType(EnumType.Wood), 6)); result.Add(new LandTile(new Coordinate(3,5, EnumTypeSort.Land), new LandTileType(EnumType.Wheat), 11)); result.Add(new HarbourTile(new Coordinate(3,6, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoOreHarbour)));
            result.Add(new HarbourTile(new Coordinate(4, 1, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoWheatHarbour))); result.Add(new LandTile(new Coordinate(4,2, EnumTypeSort.Land), new LandTileType(EnumType.Stone), 3)); result.Add(new LandTile(new Coordinate(4, 3, EnumTypeSort.Land), new LandTileType(EnumType.Wood), 4)); result.Add(new LandTile(new Coordinate(4, 4, EnumTypeSort.Land), new LandTileType(EnumType.Stone), 5)); result.Add(new LandTile(new Coordinate(4, 5, EnumTypeSort.Land), new LandTileType(EnumType.Ore), 12)); result.Add(new WaterTile(new Coordinate(4, 6, EnumTypeSort.Sea), new WaterTileType(EnumType.Water)));
            result.Add(new WaterTile(new Coordinate(5, 2, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new LandTile(new Coordinate(5, 3, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 8)); result.Add(new LandTile(new Coordinate(5, 4, EnumTypeSort.Land), new LandTileType(EnumType.Wheat), 10)); result.Add(new LandTile(new Coordinate(5,5, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 9)); result.Add(new HarbourTile(new Coordinate(5, 6, EnumTypeSort.Harbour), new HarbourTileType(EnumType.OneToThreeHarbour)));
            result.Add(new HarbourTile(new Coordinate(6, 3, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoMeadowHarbour))); result.Add(new WaterTile(new Coordinate(6, 4, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new HarbourTile(new Coordinate(6,5, EnumTypeSort.Harbour), new HarbourTileType(EnumType.OneToThreeHarbour))); result.Add(new WaterTile(new Coordinate(6, 6, EnumTypeSort.Sea), new WaterTileType(EnumType.Water)));
            return result;
        }

        public List<ITile> createOreForWoolTiles()
        {
            List<ITile> result = new List<ITile>();
            result.Add(new WaterTile(new Coordinate(0,0, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new HarbourTile(new Coordinate(0,1, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoOreHarbour))); result.Add(new WaterTile(new Coordinate(0,2, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new HarbourTile(new Coordinate(0,3, EnumTypeSort.Harbour), new HarbourTileType(EnumType.OneToThreeHarbour)));
            result.Add(new HarbourTile(new Coordinate(1,0, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoWheatHarbour))); result.Add(new LandTile(new Coordinate(1,1, EnumTypeSort.Land), new LandTileType(EnumType.Stone), 8)); result.Add(new LandTile(new Coordinate(1,2, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 3)); result.Add(new LandTile(new Coordinate(1,3, EnumTypeSort.Land), new LandTileType(EnumType.Wood), 6)); result.Add(new WaterTile(new Coordinate(1,4, EnumTypeSort.Sea), new WaterTileType(EnumType.Water)));
            result.Add(new WaterTile(new Coordinate(2,0, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new LandTile(new Coordinate(2,1, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 2)); result.Add(new LandTile(new Coordinate(2,2, EnumTypeSort.Land), new LandTileType(EnumType.Wheat), 10)); result.Add(new LandTile(new Coordinate(2,3, EnumTypeSort.Land), new LandTileType(EnumType.Stone), 12)); result.Add(new LandTile(new Coordinate(2,4, EnumTypeSort.Land), new LandTileType(EnumType.Wheat), 9)); result.Add(new HarbourTile(new Coordinate(2,5, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoMeadowHarbour)));
            result.Add(new HarbourTile(new Coordinate(3,0, EnumTypeSort.Harbour), new HarbourTileType(EnumType.OneToThreeHarbour))); result.Add(new LandTile(new Coordinate(3,1, EnumTypeSort.Land), new LandTileType(EnumType.Wood), 4)); result.Add(new LandTile(new Coordinate(3,2, EnumTypeSort.Land), new LandTileType(EnumType.Desert), 7)); result.Add(new LandTile(new Coordinate(3,3, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 11)); result.Add(new LandTile(new Coordinate(3, 4, EnumTypeSort.Land), new LandTileType(EnumType.Ore), 6)); result.Add(new LandTile(new Coordinate(3, 5, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 5)); result.Add(new WaterTile(new Coordinate(3, 6, EnumTypeSort.Sea), new WaterTileType(EnumType.Water)));
            result.Add(new WaterTile(new Coordinate(4,1, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new LandTile(new Coordinate(4,2, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 8)); result.Add(new LandTile(new Coordinate(4,3, EnumTypeSort.Land), new LandTileType(EnumType.Wood), 5)); result.Add(new LandTile(new Coordinate(4,4, EnumTypeSort.Land), new LandTileType(EnumType.Meadow), 9)); result.Add(new LandTile(new Coordinate(4,5, EnumTypeSort.Land), new LandTileType(EnumType.Wood), 10)); result.Add(new HarbourTile(new Coordinate(4, 6, EnumTypeSort.Harbour), new HarbourTileType(EnumType.OneToThreeHarbour)));
            result.Add(new HarbourTile(new Coordinate(5, 2, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoStoneHarbour))); result.Add(new LandTile(new Coordinate(5, 3, EnumTypeSort.Land), new LandTileType(EnumType.Wheat), 11)); result.Add(new LandTile(new Coordinate(5,4, EnumTypeSort.Land), new LandTileType(EnumType.Stone), 4)); result.Add(new LandTile(new Coordinate(5,5, EnumTypeSort.Land), new LandTileType(EnumType.Wheat), 3)); result.Add(new WaterTile(new Coordinate(5,6, EnumTypeSort.Sea), new WaterTileType(EnumType.Water)));
            result.Add(new WaterTile(new Coordinate(6, 3, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new HarbourTile(new Coordinate(6,4, EnumTypeSort.Harbour), new HarbourTileType(EnumType.OneToThreeHarbour))); result.Add(new WaterTile(new Coordinate(6,5, EnumTypeSort.Sea), new WaterTileType(EnumType.Water))); result.Add(new HarbourTile(new Coordinate(6,6, EnumTypeSort.Harbour), new HarbourTileType(EnumType.TwoWoodHarbour)));
            return result;
        }
    }
}
