using NUnit.Framework;

namespace Tests.PathFinderTests
{
    [TestFixture]
    public class TilemapPathFinderTests
    {
        [Test]
        public void NoWallTest()
        {
            
        }
    }

    internal static class TestMaps
    {
        public static readonly string[] NoWallMaps =
        {
            @"
S...
....
F...
"
        };
    }
}
