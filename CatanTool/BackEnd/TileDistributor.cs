using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BackEnd
{
    public class TileDistributor
    {
        List<EnumTileType> Tiletypes;
       public TileDistributor(EnumMapType type)
        {
            Tiletypes = new List<EnumTileType>();
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
        public EnumTileType GetOneTileType()// hier moet nog een algoritme voor komene
        {
            Random R = new Random();
            int randomnumber = R.Next(1, Tiletypes.Count);
            EnumTileType result = Tiletypes[randomnumber];
            RemoveTile(result);
            return result;
        }
        private void RemoveTile(EnumTileType tileType)
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
                Tiletypes.Add(EnumTileType.Sea);
            }
            for (int i = 0; i < 9; i++)
            {
                Tiletypes.Add(EnumTileType.OneToThreeHarbour);
            }
            for (int i = 0; i < 4; i++)
            {
                Tiletypes.Add(EnumTileType.Wood);
                Tiletypes.Add(EnumTileType.Meadow);
                Tiletypes.Add(EnumTileType.Wheat);
            }
            for (int i = 0; i < 3; i++)
            {
                Tiletypes.Add(EnumTileType.Ore);
                Tiletypes.Add(EnumTileType.Stone);
            }
            Tiletypes.Add(EnumTileType.Desert);
        }
        private void SetLargeTileTypes()// declaring all tiles for 6P map.
        {
            for (int i = 0; i < 22; i++)
            {
                Tiletypes.Add(EnumTileType.Sea);
            }
            for (int i = 0; i < 11; i++)
            {
                Tiletypes.Add(EnumTileType.OneToThreeHarbour);
            }
            for (int i = 0; i < 6; i++)
            {
                Tiletypes.Add(EnumTileType.Wood);
                Tiletypes.Add(EnumTileType.Wheat);
                Tiletypes.Add(EnumTileType.Meadow);
            }
            for (int i = 0; i < 5; i++)
            {
                Tiletypes.Add(EnumTileType.Ore);
                Tiletypes.Add(EnumTileType.Stone);

            }
            Tiletypes.Add(EnumTileType.Desert);
            Tiletypes.Add(EnumTileType.Desert);
        }
    }
}
