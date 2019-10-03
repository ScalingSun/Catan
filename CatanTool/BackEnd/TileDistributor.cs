using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BackEnd
{
    public class TileDistributor
    {
        List<TileType> Tiletypes;
       public TileDistributor(MapType type)
        {
            Tiletypes = new List<TileType>();
            if(type == MapType.small)
            {
                SetTileTypes();
            }
            if(type == MapType.big)
            {
                SetLargeTileTypes();
            }
            shuffleTileList();
        }
        /// <summary>
        /// Gets one tile, and removes it from its total list.
        /// </summary>
        /// <returns></returns>
        public TileType GetOneTileType()// hier moet nog een algoritme voor komene
        {
            Random R = new Random();
            int randomnumber = R.Next(1, Tiletypes.Count);
            TileType result = Tiletypes[randomnumber];
            RemoveTile(result);
            return result;
        }
        private void RemoveTile(TileType tileType)
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
                Tiletypes.Add(TileType.Sea);
            }
            for (int i = 0; i < 9; i++)
            {
                Tiletypes.Add(TileType.Harbour);
            }
            for (int i = 0; i < 4; i++)
            {
                Tiletypes.Add(TileType.Wood);
                Tiletypes.Add(TileType.Meadow);
                Tiletypes.Add(TileType.Wheat);
            }
            for (int i = 0; i < 3; i++)
            {
                Tiletypes.Add(TileType.Ore);
                Tiletypes.Add(TileType.Stone);
            }
            Tiletypes.Add(TileType.Desert);
        }
        private void SetLargeTileTypes()// declaring all tiles for 6P map.
        {
            for (int i = 0; i < 22; i++)
            {
                Tiletypes.Add(TileType.Sea);
            }
            for (int i = 0; i < 11; i++)
            {
                Tiletypes.Add(TileType.Harbour);
            }
            for (int i = 0; i < 6; i++)
            {
                Tiletypes.Add(TileType.Wood);
                Tiletypes.Add(TileType.Wheat);
                Tiletypes.Add(TileType.Meadow);
            }
            for (int i = 0; i < 5; i++)
            {
                Tiletypes.Add(TileType.Ore);
                Tiletypes.Add(TileType.Stone);

            }
            Tiletypes.Add(TileType.Desert);
            Tiletypes.Add(TileType.Desert);
        }
    }
}
