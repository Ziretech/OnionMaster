namespace EntityLayer
{
    public class TileDimension
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public TileDimension(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
