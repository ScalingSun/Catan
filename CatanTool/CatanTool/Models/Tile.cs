using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanTool.Models
{
    public class Tile
    {
        // THIS TILE OBJECT IS A MOCKUP FOR TESTING AND DEMONSTRATING THE VISUALISER PROTOTYPE.
        public int X { get; set; }
        public int Y { get; set; }
        public TEMPResourceEnum Resource { get; set; }

        public Tile(int y, int x)
        {
            X = x;
            Y = y;

            Random random = new Random();
            Resource = (TEMPResourceEnum)random.Next(0, 5);
        }
        public Tile(int y, int x, TEMPResourceEnum resource)
        {
            X = x;
            Y = y;
            Resource = resource;
        }

        // THIS TILE OBJECT IS A MOCKUP FOR TESTING AND DEMONSTRATING THE VISUALISER PROTOTYPE.
    }
}
