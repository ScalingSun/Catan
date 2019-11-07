using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    //public enum EnumLandTileType
    //{
    //    Desert,Ore,Wheat,Meadow,Wood,Stone
    //}
    //public enum EnumHarbourTileType
    //{
    //    OneToThreeHarbour, TwoMeadowHarbour, TwoWoodHarbour, TwoOreHarbour, TwoWheatHarbour, TwoStoneHarbour
    //}
    public enum Type
    {
        Desert, Ore, Wheat, Meadow, Wood, Stone, OneToThreeHarbour, TwoMeadowHarbour, TwoWoodHarbour, TwoOreHarbour, TwoWheatHarbour, TwoStoneHarbour, Water
    }
    public enum TypeSort
    {
        Land,
        Sea
    }
    public enum EnumMapType
    {
        small = 7, big = 8
    }
    public enum EnumCoordinateType
    {
        Sea = 1,
        Land = 2
    }
}
