using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class Junction
    {
        public List<ITile> ThreeTiles { get; private set; }  
        public Junction(List<ITile> ThreeTiles)
        {
            this.ThreeTiles = ThreeTiles;
        }

        public ITile CalculateOneJunction(List<ITile> Tiles)
        {
            return null;
        }
    }
}
