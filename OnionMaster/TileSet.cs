namespace OnionMaster
{
    public class TileSet
    {
        public int Texture { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public TileSet(int texture, int width, int height)
        {
            Texture = texture;
            Width = width;
            Height = height;
        }
    }
}
