using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class Coordinate
    {
        public int Xaxis { get; private set; }
        public int Yaxis { get; private set; }
        public Coordinate(int Yaxis,int Xaxis)
        {
            this.Yaxis = Yaxis;
            this.Xaxis = Xaxis;
        }
    }
}
