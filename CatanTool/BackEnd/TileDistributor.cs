using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BackEnd
{
    public class TileDistributor
    {
        List<ITileType> Tiletypes;
       public TileDistributor(EnumMapType type)
        {
            Tiletypes = new List<ITileType>();
            if(type == EnumMapType.small)
            {
                SetTileTypes();
            }
            if(type == EnumMapType.big)
            {
                SetLargeTileTypes();
            }
            shuffleTileList();
        }
        /// <summary>
        /// Gets one tile, and removes it from its total list.
        /// </summary>
        /// <returns></returns>
        public ITileType GetOneRandomTileTypeOfTypeSort(TypeSort typeSort)
        {
            IList<ITileType> sortedListTileType = GetListTileTypesOfTypeSort(typeSort);
            Random R = new Random();
            int randomnumber = R.Next(1, sortedListTileType.Count);
            ITileType result = sortedListTileType[randomnumber];
            RemoveTile(result);
            return result;
        }
        public IList<ITileType> GetListTileTypesOfTypeSort(TypeSort typeSort)
        {
            List<ITileType> resultTileTypeList = new List<ITileType>();
            foreach (ITileType tileTypeInList in Tiletypes)
            {
                if (tileTypeInList.TypeSort == typeSort)
                {
                    resultTileTypeList.Add(tileTypeInList);
                }
            }
            return resultTileTypeList;
        }
        public ITileType GetDesertTileType()
        {
            ITileType result = null;
            foreach (ITileType type in Tiletypes.ToList())
            {
                if(type.Type == Type.Desert)
                {
                    Tiletypes.Remove(type);
                    result = type;
                    break;
                }
            }
            return result;
        }
        private void RemoveTile(ITileType tileType)
        {
            Tiletypes.Remove(tileType);
        }

        private void shuffleTileList()//this could be useless.
        {
            Shuffler shuffler = new Shuffler();
            shuffler.Shuffle(Tiletypes);
        }


        private void SetTileTypes() //declaring all tiles for 4P map.
        {
            for (int i = 0; i < 18; i++)
            {
                Tiletypes.Add(new WaterTileType(Type.Water));
            }
            for (int i = 0; i < 9; i++)
            {
                Tiletypes.Add(new HarbourTileType(Type.OneToThreeHarbour));
            }
            for (int i = 0; i < 4; i++)
            {
                Tiletypes.Add(new LandTileType(Type.Wood));
                Tiletypes.Add(new LandTileType(Type.Meadow));
                Tiletypes.Add(new LandTileType(Type.Wheat));
            }
            for (int i = 0; i < 3; i++)
            {
                Tiletypes.Add(new LandTileType(Type.Ore));
                Tiletypes.Add(new LandTileType(Type.Stone));
            }
            Tiletypes.Add(new LandTileType(Type.Desert));
        }
        private void SetLargeTileTypes()// declaring all tiles for 6P map.
        {
            for (int i = 0; i < 22; i++)
            {
                Tiletypes.Add(new WaterTileType(Type.Water));
            }
            for (int i = 0; i < 11; i++)
            {
                Tiletypes.Add(new HarbourTileType(Type.OneToThreeHarbour));
            }
            for (int i = 0; i < 6; i++)
            {
                Tiletypes.Add(new LandTileType(Type.Wood));
                Tiletypes.Add(new LandTileType(Type.Meadow));
                Tiletypes.Add(new LandTileType(Type.Wheat));
            }
            for (int i = 0; i < 5; i++)
            {
                Tiletypes.Add(new LandTileType(Type.Ore));
                Tiletypes.Add(new LandTileType(Type.Stone));
            }
            Tiletypes.Add(new LandTileType(Type.Desert));
            Tiletypes.Add(new LandTileType(Type.Desert));
        }
    }
}
