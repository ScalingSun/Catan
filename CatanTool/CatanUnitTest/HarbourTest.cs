using System;
using Xunit;
using BackEnd;
namespace CatanUnitTest
{
    public class HarbourTest
    {
        [Fact]
        public void HarbourTile_Construction_Xaxis_CorrectlySet()
        {
            HarbourTile a = new HarbourTile(0, 1, EnumTileType.Desert);
            Assert.Equal(0, a.Xaxis);
        }

        [Fact]
        public void HarbourTile_Construction_Yaxis_CorrectlySet()
        {
            HarbourTile a = new HarbourTile(0, 1, EnumTileType.Desert);
            Assert.Equal(1, a.Yaxis);
        }

        [Fact]
        public void HarbourTile_Construction_Resource_CorrectlySet()
        {
            HarbourTile a = new HarbourTile(0, 1, EnumTileType.Desert);
            Assert.Equal(EnumTileType.Desert, a.Resource);
        }
    }
}
