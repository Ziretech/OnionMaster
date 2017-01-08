namespace EntityLayer
{
    public class Frame
    {
        public Frame(TileSetCoordinate coordinate, TileDimension dimension)
        {
            TileSetCoordinate = coordinate;
            TileDimension = dimension;
        }

        public TileSetCoordinate TileSetCoordinate { get; set; }
        public TileDimension TileDimension { get; set; }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as Frame);
        }

        public bool Equals(Frame other)
        {
            return other != null && 
                (TileSetCoordinate == other.TileSetCoordinate || (TileSetCoordinate != null && TileSetCoordinate.Equals(other.TileSetCoordinate))) &&
                (TileDimension == other.TileDimension || (TileDimension != null && TileDimension.Equals(other.TileDimension)));
        }

        public override int GetHashCode()
        {
            return TileSetCoordinate.GetHashCode() ^ TileDimension.GetHashCode();
        }

        public override string ToString()
        {
            return $"{TileSetCoordinate.ToString()} {TileDimension}";
        }
    }
}
