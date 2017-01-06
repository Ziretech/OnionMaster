using UseCaseLayer.Rendering;
using NUnit.Framework;

namespace OnionMaster
{
    public static class RenderInfoTestExtensions
    {
        public static RenderInfo WillBeDrawnAtScreenCoordinates(this RenderInfo r, int x, int y)
        {
            Assert.AreEqual(x, r.ScreenX);
            Assert.AreEqual(y, r.ScreenY);
            return r;
        }

        public static RenderInfo AtLayer(this RenderInfo r, int layer)
        {
            Assert.AreEqual(layer, r.ScreenLayer);
            return r;
        }

        public static RenderInfo CutFromTileSet(this RenderInfo r, int tileSetId)
        {
            Assert.AreEqual(tileSetId, r.TileSetId);
            return r;
        }

        public static RenderInfo StartingAt(this RenderInfo r, int x, int y)
        {
            Assert.AreEqual(x, r.TileSetX);
            Assert.AreEqual(y, r.TileSetY);
            return r;
        }

        public static RenderInfo WithSize(this RenderInfo r, int width, int height)
        {
            Assert.AreEqual(width, r.TileWidth);
            Assert.AreEqual(height, r.TileHeight);
            return r;
        }
    }
}
