using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public enum EnumLandTileType
    {
        Desert,Ore,Wheat,Meadow,Wood,Stone
    }
    public enum EnumWaterTileType
    {
        Sea
    }
    public enum EnumHarbourTileType
    {
        OneToThreeHarbour, TwoMeadowHarbour, TwoWoodHarbour, TwoOreHarbour, TwoWheatHarbour, TwoStoneHarbour
    }
    enum EnumTypes
    {
        Desert, Ore, Wheat, Meadow, Wood, Stone, OneToThreeHarbour, TwoMeadowHarbour, TwoWoodHarbour, TwoOreHarbour, TwoWheatHarbour, TwoStoneHarbour
    }
    enum TypeSort
    {
        Land,
        Sea
    }
    class TileType
    {
        public EnumTypes type { get; set; }
        public EnumHarbourTileType typesort { get; set; }
    }
}
