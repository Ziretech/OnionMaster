namespace EntityLayer
{
    public class Renderable
    {
        public Renderable(int tileId, int tileX, int tileY, int width, int height)
        {
            TileSetId = tileId;
            TileSetX = tileX;
            TileSetY = tileY;
            TileWidth = width;
            TileHeight = height;
        }

        public int TileSetId { get; set; }
        public int TileSetX { get; set; }
        public int TileSetY { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
    }
}