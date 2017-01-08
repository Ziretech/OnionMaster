namespace EntityLayer
{
    public class TileSetCoordinate
    {
        public int Id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public TileSetCoordinate(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as TileSetCoordinate);
        }

        public bool Equals(TileSetCoordinate other)
        {
            return other != null &&
                Id == other.Id &&
                X == other.X &&
                Y == other.Y;
        }

        public override int GetHashCode()
        {
            return Id ^ X ^ Y;
        }

        public override string ToString()
        {
            return $"{Id}@{X},{Y}";
        }
    }
}
