using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BackEnd;
namespace CatanUnitTest
{
    public class MapTest
    {
        [Fact]
        public void mahnigga()
        {
            Map map = new Map(EnumMapType.small);
            List<ITile> tiles = map.createtiles(EnumMapType.small);
            string aap = "a";
        }

    }
}
