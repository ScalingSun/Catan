using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class Coordinate
    {
        public int Xaxis { get; private set; }
        public int Yaxis { get; private set; }
        public EnumCoordinateType CoordinateType { get; private set; }
        public HarbourDirection Direction { get; private set; }
        [JsonConstructor]
        public Coordinate(int Yaxis, int Xaxis, EnumCoordinateType coordinateType, HarbourDirection direction)
        {
            this.Yaxis = Yaxis;
            this.Xaxis = Xaxis;
            CoordinateType = coordinateType;
            Direction = direction;
        }
        public Coordinate(int Yaxis, int Xaxis, EnumCoordinateType coordinateType)
        {
            this.Yaxis = Yaxis;
            this.Xaxis = Xaxis;
            CoordinateType = coordinateType;
        }
    }
}
