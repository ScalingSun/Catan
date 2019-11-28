using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class Coordinate
    {
        public int Xaxis { get; private set; }
        public int Yaxis { get; private set; }
        public EnumTypeSort CoordinateType { get; private set; }
        public HarbourDirection Direction { get; private set; }
        public Coordinate(int Yaxis, int Xaxis, EnumTypeSort coordinateType, HarbourDirection direction)
        {
            this.Yaxis = Yaxis;
            this.Xaxis = Xaxis;
            CoordinateType = coordinateType;
            Direction = direction;
        }
        public Coordinate(int Yaxis, int Xaxis, EnumTypeSort coordinateType)
        {
            this.Yaxis = Yaxis;
            this.Xaxis = Xaxis;
            CoordinateType = coordinateType;
        }
    }
}
