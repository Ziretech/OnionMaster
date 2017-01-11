namespace EntityLayer
{
    public class Frame
    {
        public Frame(TileSetCoordinate coordinate, TileDimension dimension, int time = 1)
        {
            TileSetCoordinate = coordinate;
            TileDimension = dimension;
            Time = time;
        }

        public TileSetCoordinate TileSetCoordinate { get; set; }
        public TileDimension TileDimension { get; set; }
        public int Time { get; set; }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as Frame);
        }

        public bool Equals(Frame other)
        {
            return other != null && 
                (TileSetCoordinate == other.TileSetCoordinate || (TileSetCoordinate != null && TileSetCoordinate.Equals(other.TileSetCoordinate))) &&
                (TileDimension == other.TileDimension || (TileDimension != null && TileDimension.Equals(other.TileDimension))) &&
                Time == other.Time;
        }

        public override int GetHashCode()
        {
            return TileSetCoordinate.GetHashCode() ^ TileDimension.GetHashCode() ^ Time;
        }

        public override string ToString()
        {
            return $"{TileSetCoordinate.ToString()} {TileDimension} :{Time}";
        }
    }
}
