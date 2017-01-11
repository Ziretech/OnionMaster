namespace EntityLayer
{
    public class Frame
    {
        public Frame(TileSetCoordinate coordinate, TileDimension dimension, int time = 1)
        {
            TileSetCoordinate = coordinate;
            TileDimension = dimension;
            Duration = time;
        }

        public TileSetCoordinate TileSetCoordinate { get; set; }
        public TileDimension TileDimension { get; set; }
        public int Duration { get; set; }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as Frame);
        }

        public bool Equals(Frame other)
        {
            return other != null && 
                (TileSetCoordinate == other.TileSetCoordinate || (TileSetCoordinate != null && TileSetCoordinate.Equals(other.TileSetCoordinate))) &&
                (TileDimension == other.TileDimension || (TileDimension != null && TileDimension.Equals(other.TileDimension))) &&
                Duration == other.Duration;
        }

        public override int GetHashCode()
        {
            return TileSetCoordinate.GetHashCode() ^ TileDimension.GetHashCode() ^ Duration;
        }

        public override string ToString()
        {
            return $"{TileSetCoordinate.ToString()} {TileDimension} :{Duration}";
        }
    }
}
