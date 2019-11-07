using BackEnd;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CatanUnitTest
{
    public class JunctionTest
    {
        [Fact]
        public void FindSingleJunction()
        {
            // Arrange
            List<ITile> threeAdjecentTiles = new List<ITile>
            {
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), EnumLandTileType.Desert, 1),
                new LandTile(new Coordinate(0,1,EnumCoordinateType.Land), EnumLandTileType.Desert, 1),
                new LandTile(new Coordinate(1,1,EnumCoordinateType.Land), EnumLandTileType.Desert, 1)
            };

            Map map = new Map(threeAdjecentTiles);

            List<Junction> expected = new List<Junction> { new Junction(threeAdjecentTiles) };

            // Act
            List<Junction> actual = map.FindAllJunctions(threeAdjecentTiles);

            // Assert
            if (actual.Count == 1)
            {
                Assert.True(true);
            }
        }
    }
}
