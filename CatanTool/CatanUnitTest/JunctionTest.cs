using BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CatanUnitTest
{
    public class JunctionTest
    {
        [Fact]
        public void ThreeTileJunction()
        {
            // Arrange
            List<ITile> tiles = new List<ITile>
            {
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 1),
                new LandTile(new Coordinate(0,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 2),
                new LandTile(new Coordinate(1,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 3)
            };

            Map map = new Map(tiles);

            int expectedCount = 1;

            // Act
            map.FindAllJunctions(tiles);
            int actual = map.Junctions.Count;

            // Assert
            Assert.Equal(expectedCount, actual);
        }



        [Fact]
        public void NoJunctionFound()
        {
            // Arrange
            List<ITile> tiles = new List<ITile>
            {
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 1),
                new LandTile(new Coordinate(4,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 2),
                new LandTile(new Coordinate(1,4,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 3)
            };

            Map map = new Map(tiles);

            int expectedCount = 0;

            // Act
            map.FindAllJunctions(tiles);
            int actual = map.Junctions.Count;

            // Assert
            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public void RandomTileOrderMapJunctions()
        {
            // Arrange
            List<ITile> tiles = new List<ITile>
            {
                new LandTile(new Coordinate(1,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 4),
                new LandTile(new Coordinate(1,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 3),
                new LandTile(new Coordinate(1,2,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 5),
                new LandTile(new Coordinate(0,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 2),
                new LandTile(new Coordinate(2,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 6),
                new LandTile(new Coordinate(2,2,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 7),
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 1)
            };

            Map map = new Map(tiles);

            int expectedCount = 6;

            // Act
            map.FindAllJunctions(tiles);
            int actual = map.Junctions.Count;

            // Assert
            Assert.Equal(expectedCount, actual);
        }

        [Fact]
        public void MultipleMapJunctions()
        {
            // Arrange
            List<ITile> tiles = new List<ITile>
            {
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 1),
                new LandTile(new Coordinate(0,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 2),
                new LandTile(new Coordinate(1,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 3),
                new LandTile(new Coordinate(1,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 4),
                new LandTile(new Coordinate(1,2,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 5),
                new LandTile(new Coordinate(2,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 6),
                new LandTile(new Coordinate(2,2,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 7)
            };

            Map map = new Map(tiles);

            int expectedCount = 6;

            // Act
            map.FindAllJunctions(tiles);
            int actual = map.Junctions.Count;

            // Assert
            Assert.Equal(expectedCount, actual);
        }
        
        [Fact]
        public void FindAllAdjecentTiles()
        {
            // Arrange
            int expectedFoundCount = 6;

            List<ITile> tiles = new List<ITile>
            {
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 1),
                new LandTile(new Coordinate(0,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 2),
                new LandTile(new Coordinate(1,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 3),
                new LandTile(new Coordinate(1,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 4),
                new LandTile(new Coordinate(1,2,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 5),
                new LandTile(new Coordinate(2,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 6),
                new LandTile(new Coordinate(2,2,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 7)
            };

            Map map = new Map(tiles);

            // Act
            List<ITile> foundTiles = map.GetAdjacentTiles(new Coordinate(1, 1, EnumCoordinateType.Land));
            int actualFoundCount = foundTiles.Count();

            int originTileCount = foundTiles.Where(t => t.Coordinate.Xaxis == 1 && t.Coordinate.Yaxis == 1).Count();

            // Assert
            Assert.Equal(0, originTileCount);
            Assert.Equal(expectedFoundCount, actualFoundCount);
        }

        [Fact]
        public void NoSameTilesInJunction()
        {
            // Arrange
            List<ITile> tiles = new List<ITile>
            {
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 1),
                new LandTile(new Coordinate(0,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 2),
                new LandTile(new Coordinate(1,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 3)
            };

            Map map = new Map(tiles);

            // Act
            map.FindAllJunctions(tiles);

            List<Junction> junctions = map.Junctions;

            // Assert
            if (junctions.Where(j => j.ThreeTiles.Contains(tiles[0])).Count() > 1)
            {
                Assert.False(true);
            }

            if (junctions.Where(j => j.ThreeTiles.Contains(tiles[1])).Count() > 1)
            {
                Assert.False(true);
            }

            if (junctions.Where(j => j.ThreeTiles.Contains(tiles[2])).Count() > 1)
            {
                Assert.False(true);
            }
        }

        [Fact]
        public void CalculateJunctionScoreTilesLowerThan7()
        {
            // Arrange
            int expected = 1+4+5;
            Junction junction = new Junction(new List<ITile> {
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 2),
                new LandTile(new Coordinate(0,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 5),
                new LandTile(new Coordinate(1,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 6)
            });

            // Act
            junction.CalculateScore();
            int actual = junction.Score;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateJunctionScoreTilesHigherThan7()
        {
            // Arrange
            int expected = 1 + 4 + 5;
            Junction junction = new Junction(new List<ITile> {
                new LandTile(new Coordinate(0,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 12),
                new LandTile(new Coordinate(0,1,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 9),
                new LandTile(new Coordinate(1,0,EnumCoordinateType.Land), new LandTileType(EnumType.Desert), 8)
            });

            // Act
            junction.CalculateScore();
            int actual = junction.Score;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
