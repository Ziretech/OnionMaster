using UseCaseLayer.Rendering;

namespace AdaptorLayer
{
    public class DrawCommand
    {
        public int ScreenX { get; set; }
        public int ScreenY { get; set; }
        public int TileSetX { get; set; }
        public int TileSetY { get; set; }
        public int TileSetId { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public DrawCommand(int screenX, int screenY, int tileSetId, int tileSetX, int tileSetY, int tileWidth = 32, int tileHeight = 32)
        {
            ScreenX = screenX;
            ScreenY = screenY;
            TileSetX = tileSetX;
            TileSetY = tileSetY;
            TileSetId = tileSetId;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }

        public DrawCommand(RenderInfo renderInfo)
        {
            ScreenX = renderInfo.ScreenX;
            ScreenY = renderInfo.ScreenY;
            TileSetId = renderInfo.TileSetId;
            TileSetX = renderInfo.TileSetX;
            TileSetY = renderInfo.TileSetY;
            TileWidth = renderInfo.TileWidth;
            TileHeight = renderInfo.TileHeight;
        }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as DrawCommand);
        }

        private bool Equals(DrawCommand command)
        {
            return command != null &&
                ScreenX == command.ScreenX &&
                ScreenY == command.ScreenY &&
                TileSetId == command.TileSetId &&
                TileSetX == command.TileSetX &&
                TileSetY == command.TileSetY &&
                TileWidth == command.TileWidth &&
                TileHeight == command.TileHeight;
        }

        public override int GetHashCode()
        {
            return ScreenX ^ ScreenY ^ TileSetId ^ TileSetX ^ TileSetY ^ TileWidth ^ TileHeight;
        }

        public override string ToString()
        {
            return "Screen: " + ScreenX + ", " +
                ScreenY +
                " Tile: " + TileSetId + " @ " +
                TileSetX + ", " +
                TileSetY + " " +
                TileWidth + "x" +
                TileHeight;
        }
    }
}
