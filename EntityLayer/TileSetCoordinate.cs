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
    }
}
