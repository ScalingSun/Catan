using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BackEnd
{
    public class TileDistributor
    {
        List<EnumLandTileType> Tiletypes;
       public TileDistributor(EnumMapType type)
        {
            Tiletypes = new List<EnumLandTileType>();
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
        public EnumLandTileType GetOneLandTileType()
        {
            Random R = new Random();
            int randomnumber = R.Next(1, Tiletypes.Count);
            EnumLandTileType result = Tiletypes[randomnumber];
            RemoveTile(result);
            return result;
        }
        private void RemoveTile(EnumLandTileType tileType)
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
                Tiletypes.Add(EnumLandTileType.Sea);
            }
            for (int i = 0; i < 9; i++)
            {
                Tiletypes.Add(EnumLandTileType.OneToThreeHarbour);
            }
            for (int i = 0; i < 4; i++)
            {
                Tiletypes.Add(EnumLandTileType.Wood);
                Tiletypes.Add(EnumLandTileType.Meadow);
                Tiletypes.Add(EnumLandTileType.Wheat);
            }
            for (int i = 0; i < 3; i++)
            {
                Tiletypes.Add(EnumLandTileType.Ore);
                Tiletypes.Add(EnumLandTileType.Stone);
            }
            Tiletypes.Add(EnumLandTileType.Desert);
        }
        private void SetLargeTileTypes()// declaring all tiles for 6P map.
        {
            for (int i = 0; i < 22; i++)
            {
                Tiletypes.Add(EnumLandTileType.Sea);
            }
            for (int i = 0; i < 11; i++)
            {
                Tiletypes.Add(EnumLandTileType.OneToThreeHarbour);
            }
            for (int i = 0; i < 6; i++)
            {
                Tiletypes.Add(EnumLandTileType.Wood);
                Tiletypes.Add(EnumLandTileType.Wheat);
                Tiletypes.Add(EnumLandTileType.Meadow);
            }
            for (int i = 0; i < 5; i++)
            {
                Tiletypes.Add(EnumLandTileType.Ore);
                Tiletypes.Add(EnumLandTileType.Stone);

            }
            Tiletypes.Add(EnumLandTileType.Desert);
            Tiletypes.Add(EnumLandTileType.Desert);
        }
    }
}
