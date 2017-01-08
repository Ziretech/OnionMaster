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

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as TileDimension);
        }

        public bool Equals(TileDimension other)
        {
            return other != null &&
                Width == other.Width &&
                Height == other.Height;
        }

        public override int GetHashCode()
        {
            return Width ^ Height;
        }

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
}
