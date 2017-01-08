using EntityLayer;

namespace UseCaseLayer.Rendering
{
    public class RenderInfo
    {
        public int ScreenX { get; private set; }
        public int ScreenY { get; private set; }
        public int ScreenLayer { get; private set; }
        public int TileSetX { get; private set; }
        public int TileSetY { get; private set; }
        public int TileSetId { get; private set; }
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }

        public RenderInfo(int screenX, int screenY, int screenLayer, int tileSetId, int tileSetX, int tileSetY, int tileWidth, int tileHeight)
        {
            ScreenX = screenX;
            ScreenY = screenY;
            ScreenLayer = screenLayer;
            TileSetId = tileSetId;
            TileSetX = tileSetX;
            TileSetY = tileSetY;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }

        public RenderInfo(Position positional, TileSetCoordinate tileSetCoordinate, TileDimension tileDimension)
            : this(positional.X, positional.Y, positional.Z, 
                  tileSetCoordinate.Id, tileSetCoordinate.X, tileSetCoordinate.Y, 
                  tileDimension.Width, tileDimension.Height)
        {
        }

        private bool Equals(RenderInfo other)
        {
            return other != null &&
                ScreenX == other.ScreenX &&
                ScreenY == other.ScreenY &&
                ScreenLayer == other.ScreenLayer &&
                TileSetId == other.TileSetId &&
                TileSetX == other.TileSetX &&
                TileSetY == other.TileSetY &&
                TileWidth == other.TileWidth &&
                TileHeight == other.TileHeight;
        }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as RenderInfo);
        }

        public override int GetHashCode()
        {
            return ScreenX ^ ScreenY ^ ScreenLayer ^ TileSetId ^ TileSetX ^ TileSetY ^ TileWidth ^ TileHeight;
        }

        public override string ToString()
        {
            return $"Screen: {ScreenX}, {ScreenY}, {ScreenLayer} Tile: {TileSetId}@{TileSetX}, {TileSetY} {TileWidth}x{TileHeight}";
        }
    }
}